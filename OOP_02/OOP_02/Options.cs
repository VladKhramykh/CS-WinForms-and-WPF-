using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_02
{

    
    class Options
    {
        [DataContract]
        public class Bath
        {
            [DataMember]
            double footage;
            [DataMember]
            string convenience;

            public Bath(double footage, string convenience)
            {
                this.footage = footage;
                this.convenience = convenience;
            }


            public double getFoodAge() => footage;
            public string getConvenience() => convenience;

        }

        [DataContract]
        public class Toilet
        {
            [DataMember]
            double footage;

            public Toilet(double footage)
            {
                this.footage = footage;
            }

            public double getFootAge() => footage;

        }

        [DataContract]
        public class Kitchen
        {
            [DataMember]
            double footAge;
            [DataMember]
            bool isFridge = false;
            [DataMember]
            bool isStove = false;

            public Kitchen(double footAge, bool isFridge, bool isStove)
            {
                this.footAge = footAge;
                this.isFridge = isFridge;
                this.isStove = isStove;
            }

            public double getFootAge() => footAge;
            public bool getIsFridge() => isFridge;
            public bool getIsStove() => isStove;

        }

        [DataContract]
        public class Balcon
        {
            [DataMember]
            double footAge;
            [DataMember]
            bool isClosed = false;

            public Balcon(bool isClosed, double footAge)
            {
                this.isClosed = isClosed;
                this.footAge = footAge;
            }

            public double getFootAge() => footAge;
            public bool getIsClosed() => isClosed;
            
        }

        [DataContract]
        public class Room
        {
            [DataMember]
            int amountWindwow;
            [DataMember]
            string sideOfTheWindow;
            [DataMember]
            double footAge;

            public Room(int amountWindwow, string sideOfTheWindow, double footAge)
            {
                this.amountWindwow = amountWindwow;
                this.sideOfTheWindow = sideOfTheWindow ?? throw new ArgumentNullException(nameof(sideOfTheWindow));
                this.footAge = footAge;
            }

            public double getFootAge() => footAge;
            public int getAmountWindow() => amountWindwow;
            public string getIsStove() => sideOfTheWindow;
        }
    }
}
