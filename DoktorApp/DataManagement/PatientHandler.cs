using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using DoktorApp.Communication;
using System.Collections.Concurrent;

namespace DoktorApp.Data_Management
{
    public class PatientHandler
    {

        public ConcurrentBag<PatientStorage> patientStorages { get; set; }
        public Dictionary<PatientStorage, SmallPatientView> views { get; set; }

        public MainView mainView = null;
        public Client client = null;

        public PatientHandler()
        {
			patientStorages = new ConcurrentBag<PatientStorage>();
			views = new Dictionary<PatientStorage, SmallPatientView>();
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
			Console.WriteLine(message);
            string patientName = TagDecoder.GetValueByTag(Tag.PNA, message);
            string patientNumber = TagDecoder.GetValueByTag(Tag.PNU, message);
            string ergoId = TagDecoder.GetValueByTag(Tag.ID, message);

            string eventCount = TagDecoder.GetValueByTag(Tag.EC, message);

            string timestamp = TagDecoder.GetValueByTag(Tag.TS, message);
            string heartrate = TagDecoder.GetValueByTag(Tag.HR, message);
            string speed = TagDecoder.GetValueByTag(Tag.SP, message);
            string distance = TagDecoder.GetValueByTag(Tag.DT, message);
            string accuPower = TagDecoder.GetValueByTag(Tag.AP, message);
            string instPower = TagDecoder.GetValueByTag(Tag.IP, message);
            string instCadence = TagDecoder.GetValueByTag(Tag.IC, message);

            bool patientExists = false;
            PatientStorage patientStorage = null;

            foreach (PatientStorage storage in patientStorages)
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
                    addDataToCorrectLists(patientStorage, timestamp, heartrate, speed, distance, accuPower, instPower, instCadence);
                }
            }
            else
            {
				patientStorage = new PatientStorage(patientName, patientNumber, ergoId);

				if (patientStorage.PatientNumber != null)
				{
					addDataToCorrectLists(patientStorage, timestamp, heartrate, speed, distance, accuPower, instPower, instCadence);
					patientStorages.Add(patientStorage);
				}
              
            }
        }

        public void addDataToCorrectLists(PatientStorage patientStorage, string timestamp, string heartrate, string speed, string distance, string accuPower, string instPower, string instCadence)
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
            return this.views.ContainsKey(storage);
        }

        public void addView(PatientStorage storage, SmallPatientView view)
        {
            this.views.Add(storage, view);
        }

    }
}