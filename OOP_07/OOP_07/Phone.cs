using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_07
{
    public class Phone: DependencyObject
    {

        public static readonly DependencyProperty TitleProperty; 
        public static readonly DependencyProperty PriceProperty; 

        static Phone()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Phone));

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Phone), metadata, new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject dependencyObject, object value)
        {
            int currentValue = (int)value;

            if (currentValue > 100000)
                return 100000;
            else
                return currentValue;
        }

        public static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0)
                return true;
            return false;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }
    }
}
