using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using DoktorApp.Communication;

namespace DoktorApp.Data_Management
{
    public class PatientHandler
    {

        List<PatientStorage> patientStorages = new List<PatientStorage>();

        public MainView mainView = null;
        public Client client = null;

        public PatientHandler()
        {

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

            string patientnummerDummy = "123";

            string patientName = TagDecoder.GetValueByTag(Tag.PNA, message);
            string patientNumber = TagDecoder.GetValueByTag(Tag.PNU, message);

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

            foreach (PatientStorage storage in patientStorages)
            {
                if (storage.PatientNumber.Equals(patientnummerDummy))
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
                patientStorage = new PatientStorage(patientName, patientNumber);

                addDataToCorrectLists(patientStorage, timestamp, heartrate, speed, distance, accuPower, instPower, instCadence);

                if (this.mainView != null && this.client != null)
                {
                    this.mainView.NewClientConnects(patientName, patientNumber, this.client, patientStorage);
                }

                patientStorages.Add(patientStorage);

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

    }
}