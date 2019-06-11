using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    class Decorator
    {
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() :base("Italian pizza")
        {

        }

        public override int GetCost()
        {
            return 10;
        }
    }

    class BulgerianPizza : Pizza
    {
        public BulgerianPizza(): base("Bulgerian pizza")
        {

        }

        public override int GetCost()
        {
            return 15;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.Pizza = pizza;
        }
    }

    class PizzaWithTomato : PizzaDecorator
    {
        public PizzaWithTomato(Pizza pizza):base(pizza.Name+" with tomatoes", pizza)
        {

        }

        public override int GetCost()
        {
            return Pizza.GetCost() + 2;
        }
    }

    class PizzaWithCheese : PizzaDecorator
    {
        public PizzaWithCheese(Pizza pizza):base(pizza.Name+" with cheese", pizza)
        {

        }

        public override int GetCost()
        {
            return Pizza.GetCost() + 1;
        }
    }
}
