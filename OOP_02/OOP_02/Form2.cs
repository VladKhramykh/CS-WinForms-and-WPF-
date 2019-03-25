using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_02
{
    public partial class adressForm : Form
    {
        public adressForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void addAdressButton(object sender, EventArgs e)
        {
            string country = textCountry.Text;
            string city = textCity.Text;
            string area = textArea.Text;
            string street = textStreet.Text;
            string house = textHouse.Text;
            string appartNumber = textAppartNumber.Text;
            Adress tmp = new Adress(country, city, area, street, house, appartNumber);

            if (!Adress.isAdress(tmp))
            {
                if (textCity.Text == "" || textCountry.Text == "" || textHouse.Text == "" || textStreet.Text == "" || textAppartNumber.Text == "" || textArea.Text == "")
                    MessageBox.Show("Не все параметры указаны!");
                else
                {
                    showNotReadyAdresses.Items.Add(tmp.ToString());
                    Adress.addAdress(tmp);
                }
            }
            else
            {
                MessageBox.Show("Такой адрес уже существует!");
            }
                
        }

        private void nextForm(object sender, EventArgs e)
        {
            appartForm appartForm = new appartForm();
            appartForm.Show();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            JSONController.DeserializedJsonFormat("Adresses.json");

            showReadyAdresses.Items.Clear();
            showNotReadyAdresses.Items.Clear();
            foreach (Adress adress in Adress.getAdresses())
            {
                if (adress.isFull())
                    showReadyAdresses.Items.Add(adress.ToString());
                else
                    showNotReadyAdresses.Items.Add(adress.ToString());
            }
        }

        private void showReadyAdresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInfo.Items.Clear();
            Adress tmp = Adress.getAdresses()[showReadyAdresses.SelectedIndex];

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
