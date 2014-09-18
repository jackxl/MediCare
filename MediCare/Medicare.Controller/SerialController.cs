﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace MediCare.Controller
{
    class SerialController : ComController
    {
        private SerialPort _comPort;

        public SerialController(string port)
        {
            _comPort = new SerialPort(port, 9600);
        }
        public SerialController()
        {
            Console.WriteLine("Available Connected Com Ports:");
            string[] portArray = getAvailablePorts();
            foreach (string s in portArray)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Please type the port you want to use");
            string port = Console.ReadLine();
            _comPort = new SerialPort(port, 9600);
        }

        /**
         * Remove Try Catch Clausule When switching to auto detection Mode for COM port detection (located in BikeController)
         */ 
        override public void openConnection()
        {
            try
            {
                _comPort.Open();
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Could not open selected port, please try again",
                                "Critical Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1);
               closeConnection();
            }
        }

        override public void closeConnection()
        {
            _comPort.Close();
        }

        override public void send(string command)
        {
            _comPort.WriteLine(command);
        }

        override public string[] getAvailablePorts()
        {
            string[] temp = SerialPort.GetPortNames();
            List<string> tempList = temp.ToList();
            tempList.Add("SIM");
            return tempList.ToArray<string>();
        }

        override public string read()
        {
            return _comPort.ReadLine();
        }

        override public string getPort()
        {
            return _comPort.PortName;
        }

        /*public bool isOpen()
        {
            return _comPort.IsOpen();
        }*/
    }
}
