using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint2VR.VR
{
    public class VRConnectionHandler
    {
        public Client _client { get; private set; }

        public VRConnectionHandler(string ip, int port)
        {
            this._client = new Client();
            this._client.Connect(ip, port);
        }

        public void connect(string serverIP, int port)
        {
            this._client.Connect(serverIP, port);
        }

        public void DisconnectClient()
        {
            this._client.Disconnect();
        }
    }
}
