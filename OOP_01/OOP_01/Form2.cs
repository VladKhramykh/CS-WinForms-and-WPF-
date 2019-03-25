using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_01
{
    public partial class Form2 : Form
    {
        List<User> users = new List<User>();
        public Form2()
        {
            InitializeComponent();
        }

        private void generation(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            users.Clear();
            int length = Convert.ToInt32(textBox1.Text);
            Random random = new Random();            
            for (int i = 0; i < length; i++)
            {
                int age = random.Next(1, 120);
                string name = User.names[random.Next(0, 12)];
                User tmp = new User(name, age);
                users.Add(tmp);
                listBox1.Items.Add(tmp.ToString());
            }
        }

        private void upperSort(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            User.lowerSort(users);
            foreach(User user in users)
            {
                listBox2.Items.Add(user.ToString());
            }
        }

        private void lowerSort(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            User.lowerSort(users);           
            for(int i = users.Count; i>0;i--)
            {
                listBox2.Items.Add(users[i-1].ToString());
            }
        }

        private void getMax(object sender, EventArgs e)
        {
            listBox2.Items.Clear();           
            var user = from u in users
                       orderby u.getAge()
                       select u;
            listBox2.Items.Add(user.Last().ToString());
        }

        private void getMin(object sender, EventArgs e)
        {
            listBox2.Items.Clear();            
            var user = from u in users
                       orderby u.getAge()
                       select u;
            listBox2.Items.Add(user.First().ToString());
        }


    }
}
