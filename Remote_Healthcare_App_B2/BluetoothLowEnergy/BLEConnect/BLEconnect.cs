using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avans.TI.BLE;

namespace ErgoConnect
{
    /// <summary>
    /// The BLEConnect class handles connecting to the Ergometer and Heart Rate Monitor. 
    /// </summary>
    public class BLEconnect
    {
        public System.String ergometerSerialLastFiveNumbers;
        public const bool printChecksum=false;
        private BLEDataHandler dataHandler;
        private BLESimulator bLESimulator;

        /// <summary>
        /// Constructor to setup some prequisites. The serial code of the Ergometer is needed to setup the connection.
        /// </summary>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        public BLEconnect(System.String ergometerSerialLastFiveNumbers)
        {
            this.ergometerSerialLastFiveNumbers = ergometerSerialLastFiveNumbers;
            bLESimulator = new BLESimulator(ergometerSerialLastFiveNumbers);
            init(ergometerSerialLastFiveNumbers);
            this.dataHandler = new BLEDataHandler(ergometerSerialLastFiveNumbers);
        }

        /// <summary>
        /// Attempt to connect to the Ergometer using the known serial number.
        /// </summary>
        /// <param name="ergometerSerialLastFiveNumbers"></param>

        public async void init(System.String ergometerSerialLastFiveNumbers)
        {
            ConnectToErgoAndHR(ergometerSerialLastFiveNumbers);
        }

        /// <summary>
        /// Helper method to connect to the Ergometer and Heart rate monitor. Uses the "Thread.Sleep(1000)" to give some time for scanning for BLE devices.
        /// </summary>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        /// <returns></returns>

        public async Task ConnectToErgoAndHR(String ergometerSerialLastFiveNumbers)
        {
            BLE ergometerBLE = new BLE();
            BLE heartrateBLE = new BLE();

            Thread.Sleep(1000);

            await ScanConnectForErgo(ergometerBLE, ergometerSerialLastFiveNumbers);
            await ScanConnectForHR(heartrateBLE);
        }

        /// <summary>
        /// Stores a potential error code and prints devices, afterwards the connection attempt to the ergometer is made.
        /// </summary>
        /// <param name="ergometerBLE"></param>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        /// <returns></returns>

        public async Task ScanConnectForErgo(BLE ergometerBLE, System.String ergometerSerialLastFiveNumbers)
        {
            System.Int32 errorCode = 0;
            // List available device 
            printDevices(ergometerBLE);
            // Ergometer Bluetooth Low Energy Code
            ConnectToErgoMeter(ergometerBLE, ergometerSerialLastFiveNumbers, errorCode);
            //this.SendResistance(ergometerBLE, 100);  // Change ergometer resistance!
        }

        /// <summary>
        /// Attempt to connect to the Ergometer. For this the serial code is needed, potential errors are logged in an integer "errorCode".
        /// </summary>
        /// <param name="ergometerBLE"></param>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        /// <param name="errorCode"></param>

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

        /// <summary>
        /// Scan for a BLE Heartrate device.
        /// </summary>
        /// <param name="heartrateBLE"></param>
        /// <returns></returns>

        public async Task ScanConnectForHR(BLE heartrateBLE)
        {
            System.Int32 errorCode = 0;
            // List available device
            printDevices(heartrateBLE);
            // Heart rate monitor Bluetooth Low Energy code
            ConnectToHeartRateSensor(heartrateBLE, errorCode);
        }

        /// <summary>
        /// Attempt to setup a connection with the Heart Rate monitor. 
        /// </summary>
        /// <param name="heartrateSensorBLE"></param>
        /// <param name="errorCode"></param>
        
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

        /// <summary>
        /// Print BLE services.
        /// </summary>
        /// <param name="ergoMeterBle"></param>

        private static void printServices(BLE ergoMeterBle)
        {
            List<BluetoothLEAttributeDisplay> services = ergoMeterBle.GetServices;
            foreach (BluetoothLEAttributeDisplay service in services)
            {
                Console.WriteLine($"Service: {service}");
            }
        }

        /// <summary>
        /// Print BLE devices.
        /// </summary>
        /// <param name="ergoMeterBle"></param>

        private static void printDevices(BLE ergoMeterBle)
        {
            List<String> bluetoothDeviceList = ergoMeterBle.ListDevices();
            Console.WriteLine("Devices currently found:");
            foreach (System.String deviceName in bluetoothDeviceList)
            {
                Console.WriteLine($"Device: {deviceName}");
            }
        }

        /// <summary>
        /// Attempt to change resistance of Ergometer.
        /// </summary>
        /// <param name="ble"></param>
        /// <param name="percentage"></param>

        private void SendResistance(BLE ble, double percentage)
        {
            byte[] resistance = { 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, (byte)(percentage * 2) };
            ble.WriteCharacteristic("6e40fec1-b5a3-f393-e0a9-e50e24dcca9e", resistance);
        }

        /// <summary>
        /// Callback for the Heart Rate sensor. Contains data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void HR_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            bLESimulator.SaveBytesHeartRate(e.Data);
            bLESimulator.WriteData(WriteOption.Heartrate);
            BLEDecoderHR.Decrypt(e.Data, this.dataHandler);
        }

        /// <summary>
        /// Callback for the Ergometer. Contains data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Ergo_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
        {
            bLESimulator.SaveBytesErgo(e.Data);
            bLESimulator.WriteData(WriteOption.Ergo);
            BLEDecoderErgo.Decrypt(e.Data, this.dataHandler);   
        }
    }
}
