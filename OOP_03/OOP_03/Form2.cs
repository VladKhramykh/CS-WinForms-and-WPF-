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
        bool flag = false;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel countAddressesLabel;
        Timer timer;

        public adressForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущее время: ";            
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            countAddressesLabel = new ToolStripLabel();
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add("\t\tКол-во готовых квартир - ");
            countAddressesLabel.Text = $"{Address.getCount()}";
            statusStrip1.Items.Add(countAddressesLabel);

            timer = new Timer { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();            
        }

        private void addAdressButton(object sender, EventArgs e)
        {
            string country = textCountry.Text;
            string city = textCity.Text;
            string area = textArea.Text;
            string street = textStreet.Text;
            string house = textHouse.Text;
            string appartNumber = textAppartNumber.Text;
            Address tmp = new Address(country, city, area, street, house, appartNumber);

            if (!Address.isAddress(tmp))
            {
                if (textCity.Text == "" || textCountry.Text == "" || textHouse.Text == "" || textStreet.Text == "" || textAppartNumber.Text == "" || textArea.Text == "")
                    MessageBox.Show("Не все параметры указаны!");
                else
                {
                    showNotReadyAdresses.Items.Add(tmp.ToString());
                    Address.addAddress(tmp);
                }
            }
            else
            {
                MessageBox.Show("Такой адрес уже существует!");
            }

            countAddressesLabel.Text = $"{Address.getCount()}";
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
            foreach (Address adress in Address.getAddresses())
            {
                if (adress.isFull())
                    showReadyAdresses.Items.Add(adress.ToString());
                else
                    showNotReadyAdresses.Items.Add(adress.ToString());
            }

            countAddressesLabel.Text = $"{Address.getCount()}";
        }

        private void showReadyAdresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInfo.Items.Clear();
            Address tmp = Address.getAddress(showReadyAdresses.SelectedItem.ToString());

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

        private void findButton_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void buttonSortByCountOfRooms_Click(object sender, EventArgs e)
        {
            showReadyAdresses.Items.Clear();
            var sortedList = from address in Address.getAddresses()
                         orderby address.getApartment().countOfRoom
                         select address;

            List<Address> result = new List<Address>();

            if (flag)
            {
                result.Clear();
                foreach (Address a in sortedList)
                {
                    result.Add(a);
                    showReadyAdresses.Items.Add(a.ToString());
                }

                XMLController.XmlSerrializer(result, "SortedAddressesByCount.xml");

                flag = false;
            }
            else
            {
                result.Clear();
                foreach (Address a in sortedList.Reverse())
                {
                    result.Add(a);
                    showReadyAdresses.Items.Add(a.ToString());
                }
                result.Reverse();
                XMLController.XmlSerrializer(result, "SortedAddressesByCount.xml");

                flag = true;
            }


        }

        private void buttonSortByCountry_Click(object sender, EventArgs e)
        {
            showReadyAdresses.Items.Clear();
            var sortedList = from address in Address.getAddresses()
                                       orderby address.getCountry()
                                       select address;

            List<Address> result = new List<Address>();

            if (flag)
            {
                result.Clear();
                foreach (Address a in sortedList)
                {
                    result.Add(a);
                    showReadyAdresses.Items.Add(a.ToString());
                }

                XMLController.XmlSerrializer(result, "SortedAddressesByCountry.xml");

                flag = false;
            }
            else
            {
                result.Clear();
                foreach (Address a in sortedList.Reverse())
                {
                    result.Add(a);
                    showReadyAdresses.Items.Add(a.ToString());                   
                }
                result.Reverse();
                XMLController.XmlSerrializer(result, "SortedAddressesByCountry.xml");

                flag = true;
            }
        }

        private void AboutProgramm_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Храмых Владислав\nВерсия: 1.2");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            textArea.Text = "";
            textCity.Text = "";
            textHouse.Text = "";
            textStreet.Text = "";
            textAppartNumber.Text = "";
            textCountry.Text = "";
        }
    }
}
