using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_02
{
    [Serializable]
    class Adress
    {
        [DataMember]
        string country;
        [DataMember]
        string city;
        [DataMember]
        string area;
        [DataMember]
        string street;
        [DataMember]
        string house;
        [DataMember]
        string apartmentNumber;

        static List<Adress> adresses = new List<Adress>();

        [DataMember]
        Apartment apartment;


        public Adress(string country, string city, string area, string street, string house, string apartmentNumber)
        {
            this.country = country ?? throw new ArgumentNullException(nameof(country));
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.area = area ?? throw new ArgumentNullException(nameof(area));
            this.street = street ?? throw new ArgumentNullException(nameof(street)); 
            this.house = house ?? throw new ArgumentNullException(nameof(house));
            this.apartmentNumber = apartmentNumber ?? throw new ArgumentNullException(nameof(apartmentNumber));
        }

        public Apartment getApartment() => apartment;

        public bool isFull()
        {
            if (apartment != null)
                return true;
            else
                return false;
        }

        public static void addAdress(Adress adress)
        {
            if(!isAdress(adress))
                adresses.Add(adress);
        }

        public void addApartment(double footage, int countOfRoom, Options.Kitchen kitchen, Options.Toilet toilet, Options.Bath bath, Options.Balcon balcony, List<Options.Room> rooms)
        {
            apartment = new Apartment(footage, countOfRoom, kitchen, toilet, bath, balcony, rooms);
        }

        public static List<Adress> getAdresses()
        {
            return adresses;
        }

        public static bool isAdress(Adress adress)
        {
            foreach(Adress a in getAdresses())
            {
                if (adress.ToString() == a.ToString())
                    return true;
            }
            return false;
        }

        public static Adress getAdress(int count) => adresses[count];

        public static int indexOf(string adress)
        {
            int i = 0;
            foreach(Adress a in adresses)
            {
                if (a.ToString() == adress.ToString())
                    return i;
                i++;
            }
            return -1;
        }

        public override string ToString()
        {
            return $"{country}, {city}, {area} район, ул.{street}, дом {house} {apartmentNumber}";
        }
    }
}
