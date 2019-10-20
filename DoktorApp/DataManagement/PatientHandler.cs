using DoktorApp.Communication;
using Server;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DoktorApp.Data_Management
{
	public class PatientHandler
	{

		public ConcurrentBag<PatientStorage> PatientStorages { get; set; }
		public Dictionary<PatientStorage, SmallPatientView> Views { get; set; }

		private MainView mainView;
		private Client client;

		public PatientHandler()
		{
			this.PatientStorages = new ConcurrentBag<PatientStorage>();
			this.Views = new Dictionary<PatientStorage, SmallPatientView>();
			this.mainView = null;
			this.client = null;
		}

		public void AttachMainView(MainView mainView)
		{
			this.mainView = mainView;
		}

		public void AttachClient(Client client)
		{
			this.client = client;
		}

		public void HandleMessage(string message)
		{
			string patientName = TagDecoder.GetValueByTag(Tag.PNA, message);
			string patientNumber = TagDecoder.GetValueByTag(Tag.PNU, message);
			string ergoId = TagDecoder.GetValueByTag(Tag.ID, message);

			string eventCount = TagDecoder.GetValueByTag(Tag.EC, message);

			string timestamp = Server.TagDecoder.GetValueByTag(Tag.TS, message);
			string heartrate = TagDecoder.GetValueByTag(Tag.HR, message);
			string speed = TagDecoder.GetValueByTag(Tag.SP, message);
			string distance = TagDecoder.GetValueByTag(Tag.DT, message);
			string accuPower = TagDecoder.GetValueByTag(Tag.AP, message);
			string instPower = TagDecoder.GetValueByTag(Tag.IP, message);
			string instCadence = TagDecoder.GetValueByTag(Tag.IC, message);

			bool patientExists = false;
			PatientStorage patientStorage = null;

			foreach (PatientStorage storage in this.PatientStorages)
			{
				if (storage.PatientNumber == patientNumber)
				{
					patientExists = true;
					patientStorage = storage;
				}
			}

			if (patientExists)
			{
				if (!patientStorage.PatientHasDataAlready(eventCount))
				{
					this.AddDataToCorrectLists(patientStorage, timestamp, heartrate, speed, distance, accuPower, instPower, instCadence);
				}
			}
			else
			{
				patientStorage = new PatientStorage(patientName, patientNumber, ergoId);

				if (patientStorage.PatientNumber != null)
				{
					this.AddDataToCorrectLists(patientStorage, timestamp, heartrate, speed, distance, accuPower, instPower, instCadence);

					if (this.client != null)
					{
						this.mainView.NewClientConnects(patientName, patientNumber, this.client, patientStorage);
					}

					this.PatientStorages.Add(patientStorage);
				}
			}
		}

		public void AddDataToCorrectLists(PatientStorage patientStorage, string timestamp, string heartrate, string speed, string distance, string accuPower, string instPower, string instCadence)
		{
			patientStorage.AddHeartrateDataPoint(timestamp, heartrate);
			patientStorage.AddSpeedDataPoint(timestamp, speed);
			patientStorage.AddDistanceDataPoint(timestamp, distance);
			patientStorage.AddAccumulatedPowerDataPoint(timestamp, accuPower);
			patientStorage.AddInstantaniousPowerDataPoint(timestamp, instPower);
			patientStorage.AddInstantaniousCadenceDataPoint(timestamp, instCadence);
		}

		public bool StorageHasView(PatientStorage storage)
		{
			return this.Views.ContainsKey(storage);
		}

		public void AddView(PatientStorage storage, SmallPatientView view)
		{
			this.Views.Add(storage, view);
		}

	}
}