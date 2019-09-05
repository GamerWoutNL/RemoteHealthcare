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
        public const bool printChecksum=true; 
        

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
            //BLE bike = new BLE();
            //await bike.OpenDevice($"Tacx Flux {ergometerSerialLastFiveNumbers}");
            //await bike.SetService("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e");
            //bike.SubscriptionValueChanged += Bike_SubscriptionValueChanged;
            //await bike.SubscribeToCharacteristic("6e40fec2-b5a3-f393-e0a9-e50e24dcca9e");
        }

        //private void Bike_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        //{
        //    byte[] rawData = e.Data;
        //    int messageLength = rawData[1];
        //    byte[] message = rawData.Skip(5).Take(messageLength).ToArray();
        //    int pageNumber = message[0];
        //    byte[] checksum = rawData.Skip(5).Skip(messageLength).ToArray();

        //    if (pageNumber == 16)
        //    {
        //        // decode page 16
        //    }

        //    else if (pageNumber == 25)
        //    {
        //        // decode page 25
        //        byte updateEventCount = message[1];
        //        byte cadence = message[2];
        //    }
        //    CheckXorValue(rawData, checksum);
        //}

        public async Task ConnectToErgoAndHR(String ergometerSerialLastFiveNumbers)
        {
            //System.Int32 errorCode = 0;

            //BLE ergoMeterBle = new BLE();
            //BLE heartRateSensorBle = new BLE();

            //Thread.Sleep(1000); // Timeout to detect and list Bluetooth devices upon using constructor "new BLE()".

            //// To list available devices
            //printDevices(ergoMeterBle);

            ////---Ergometer Bluetooth Low Energy Code---
            //ConnectToErgoMeter(ergoMeterBle, ergometerSerialLastFiveNumbers, errorCode);

            ////---Heart rate Bluetooth Low Energy code---
            //ConnectToHeartRateSensor(heartRateSensorBle, errorCode);

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

        private void Ble_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            byte[] rawData = e.Data;
            int messageLength = rawData[1];
            byte[] message = rawData.Skip(5).Take(messageLength).ToArray();
            int pageNumber = message[0];
            byte[] checksum = rawData.Skip(5).Skip(messageLength).ToArray();
            if (pageNumber == 16)
            {
                // decode page 16
            }
            else if (pageNumber == 25)
            {
                // decode page 25
                byte updateEventCount = message[1];
                byte cadence = message[2];
            }
            bool isCorrect = CheckXorValue(rawData, checksum);
        }

        //private void Ble_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        //{
        //    byte[] rawBluetoothData = e.Data;
        //    byte sync = rawBluetoothData[0];
        //    int messageLength = rawBluetoothData[1];
        //    byte[] message = rawBluetoothData.Skip(5).Take(messageLength).ToArray();
        //    int dataPage = message[0];
       
        //    System.String serviceName = e.ServiceName;
        //    //System.String data = BitConverter.ToString(e.Data).Replace("-", String.Empty);
        //    System.String data = e.Data.ToString();
        //    System.String UTF8 = Encoding.UTF8.GetString(e.Data);
        //    Console.WriteLine($"ID:{ergometerSerialLastFiveNumbers} {serviceName} {data}");

        //    System.String path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/RemoteHealthcare/";
        //    if (!System.IO.Directory.Exists(path))
        //        System.IO.Directory.CreateDirectory(path);
        //    writeToFile($"{path}BLEdata.txt",  $"{ergometerSerialLastFiveNumbers} {data}");
        //}
    }
}
