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

namespace WpfApp10
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
            TV tv = new TV();
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVonCommand(tv));
            mPult.SetCommand(1, new VolumeCommand(volume));

            mPult.PressButton(0);
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);

            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Hero hero = new Hero();
            hero.Shoot();
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState());

            hero.Shoot();
            hero.Shoot();
            hero.Shoot();
            hero.RestoreState(game.History.Pop());
            hero.Shoot();
        }
    }
}
