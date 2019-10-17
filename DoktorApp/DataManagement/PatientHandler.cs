using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoktorApp.Data_Management
{
    class PatientHandler
    {

        List<PatientStorage> patientStorages = new List<PatientStorage>();

        public PatientHandler()
        {

        }

        public void handleMessage(string message)
        {

            string patientnummerDummy = "123";

            bool patientExists = false;
            PatientStorage patientStorage;

            foreach(PatientStorage storage in patientStorages)
            {
                if (storage.PatientNumber.Equals(patientnummerDummy))
                {
                    patientExists = true;
                    patientStorage = storage;
                }
            }

            if (patientExists)
            {
                //Add the correct data to the corresponding lists
                //patientStorage.AddHeartrateDataPoint();
                //patientStorage.AddSpeedDataPoint();
                //patientStorage.AddDistanceDataPoint();
                //patientStorage.AddAccumulatedPowerDataPoint();
                //patientStorage.AddInstantaniousPowerDataPoint();
                //patientStorage.AddInstantaniousCadenceDataPoint();
            } else
            {
                patientStorage = new PatientStorage("Patient name", "Patient number");

                //patientStorage.AddHeartrateDataPoint();
                //patientStorage.AddSpeedDataPoint();
                //patientStorage.AddDistanceDataPoint();
                //patientStorage.AddAccumulatedPowerDataPoint();
                //patientStorage.AddInstantaniousPowerDataPoint();
                //patientStorage.AddInstantaniousCadenceDataPoint();

                patientStorages.Add(patientStorage);

            }


        }

        public enum TagErgo
        {
            // Page 16
            ET, // Elapsed time
            DT, // Distance travelled
            SP, // Speed
            HR, // Heartrate

            // Page 25
            EC, // Event count
            IC, // Instanteous cadence
            AP, // Accumulated power
            IP, // Instanteous power

            // Extra
            EOF, // End Of File
            ID,  // Tag of Ergometer / simulator ID
            TS,  // Timestamp
            MT   //The Message type of the message
        }

        private string GetValueByTag(TagErgo tag, string packet)
        {
            char openTag = '<';
            char closeTag = '>';
            if (tag != TagErgo.EOF)
            {
                string completeTag = $"{openTag}{tag.ToString()}{closeTag}";
                if (packet.Contains(completeTag))
                {
                    //  Console.WriteLine("Found and processed tag! {tag.ToString()}");
                    int startPosition = -1;
                    int endPosition = -1;
                    for (int i = packet.IndexOf(completeTag); i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == closeTag && i + 1 < packet.Length)
                        {
                            startPosition = i + 1;
                            break;
                        }
                    }
                    for (int i = startPosition; i < packet.Length; i++)
                    {
                        char characterAtIndex = packet[i];
                        if (characterAtIndex == openTag && i - 1 >= 0)
                        {
                            endPosition = i;
                            break;
                        }
                    }
                    try
                    {
                        string value = packet.Substring(startPosition, endPosition - startPosition);
                        //Console.WriteLine($"Found value corresponding with tag : {completeTag}{value}");
                        return value;
                    }
                    catch (ArgumentOutOfRangeException e) { Console.WriteLine($"Apparently something went wrong in the GetValueByTag() method located in the ServerClient class. Have you changed any code? {e.ToString()}"); }
                }
                // else Console.WriteLine("String does not contain your searched tag, have you added tags? Search tag: " + tag.ToString());
            }
            return String.Empty;
        }
    }
}
