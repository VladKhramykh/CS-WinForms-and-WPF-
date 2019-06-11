using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp10
{
    class State
    {

    }

    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }

        public void Heat()
        {
            State.Heat(this);
        }

        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState: IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("make water from ice");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            MessageBox.Show("continue freeze...");
        }
    }

    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("make gas from water");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            MessageBox.Show("make ice from water");
            water.State = new SolidWaterState();
        }
    }

    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            MessageBox.Show("Upper temperature of gas");
        }

        public void Frost(Water water)
        {
            MessageBox.Show("make water from gas");
            water.State = new LiquidWaterState();
        }
    }
}
