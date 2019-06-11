using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Driver driver = new Driver();

            Auto auto = new Auto();
            driver.Travel(auto);

            Horse horse = new Horse();
            ITransoprt transoprt = new HorseToTransoprtAdapter(horse);
            driver.Travel(transoprt);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new PizzaWithTomato(pizza1);
            MessageBox.Show($"Name: {pizza1.Name}, cost: {pizza1.GetCost()}");

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new PizzaWithCheese(pizza2);
            MessageBox.Show($"Name: {pizza2.Name}, cost: {pizza2.GetCost()}");

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new PizzaWithTomato(pizza3);
            pizza3 = new PizzaWithCheese(pizza3);
            MessageBox.Show($"Name: {pizza3.Name}, cost: {pizza3.GetCost()}");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Component fileSystem = new Directory("file system");

            Component diskC = new Directory("Files");
            Component file1 = new File("txt.txt");
            Component file2 = new File("song.mp3");

            diskC.Add(file1);
            diskC.Add(file2);

            fileSystem.Add(diskC);
            //fileSystem.Print();

            diskC.Remove(file2);

            Component docsFolder = new Directory("Documents");
            Component file3 = new File("vvv.txt");
            Component file4 = new File("ggg.txt");
            docsFolder.Add(file3);
            docsFolder.Add(file4);
            diskC.Add(docsFolder);
            diskC.Remove(docsFolder);

            fileSystem.Print();
        }
    }
}
