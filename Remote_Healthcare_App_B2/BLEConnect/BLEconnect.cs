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
    // Changes in structure made by B2. Also added functionality.
    public class BLEconnect
    {
        public const System.String ergometerSerialLastFiveNumbers = "00472";
        public const bool printChecksum=false;
        private BLEDataHandler dataHandler;
        private BLESimulator bLESimulator = new BLESimulator(ergometerSerialLastFiveNumbers);

        public BLEconnect(System.String ergometerSerialLastFiveNumbers)
        {
            init(ergometerSerialLastFiveNumbers);
            this.dataHandler = new BLEDataHandler(ergometerSerialLastFiveNumbers);
        }

        public async void init(System.String ergometerSerialLastFiveNumbers)
        {
            ConnectToErgoAndHR(ergometerSerialLastFiveNumbers);
        }

        public async Task ConnectToErgoAndHR(String ergometerSerialLastFiveNumbers)
        {
            BLE ergometerBLE = new BLE();
            BLE heartrateBLE = new BLE();

            Thread.Sleep(1000);

            await ScanConnectForErgo(ergometerBLE, ergometerSerialLastFiveNumbers);
            await ScanConnectForHR(heartrateBLE);
        }

        public async Task ScanConnectForErgo(BLE ergometerBLE, System.String ergometerSerialLastFiveNumbers)
        {
            System.Int32 errorCode = 0;
            // List available device 
            printDevices(ergometerBLE);
            // Ergometer Bluetooth Low Energy Code
            ConnectToErgoMeter(ergometerBLE, ergometerSerialLastFiveNumbers, errorCode);
            //this.SendResistance(ergometerBLE, 100);  // Change ergometer resistance!
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
            ergometerBLE.SubscriptionValueChanged += Ergo_SubscriptionValueChanged;
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
            heartrateSensorBLE.SubscriptionValueChanged += HR_SubscriptionValueChanged;
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

        private void HR_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            bLESimulator.SaveBytesHeartRate(e.Data);
            bLESimulator.WriteData(WriteOption.Heartrate);
            BLEDecryptorHR.Decrypt(e.Data, this.dataHandler);
        }
        private void Ergo_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            bLESimulator.SaveBytesErgo(e.Data);
            bLESimulator.WriteData(WriteOption.Ergo);
            BLEDecryptorErgo.Decrypt(e.Data, this.dataHandler);   
        }
    }
}
