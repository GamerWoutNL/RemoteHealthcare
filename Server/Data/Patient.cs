using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
	class Patient
	{
		private string _name;
		private ClientData _clientData;

		public Patient(string name)
		{
			this._name = name;
			this._clientData = new ClientData();
		}
	}
}
