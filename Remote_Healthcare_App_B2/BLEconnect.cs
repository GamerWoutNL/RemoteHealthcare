using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avans.TI.BLE;

namespace ErgoConnect
{
    // Original author:
    // Avans TI
    // Changes in structure made by B2. Also added file writing of data.
    class BLEconnect
    {
        public const System.String ergometerSerialLastFiveNumbers = "00472";
        public const bool printChecksum=false; 
        

        public static void Main(string[] args)
        {
            BLEconnect test = new BLEconnect();
            Console.Read();
        }

        public BLEconnect()
        {
            init();
        }

        public async void init()
        {
            ConnectToErgoAndHR(ergometerSerialLastFiveNumbers);
        }

        public async Task ConnectToErgoAndHR(String ergometerSerialLastFiveNumbers)
        {
            BLE ergometerBLE = new BLE();
            BLE heartrateBLE = new BLE();

            Thread.Sleep(1000);

            ScanConnectForErgo(ergometerBLE, ergometerSerialLastFiveNumbers);
            //ScanConnectForHR(heartrateBLE);
        }

        public async Task ScanConnectForErgo(BLE ergometerBLE, System.String ergometerSerialLastFiveNumbers)
        {
            System.Int32 errorCode = 0;

            // List available device 
            printDevices(ergometerBLE);

            // Ergometer Bluetooth Low Energy Code
            ConnectToErgoMeter(ergometerBLE, ergometerSerialLastFiveNumbers, errorCode);

            this.SendResistance(ergometerBLE, 100);
        }

        private async void ConnectToErgoMeter(BLE ergometerBLE, System.String ergometerSerialLastFiveNumbers, System.Int32 errorCode)
        {
            // Attempt to connect to the Ergometer.
            errorCode = await ergometerBLE.OpenDevice($"Tacx Flux {ergometerSerialLastFiveNumbers}"); // Example: Tacx Flux 01140

            // Receive bluetooth services and print afterwards, error check.
            printServices(ergometerBLE);

            // Set service
            errorCode = await ergometerBLE.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");

            // Subscribe 
            ergometerBLE.SubscriptionValueChanged += Ble_SubscriptionValueChanged;
            errorCode = await ergometerBLE.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");
        }

        public async Task ScanConnectForHR(BLE heartrateBLE)
        {
            System.Int32 errorCode = 0;

            // List available device
            printDevices(heartrateBLE);

            // Heart rate monitor Bluetooth Low Energy code
            ConnectToHeartRateSensor(heartrateBLE, errorCode);
        }

        private async void ConnectToHeartRateSensor(BLE heartrateSensorBLE, System.Int32 errorCode)
        {
            // Attempt to connect to the heart rate sensor.
            errorCode = await heartrateSensorBLE.OpenDevice("Decathlon Dual HR");

            // Set service
            await heartrateSensorBLE.SetService("HeartRate");

            // Subscribe
            heartrateSensorBLE.SubscriptionValueChanged += Ble_SubscriptionValueChanged;
            await heartrateSensorBLE.SubscribeToCharacteristic("HeartRateMeasurement");
        }

        private static void printServices(BLE ergoMeterBle)
        {
            List<BluetoothLEAttributeDisplay> services = ergoMeterBle.GetServices;
            foreach (BluetoothLEAttributeDisplay service in services)
            {
                Console.WriteLine($"Service: {service}");
            }
        }

        private static bool CheckXorValue(byte[] data, byte[] checksum)
        {
            int xorValue = 0;
            for (int i = 0; i < data.Length-1; i++)  
                xorValue ^= data[i];
            if (printChecksum)
                Console.WriteLine($"Xorvalue: {xorValue} Checksum: {data[data.Length-1]}");
            return xorValue == data[data.Length - 1];  
        }

        private static void printDevices(BLE ergoMeterBle)
        {
            List<String> bluetoothDeviceList = ergoMeterBle.ListDevices();
            Console.WriteLine("Devices currently found:");
            foreach (System.String deviceName in bluetoothDeviceList)
            {
                Console.WriteLine($"Device: {deviceName}");
            }
        }

        private void SendResistance(BLE ble, double percentage)
        {
            byte[] resistance = { 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, (byte)(percentage * 2) };
            ble.WriteCharacteristic("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e", resistance);
        }

        private void Ble_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            // Attempt to change resistance of vehicle.

            byte[] rawData = e.Data;
            int messageLength = rawData[1];
            byte[] message = rawData.Skip(4).Take(messageLength).ToArray();
            int pageNumber = message[0];
            byte[] checksum = rawData.Skip(4).Skip(messageLength).ToArray();
            //Console.WriteLine((int)rawData[4]);

            bool isCorrect = CheckXorValue(rawData, checksum);

            if (isCorrect)
            {
                if (pageNumber == 16)
                {
                    // decode page 16
                    double elapsedTime = message[2] * 0.25; //seconds
                    int distanceTraveled = message[3]; //metres
                    byte speedLSB = message[4];
                    byte speedMSB = message[5];
                    int heartRate = message[6]; // bpm
                    double speed = ((speedMSB << 8) | speedLSB) / 1000.0 * 3.6; //kmph

                    double[] data = {elapsedTime, distanceTraveled, speed, heartRate};

                    Console.WriteLine($"Elapsed Time: {Math.Round(data[0])} sec\t\t Distance: {data[1]} m\t\t Speed: {Math.Round(data[2])} kmph\t\t Heart rate: {data[3]} bpm");
                }
                else if (pageNumber == 25)
                {
                    // decode page 25
                    int updateEventCount = message[1]; //count
                    int instanteousCadence = message[2]; //rpm
                    byte accumulatedPowerLSB = message[3];
                    byte accumulatedPowerMSB = message[4];
                    byte instanteousPowerLSB = message[5];
                    byte instanteousPowerMSB = message[6];

                    int accumulatedPower = (accumulatedPowerMSB << 8) | accumulatedPowerLSB; //watt
                    int instanteousPower = (((instanteousPowerMSB | 0b11110000) ^ 0b11110000) << 8) | instanteousPowerLSB; //watt

                    double[] data = {updateEventCount, instanteousCadence, accumulatedPower, instanteousPower};

                    //Console.WriteLine($"Count: {Math.Round(data[0])}\t\t Cadence: {data[1]} rpm\t\t Acc power: {Math.Round(data[2])} Watt\t\t Inst power: {data[3]} Watt");
                }
            }
        }
    }
}
