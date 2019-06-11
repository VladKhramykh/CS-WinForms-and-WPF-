using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp9
{
    class Composite
    {
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }
        public virtual void Remove(Component component) { }
        public virtual void Print()
        {
            MessageBox.Show(name);
        }
    }

    class Directory: Component
    {
        private List<Component> components = new List<Component>();

        public Directory(string name) : base(name)
        {

        }

        public override void Add(Component component)
        {
            components.Add(component);
        }

        public override void Remove(Component component)
        {
            components.Remove(component);
        }

        //string str;
        public override void Print()
        {
            MessageBox.Show($"узел {name}");
            MessageBox.Show("подузлы: ");
            for(var i = 0;i < components.Count; i++)
            {
                components[i].Print();
            }
            //MessageBox.Show($"подузлы:\t{str}");
        }
    }

    class File : Component
    {
        public File(string name):base(name)
        {

        }
    }

}
