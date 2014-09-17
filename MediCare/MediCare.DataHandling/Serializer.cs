﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/**
 * @Author: Frank
 * @version: 1.0
 * This class Serializes objects. U can sthrow in everything you want. It does currently not check if the file exists already.
 * That may be a future feature.
 * 
 * Tested fully operational.
 *
 */

namespace MediCare.DataHandling
{
    public class Serializer
    {
        public Serializer()
        {
        }

        public void SerializeObject(string filename, ArrayList objectToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public ArrayList DeSerializeObject(string filename)
        {
            ArrayList objectToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (ArrayList)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }
    }
}
