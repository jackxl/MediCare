﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicare.Controller
{
    public class BikeController
    {
        public BikeController(string comPort)
        {
            comPort = "COM5"; //TO DO: remove
            ComController cc = new ComController(comPort);
        }


    }
}
