using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp9
{
    class Adapter
    {

    }

    interface ITransoprt
    {
        void Drive();
    }

    class Auto : ITransoprt
    {
        public void Drive()
        {
            MessageBox.Show("Car drive on road");
        }
    }

    class Driver
    {
        public void Travel(ITransoprt transoprt)
        {
            transoprt.Drive();
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Horse : IAnimal
    {
        public void Move()
        {
            MessageBox.Show("Horse go on field");
        }
    }

    class HorseToTransoprtAdapter: ITransoprt
    {
        Horse horse;
        public HorseToTransoprtAdapter(Horse s)
        {
            horse = s;
        }

        public void Drive()
        {
            horse.Move();
        }
    }


}
