using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_02
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            List<Address> addresses = Address.getAddresses();          
        }


        private void showInfoOfAddress(List<Address> addresses)
        {

            foreach (Address address in addresses)
            {
                showResult.Items.Add(address.ToString());
                XMLController.XmlSerrializer(addresses, "SearchResult.xml");
            }
                
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            showResult.Items.Clear();
            string str = findTextBox.Text;
            string pattern;

            if (radioArea.Checked)
            {
                pattern = $@"\w*{str}\w*";
                showInfoOfAddress(Address.getAddressesByArea(pattern));
            }
            else if (radioCity.Checked)
            {
                pattern = $@"\w*{str}\w*";
                showInfoOfAddress(Address.getAddressesByCity(pattern));
            }
            else if (radioCountry.Checked)
            {
                pattern = $@"\w*{str}\w*";
                showInfoOfAddress(Address.getAddressesByCountry(pattern));
            }
            else if (radioNumberOfHouse.Checked)
            {
                pattern = $@"\w*{str}\w*";
                showInfoOfAddress(Address.getAddressesByHouse(pattern));
            }
            else if (radioNumberOfRooms.Checked)
            {
                try
                {
                    int number = Int32.Parse(str);
                    showInfoOfAddress(Address.getAddressesByCountOfRooms(number));

                }
                catch(Exception ex)
                {
                    showResult.Items.Clear();
                    showInfo.Items.Clear();
                    MessageBox.Show("Для поиска поо количеству нужно ввести число!");
                }
            }
            else
                MessageBox.Show("Выерите параметр поиска!");

        }

        private void showResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInfo.Items.Clear();
            Address tmp = Address.getAddress(showResult.SelectedItem.ToString());
            showInfo.Items.Add("Кол-во комнат: " + tmp.getApartment().countOfRoom);
            showInfo.Items.Add($"Метраж ванной: {tmp.getApartment().bath.getFoodAge()} м^2");
            showInfo.Items.Add($"Удобства в ванной: {tmp.getApartment().bath.getConvenience()}");
            showInfo.Items.Add($"Метраж туалета: {tmp.getApartment().toilet.getFootAge()} м^2");
            showInfo.Items.Add($"Метраж кухни: {tmp.getApartment().kitchen.getFootAge()} м^2");
            showInfo.Items.Add("Холодильник: " + (tmp.getApartment().kitchen.getIsFridge() ? "Да" : "Нет"));
            showInfo.Items.Add("Газовая плита: " + (tmp.getApartment().kitchen.getIsStove() ? "Да" : "Нет"));
            showInfo.Items.Add($"Метраж балкона: {tmp.getApartment().balcony.getFootAge()} м^2");
            showInfo.Items.Add("Балкон закрыт: " + (tmp.getApartment().balcony.getIsClosed() ? "Да" : "Нет"));
        }
    }
}
