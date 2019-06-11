using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = String.Concat(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String oldString = "";
            String newString = "";

            String[] args = textBox2.Text.Split(',');
            if(args.Length != 2)
            {
                textBox3.Text = "Во 2-й строке неверно!";
            }
            else
            {
                oldString = args[0];
                newString = args[1];

                textBox3.Text = textBox1.Text.Replace(oldString, newString);
            }
            
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            String deletingString = textBox2.Text;

            textBox3.Text = textBox1.Text.Replace(deletingString, "");
        }

        private void button4_Click(object sender, EventArgs e) 
        {
            try
            {
                int index = Convert.ToInt32(textBox2.Text);

                if (index < 0 && index > 32767)
                    throw new Exception("Проверьте значение индекса");
                else
                    textBox3.Text = textBox1.Text[index-1].ToString();
            }
            catch( Exception exception)
            {
                Console.WriteLine(exception.Message);
                textBox3.Text = "Проверьте значение индекса";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text.Length.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = Mind.CountVowel(textBox1.Text).ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox3.Text = Mind.CountConsonats(textBox1.Text).ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            char[] symbols = {'.', '!', '?'};
            textBox3.Text = textBox1.Text.Split(symbols).Length.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            textBox3.Text = Mind.CountWords(textBox1.Text).ToString();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Process.Start("G:/УЧЁБА/ООП_CS (Forms)/OOP_01/OOP_01/ReadMe.txt");
        }
                     
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
