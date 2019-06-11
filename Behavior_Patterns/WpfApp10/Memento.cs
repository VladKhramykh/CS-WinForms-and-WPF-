using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp10
{
    class Memento
    {
    }

    class Hero
    {
        private int patrons = 10;
        private int lives = 5;

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                MessageBox.Show($"shot!!! count patrons: {patrons}");
            }
            else
                MessageBox.Show("patrons finished");
        }

        //saving state
        public HeroMemento SaveState()
        {
            MessageBox.Show($"save the game, parameters: {patrons} patrons, {lives} lives");
            return new HeroMemento(patrons, lives);
        }

        //restoring state
        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            MessageBox.Show($"restore the game, parameters: {patrons} patrons, {lives} lives");
        }
    }

    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }
}
