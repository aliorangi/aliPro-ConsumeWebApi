using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleAppConsumingWebApi
{
    class Serializer
    {
        public Serializer()
        {
        }

        //public void SerializeObject(string filename, Program objectToSerialize)
        //{
        //    Stream stream = File.Open(filename, FileMode.Create);
        //    BinaryFormatter bFormatter = new BinaryFormatter();
        //    bFormatter.Serialize(stream, objectToSerialize);
        //    stream.Close();
        //}


    }
}
