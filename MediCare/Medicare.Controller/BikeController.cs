﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Controller
{
    public class BikeController
    {
        private ComController cc;
        public BikeController(string comPort)
        {
            if (comPort.Contains("COM"))
            {
                cc = new ComController(comPort);
                cc.openConnection();
                //Console.WriteLine(Enums.GetValue(Enums.BikeCommands.CONTROLMODE));
            }
            else
            {
                //TODO change content of ComController to SerialController EXTENDS ComController. and add BikeSimulator EXTENDS ComController class.
                // cc gets type ComController and gets object of either SerialController or BikeSimulator.. Bikesimulator will be made in a way that it responds accordingly to cc.send() methods etc..
            }

        }

        #region getters

        public string[] GetStatus()
        {
            cc.send(Enums.GetValue(Enums.BikeCommands.STATUS)); 
            string raw = cc.read();
            string[] rawArray = raw.Split();
            rawArray[3] = (float.Parse(rawArray[3]) / 10).ToString();
            rawArray[4] = (float.Parse(rawArray[4])).ToString();
            return rawArray;
        }

        #endregion

        #region setters

        public void ResetBike() 
        {
            cc.send(Enums.GetValue(Enums.BikeCommands.CONTROLMODE));
            cc.send(Enums.GetValue(Enums.BikeCommands.RESET));
            cc.read();
        }

        public string[] SetPower(int power)
        {
            cc.send(Enums.GetValue(Enums.BikeCommands.CONTROLMODE));
            cc.send(Enums.GetValue(Enums.BikeCommands.POWER) + " " + power.ToString());
            string raw = cc.read();
            string[] rawArray = raw.Split();
            rawArray[3] = (float.Parse(rawArray[3]) / 10).ToString();
            rawArray[4] = (float.Parse(rawArray[4])).ToString();
            return rawArray;
        }

        #endregion
    }
}
