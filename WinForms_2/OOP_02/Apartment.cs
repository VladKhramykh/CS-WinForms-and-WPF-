using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OOP_02
{
    [DataContract]
    class Apartment
    {
        [DataMember]      
        public readonly double footage;
        [DataMember]
        public readonly int countOfRoom;
        [DataMember]
        public readonly Options.Kitchen kitchen;
        [DataMember]
        public readonly Options.Toilet toilet;
        [DataMember]
        public readonly Options.Bath bath;
        [DataMember]
        public readonly Options.Balcon balcony;
        [DataMember]
        public readonly List<Options.Room> rooms;

        public Apartment(double footage, int countOfRoom, Options.Kitchen kitchen, Options.Toilet toilet, Options.Bath bath, Options.Balcon balcony, List<Options.Room> rooms)
        {
            this.footage = footage;
            this.countOfRoom = countOfRoom;
            this.kitchen = kitchen ?? throw new ArgumentNullException(nameof(kitchen));
            this.toilet = toilet ?? throw new ArgumentNullException(nameof(toilet));
            this.bath = bath ?? throw new ArgumentNullException(nameof(bath));
            this.balcony = balcony ?? throw new ArgumentNullException(nameof(balcony));
            this.rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
        }
    }
}

