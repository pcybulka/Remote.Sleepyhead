﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remote.Sleepyhead.Library.Service
{
    public class ManagementSH
    {
        Bluetooth x = new Bluetooth();
        public void Start()
        {
            x.Start();
        }
        public void Stop()
        {
            x.Stop();
        }
        public void Pause()
        {

        }
    }
}
