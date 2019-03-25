using System;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace OOP_02
{
    public static class JSONController
    {
        public static void SaveJsonFormat(object obj, string fileName)
        {
            DeserializedJsonFormat(fileName);
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(obj.GetType());
           
            using (FileStream fs = new FileStream(fileName, FileMode.Truncate))
            {
                jsonFormatter.WriteObject(fs, obj);
            }
        }
        public static void DeserializedJsonFormat(string fileName)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Address>));
            List<Address> adresses;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                 adresses = (List<Address>)jsonFormatter.ReadObject(fs);
            }

            foreach (Address adress in adresses)
                Address.addAddress(adress);
        }
    }
}
