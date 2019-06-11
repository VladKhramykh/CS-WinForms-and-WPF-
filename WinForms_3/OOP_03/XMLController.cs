using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_02
{
    class XMLController
    {
        

        public static void XmlSerrializer(object addresses,string path)
        {
            List<Address> tmp = (List<Address>) addresses;
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(String));

            using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach(Address address in tmp)
                {
                    XmlSerializer.Serialize(fs, address.ToString());
                }
                
            }
        }
    }
}
