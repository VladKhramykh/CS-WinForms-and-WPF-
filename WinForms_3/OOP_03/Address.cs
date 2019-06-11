using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace OOP_02
{
    [Serializable]    
    public class Address
    {
        
        [DataMember]
        [XmlElement]
        [Required(ErrorMessage = "Укажите страну")]
        string country;
        [DataMember]
        [Required(ErrorMessage = "Укажите город")]
        string city;
        [DataMember]
        [Required(ErrorMessage = "Укажите район")]
        string area;
        [DataMember]
        [Required(ErrorMessage = "Укажите улицу")]
        string street;
        [DataMember]
        [Required(ErrorMessage = "Укажите номер дома")]
        string house;
        [DataMember]
        [Required(ErrorMessage = "Укажите номер квартиры")]
        string apartmentNumber;
                
        static List<Address> addresses = new List<Address>();

        [XmlElement]
        [DataMember]
        Apartment apartment;

        public static Address getAddress(string address)
        {
            foreach(Address a in addresses)
            {
                
                if (address == a.ToString())
                    return a;
            }
            return null;
        }
        public Address(string country, string city, string area, string street, string house, string apartmentNumber)
        {
            this.country = country ?? throw new ArgumentNullException(nameof(country));
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.area = area ?? throw new ArgumentNullException(nameof(area));
            this.street = street ?? throw new ArgumentNullException(nameof(street)); 
            this.house = house ?? throw new ArgumentNullException(nameof(house));
            this.apartmentNumber = apartmentNumber ?? throw new ArgumentNullException(nameof(apartmentNumber));
        }

        public Address()
        {

        }

        public Apartment getApartment() => apartment;

        public string getCountry() => country;

        public static List<Address> getAddressesByCountOfRooms(int numberOfRooms)
        {
            List<Address> result = new List<Address>();           
         
            foreach (Address address in addresses)
            {
                if (address.apartment.countOfRoom == numberOfRooms)
                    result.Add(address);
            }
            return result;
        }


        public static List<Address> getAddressesByHouse(string regex)
        {
            List<Address> result = new List<Address>();
            foreach (Address address in addresses)
            {
                if (Regex.IsMatch(address.house, regex, RegexOptions.IgnoreCase))
                    result.Add(address);
            }
            return result;
        }


        public static List<Address> getAddressesByArea(string regex)
        {
            List<Address> result = new List<Address>();
            foreach (Address address in addresses)
            {
                if (Regex.IsMatch(address.area, regex, RegexOptions.IgnoreCase))
                    result.Add(address);
            }
            return result;
        }



        public static List<Address> getAddressesByCity(string regex)
        {
            List<Address> result = new List<Address>();
            foreach (Address address in addresses)
            {
                if (Regex.IsMatch(address.city, regex, RegexOptions.IgnoreCase))
                    result.Add(address);
            }
            return result;
        }



        public static List<Address> getAddressesByCountry(string regex)
        {
            List<Address> result = new List<Address>();
            foreach(Address address in addresses)
            {
                if (Regex.IsMatch(address.country, regex, RegexOptions.IgnoreCase))
                    result.Add(address);
            }
            return result;
        }

        public bool isFull()
        {
            if (apartment != null)
                return true;
            else
                return false;
        }

        public static void addAddress(Address address)
        {
            if(!isAddress(address))
                addresses.Add(address);
        }

        public void addApartment(double footage, int countOfRoom, Options.Kitchen kitchen, Options.Toilet toilet, Options.Bath bath, Options.Balcon balcony, List<Options.Room> rooms)
        {
            apartment = new Apartment(footage, countOfRoom, kitchen, toilet, bath, balcony, rooms);
        }

        public static List<Address> getAddresses()
        {
            return addresses;
        }

        public static bool isAddress(Address address)
        {
            foreach(Address a in getAddresses())
            {
                if (address.ToString() == a.ToString())
                    return true;
            }
            return false;
        }

        public static Address getAddress(int count) => addresses[count];

        public static int indexOf(string address)
        {
            int i = 0;
            foreach(Address a in addresses)
            {
                if (a.ToString() == address.ToString())
                    return i;
                i++;
            }
            return -1;
        }

        public static int getCount() => addresses.Count;

        public override string ToString()
        {
            return $"{country}, {city}, {area} район, ул.{street}, дом {house}, кв. {apartmentNumber}";
        }
    }
}
    