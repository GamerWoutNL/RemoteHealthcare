using Sprint2VR.VR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VREngine.Additional
{
    public class VRResponseHandler
    {
        private dynamic[] responses;
        private int storageIndex = 0;
        public bool isCorrect = false;
        public VRResponseHandler(int buffer)
        {
            responses = new dynamic[buffer];
        }

        public void HandleResponse(dynamic response)
        {
            responses[storageIndex] = response;
            if (storageIndex++ > responses.Length - 1) storageIndex = 0;
        }

        public dynamic GetResponse(string IDOperation)
        {
            isCorrect = false;
            try
            {
                for (int i = 0; i < responses.Length; i++)
                {
                    Console.WriteLine("DATA IN RESPONSE HANDLER");
                    Console.WriteLine(responses[i].id+"  "+IDOperation);
                    if ((string)responses[i].id == IDOperation)
                    {
                        isCorrect = true;
                        return responses[i];
                    }
                    else if ((string)responses[i].id.data.id == IDOperation)
                    {
                        isCorrect = true;
                        return responses[i];
                    }
                }
            }
            catch (Exception e) {}
            return null;
        }
    }
}
