using AudioSwitcher.AudioApi.CoreAudio;
using ScreenBrighnessClassNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote.Sleepyhead.Library.Service
{
    class OperationMethods
    {
        public static void ExecuteMethod(Operation Operation)
        {
            switch (Operation.Type)
            {
                case CommandType.SetBrightness:
                    SetBrightness(Operation.Number);
                    break;
                case CommandType.SetSoundlevel:
                    SetSoundlevel(Operation.Number);
                    break;
                case CommandType.Shutdown:
                    Shutdown(Operation.Number);
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy typ");
                    break;
            }
        }

        private static void SetBrightness(int number)
        {
            if (number > 255)
                number = 100;
            if (number < 0)
                number = 0;

            ScreenBrightness sb = new ScreenBrightness();
            Console.WriteLine("Aktualny poziom jasności to: " + sb.GetBrightness());

            sb.SetBrightness(Convert.ToByte(number));
        }
        private static void SetSoundlevel(int number)
        {
            if (number > 100)
                number = 100;
            if (number < 0)
                number = 0;

            CoreAudioDevice cad = new CoreAudioController().DefaultPlaybackDevice;
            Console.WriteLine("Poziom głośności " + cad.Volume);

            cad.Volume = Convert.ToInt32(number);
        }

        private static void Shutdown(int number)
        {
            if (number < 0)
                number = 0;

            ProcessStartInfo psi = new ProcessStartInfo("shutdown", "/s /t " + number);
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
