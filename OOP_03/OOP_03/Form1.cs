using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OOP_02
{
    public partial class appartForm : Form
    {
        public appartForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            foreach( Address adress in Address.getAddresses())
            {
                choiceAdress.Items.Add(adress.ToString());
            }

            choiceBox.Items.Add("Душ");
            choiceBox.Items.Add("Ванна");
            choiceBox.Items.Add("Джакузи");
            choiceBox.Items.Add("Ничего");
        }

        private void payment(object sender, EventArgs e)
        {
            if (choiceAdress.SelectedItem != null)
            {
                
                showBox.Items.Clear();
                showCost.Clear();
                Options.Bath bath;
                Options.Balcon balcon;
                Options.Toilet toilet;
                Options.Kitchen kitchen;
                List<Options.Room> rooms = new List<Options.Room>();

                string choiceOptionInBath = choiceBox.Text;
                try
                {
                    int number;
                    double footAgeBath = Double.Parse(footAgeOfBathBox.Text);
                    double footAgeToilet = Double.Parse(footAgeOfToiletBox.Text);
                    double footAgeBalcon = Double.Parse(footAgeOfBalconBox.Text);
                    double footAgeKitchen = Double.Parse(footAgeOfKitchenBox.Text);
                    double sumFootage;

                    bool balconClosed = checkBoxClosedBalcon.Checked;
                    bool stove = checkBoxStave.Checked;
                    bool fridge = checkBoxFridge.Checked;
                    bool basement = checkBoxBasement.Checked;

                    if (radioButton5.Checked)
                        number = Int32.Parse(radioButton5.Text);
                    else if (radioButton4.Checked)
                        number = Int32.Parse(radioButton4.Text);
                    else if (radioButton3.Checked)
                        number = Int32.Parse(radioButton3.Text);
                    else if (radioButton2.Checked)
                        number = Int32.Parse(radioButton2.Text);
                    else
                        number = Int32.Parse(radioButton1.Text);

                    for(int i = 0; i<number;i++)
                        rooms.Add(new Options.Room(3, "South", 12));


                    sumFootage = footAgeBalcon + footAgeBath + footAgeKitchen + footAgeToilet + (number * 34);
                    bath = new Options.Bath(footAgeBath, choiceOptionInBath);
                    balcon = new Options.Balcon(balconClosed, footAgeBalcon);
                    toilet = new Options.Toilet(footAgeToilet);
                    kitchen = new Options.Kitchen(footAgeKitchen, fridge, stove);

                    Apartment apartment = new Apartment(sumFootage, number, kitchen, toilet, bath, balcon, rooms);

                    int choice = Address.indexOf(choiceAdress.Text);
                    if (choice != -1)
                    {
                        Address.getAddress(choice).addApartment(sumFootage, number, kitchen, toilet, bath, balcon, rooms);
                        JSONController.SaveJsonFormat(Address.getAddresses(), "Adresses.json");
                    }
                    else
                        MessageBox.Show("Выберите адрес из предложенных!");

                    double resultCost = sumFootage * 1187 + (fridge ? 500 : 0) + (stove ? 500 : 0) + (basement ? 645 : 0) + (balconClosed ? 320 : 0) + (choiceOptionInBath != "Ничего" ? 500 : 0);

                    showBox.Items.Add(Address.getAddress(choice));
                    showBox.Items.Add($"Метраж ванной: {footAgeBath} м^2");
                    showBox.Items.Add($"Удобства в ванной: {choiceOptionInBath}");
                    showBox.Items.Add($"Метраж туалета: {footAgeToilet} м^2");
                    showBox.Items.Add($"Метраж кухни: {footAgeKitchen} м^2");
                    showBox.Items.Add("Холодильник: " + (fridge ? "Да" : "Нет"));
                    showBox.Items.Add("Газовая плита: " + (stove ? "Да" : "Нет"));
                    showBox.Items.Add($"Метраж балкона: {footAgeBalcon} м^2");
                    showBox.Items.Add("Балкон закрыт: " + (balconClosed ? "Да" : "Нет"));
                    showBox.Items.Add("Подвал: " + (basement ? "Да" : "Нет"));
                    showBox.Items.Add("Количество комнат: " + number);

                    showCost.Text = $"{resultCost} $";
                }
                catch
                {
                    showBox.Items.Clear();
                    MessageBox.Show("Ошибка при вводе данных!");
                }
            }
            else
                MessageBox.Show("Выберите адрес!");

        }

      
    }
}
