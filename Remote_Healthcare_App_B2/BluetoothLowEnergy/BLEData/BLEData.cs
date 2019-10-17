using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public enum Tag
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
        ID, // Tag of Ergometer / simulator ID
		TS, // Timestamp
		MT, //The Message type of the message
        PNA, // The name of the patient
        PNU, // The number of the patient
        DATA // Data tag
    }

    /// <summary>
    /// Simple abstract class that defines potential BLEData. Can be implemented and expended by data classes.
    /// </summary>
    [Serializable]
    abstract public class BLEData
    {
        private double[] data;

        /// <summary>
        /// Costructor needs data, to define a corresponding action.
        /// </summary>
        /// <param name="data"></param>
        public BLEData(double[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// Abstract implementation the print data in the console. Must be implemented for testing and debug purposes.
        /// </summary>
        public abstract void PrintData();
        public abstract string GetData();



    }
}
