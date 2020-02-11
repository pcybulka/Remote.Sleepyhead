using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote.Sleepyhead.Library.Service
{
    class Bluetooth
    {
        private bool execute;

        private Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");

        public void Start()
        {
            execute = true;
            ServerConnectThread();
        }

        public void Stop()
        {
            execute = false;
        }

        private void ServerConnectThread()
        {
            Console.WriteLine("Server started, waiting for clients");
            BluetoothListener blueListener = new BluetoothListener(mUUID);
            blueListener.Start();
            BluetoothClient conn = blueListener.AcceptBluetoothClient();
            Console.WriteLine("Client has connected");

            Stream mStream = conn.GetStream();
            while (execute)
            {
                try
                {
                    byte[] received = new byte[1024];
                    mStream.Read(received, 0, received.Length);
                    Operation operation = Newtonsoft.Json.JsonConvert.DeserializeObject<Operation>(Encoding.UTF8.GetString(received));
                    OperationMethods.ExecuteMethod(operation);
                }
                catch (IOException exception)
                {
                    Console.WriteLine("Client has disconnected!!!!");
                    execute = false;
                }
            }
        }
    }
}
