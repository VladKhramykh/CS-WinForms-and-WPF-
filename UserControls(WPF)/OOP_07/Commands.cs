using System.Windows.Input;

namespace OOP_07
{
    public class Commands
    {
        public static RoutedUICommand Visible { get; set; }

        static Commands()
        {
            Visible = new RoutedUICommand("Visible", "name", typeof(MainWindow));            
        }
    }
}
