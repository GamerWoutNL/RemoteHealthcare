using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avans.TI.BLE;
using Client;
using ErgoConnect.BluetoothLowEnergy;

namespace ErgoConnect
{
	/// <summary>
	/// The BLEConnect class handles connecting to the Ergometer and Heart Rate Monitor. 
	/// </summary>
	public class BLEConnect
	{
		public System.String ergometerSerialLastFiveNumbers;
		public const bool printChecksum = false;
		private BLEDataHandler dataHandler;
		private BLESimulator bLESimulator;
		private IClient iClient;
		private ISim iSim;
		private bool isConnected = false;
        public BLE ergometerBLE { get; set; }
        public BLE heartrateBLE { get; set; }


        /// <summary>
        /// Constructor to setup some prequisites. The serial code of the Ergometer is needed to setup the connection.
        /// </summary>
        /// <param name="ergometerSerialLastFiveNumbers"></param>
        public BLEConnect(string ergometerSerialLastFiveNumbers, IClient iClient, ISim iSim, string patientName, string patientNumber)
		{
			this.ergometerSerialLastFiveNumbers = ergometerSerialLastFiveNumbers;
			bLESimulator = new BLESimulator(ergometerSerialLastFiveNumbers);
			this.dataHandler = new BLEDataHandler(ergometerSerialLastFiveNumbers, patientName, patientNumber);
			this.iClient = iClient;
			this.iSim = iSim;
		}

		public bool Connect()
		{
			ConnectToErgoAndHR(ergometerSerialLastFiveNumbers);
			return isConnected;
		}

		/// <summary>
		/// Helper method to connect to the Ergometer and Heart rate monitor. Uses the "Thread.Sleep(1000)" to give some time for scanning for BLE devices.
		/// </summary>
		/// <param name="ergometerSerialLastFiveNumbers"></param>
		/// <returns></returns>

		public async Task ConnectToErgoAndHR(string ergometerSerialLastFiveNumbers)
		{
			this.ergometerBLE = new BLE();
			this.heartrateBLE = new BLE();
			Thread.Sleep(2000);
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
		//	this.SendResistance(ergometerBLE, 0);  // Change ergometer resistance!
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
            string service1 = "6e40fec1-b5a3-f393-e0a9-e50e24dcca9e";
            errorCode = await ergometerBLE.SetService(service1);
			// Subscribe 
			ergometerBLE.SubscriptionValueChanged += Ergo_SubscriptionValueChanged;
            string service2 = "6e40fec2-b5a3-f393-e0a9-e50e24dcca9e";
            errorCode = await ergometerBLE.SubscribeToCharacteristic(service2);

			if (errorCode != 0) iSim.Create();
			Console.WriteLine(errorCode); // Errorcode to check if is connected.
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
				Console.WriteLine($"Service: {service}");
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
				Console.WriteLine($"Device: {deviceName}");
		}

		/// <summary>
		/// Attempt to change resistance of Ergometer.
		/// </summary>
		/// <param name="ble"></param>
		/// <param name="percentage"></param>

		public async void SendResistance(BLE ble, double percentage)
		{
            string service3 = "6e40fec3-b5a3-f393-e0a9-e50e24dcca9e";
            byte[] resistance = { 0xA4, 0x09, 0x4E, 0x05, 0x30, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, (byte)(percentage * 2), 0};
            byte checksum = BLEDecoder.GetXorValue(resistance);
            resistance[resistance.Length-1] = checksum;
			await ble.WriteCharacteristic(service3, resistance);
		}

        /// <summary>
        /// Callback for the Heart Rate sensor. Contains data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        async public void SetResistance(int percentage)
        {

            if (this.ergometerBLE != null)
            {
                byte[] message = new byte[13];
                message[0] = 0xA4;                     //Sync byte
                message[1] = 0x09;                     //Length of message is 8 bytes content + 1 channel byte
                message[2] = 0x4E;                     //Msg id 
                message[3] = 0x05;                     //Channel id
                message[4] = 0x30;                     //We want to change the resistance (0x30)
                for (int i = 5; i < 11; i++)
                    message[i] = 0xFF;
                message[11] = Convert.ToByte(percentage*2);  //Value of the resistance, 1 == 0.5%
                byte checksum = 0;
                for (int i = 1; i < 12; i++)
                    checksum ^= message[i];
                message[12] = checksum;
                await this.ergometerBLE.WriteCharacteristic("6e40fec3-b5a3-f393-e0a9-e50e24dcca9e", message);
            }
        }

        private void HR_SubscriptionValueChanged(object sender, BLESubscriptionValueChangedEventArgs e)
		{
			bLESimulator.SaveBytesHeartRate(e.Data);
			bLESimulator.WriteData(WriteOption.Heartrate);
			BLEDecoderHR.Decrypt(e.Data, this.dataHandler);
			string toSendHeartRateData = dataHandler.ReadLastData();
			iClient.Write(toSendHeartRateData);
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
			string toSendErgoData = dataHandler.ReadLastData();
			iClient.Write(toSendErgoData);
		}
	}
}
