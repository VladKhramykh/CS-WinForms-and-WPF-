using System.Text;
using System.Windows;

namespace WpfApp8
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

        //abstract factory
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();
        }

        //singleton
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Computer pc = new Computer();
            pc.Launch("PC 2");
            MessageBox.Show(pc.Singleton.Name); 

            pc.Singleton = Singleton.getInstance("PC 1");
            MessageBox.Show(pc.Singleton.Name);
        }
        
        //builder+director
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            MessageBox.Show(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            MessageBox.Show(wheatBread.ToString());
        }

        //prototype
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }
    //оружие  определяют интерфейс для классов, объекты которых будут создаваться в программе.
    internal abstract class Weapon
    {
        public abstract void Hit();
    }

    // абстрактный класс движение
    abstract class Movement
    {
        public abstract void Move();
    }

    // класс арбалет
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            MessageBox.Show("Стреляем из арбалета");
        }
    }

    // класс меч. представляют конкретную реализацию абстрактных классов
    class Sword : Weapon
    {
        public override void Hit()
        {
            MessageBox.Show("Бьем мечом");
        }
    }
    // движение полета
    class FlyMovement : Movement
    {
        public override void Move()
        {
            MessageBox.Show("Летим");
        }
    }

    // движение - бег
    class RunMovement : Movement
    {
        public override void Move()
        {
            MessageBox.Show("Бежим");
        }
    }
    // класс абстрактной фабрики определяет методы для создания объектов. Причем методы возвращают абстрактные продукты, а не их конкретные реализации.
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }

    // Фабрика создания летящего героя с арбалетом. реализуют абстрактные методы базового класса и непосредственно определяют какие конкретные продукты использовать
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }

    // Фабрика создания бегущего героя с мечом
    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }

    // клиент - сам супергерой  использует класс фабрики для создания объектов. При этом он использует исключительно абстрактный класс фабрики
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
    }
    //Таким образом, создание супергероя абстрагируется от самого класса супергероя

    //--------------------------------------------------------------------------------
    class Singleton
    {
        private static Singleton instance;

        public string Name { get; private set;}

        protected Singleton(string name)
        {
            this.Name = name;
        }

        public static Singleton getInstance(string name)
        {
            if (instance == null)
                instance = new Singleton(name);
            return instance;
        }
    }

    class Computer
    {
        public Singleton Singleton { get; set; }
        public void Launch(string Name)
        {
            Singleton = Singleton.getInstance(Name);
        }
    }
    //------------------------------------------------------------------------------------

    //используется в качестве прототипа 
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone()
        {
            //return new Rectangle(this.width, this.height);
            return this.MemberwiseClone() as IFigure;
        }
        public void GetInfo()
        {
            MessageBox.Show($"Прямоугольник длиной {height} и шириной {width}");
        }
    }

    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone()
        {
            return this.MemberwiseClone() as IFigure;
            //return new Circle(this.radius);
        }
        public void GetInfo()
        {
            MessageBox.Show($"Круг радиусом {radius}");
        }
    }
    //----------------------------------------------------------------------------------------


    //мука
    class Flour
    {
        // какого сорта мука
        public string Sort { get; set; }
    }
    // соль
    class Salt
    { }
    // пищевые добавки
    class Additives
    {
        public string Name { get; set; }
    }

    class Bread
    {
        // мука
        public Flour Flour { get; set; }
        // соль
        public Salt Salt { get; set; }
        // пищевые добавки
        public Additives Additives { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }

    // абстрактный класс строителя
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }

    // пекарь
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }

    // строитель для ржаного хлеба
    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            // не используется
        }
    }

    // строитель для пшеничного хлеба
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }

        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }

        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "улучшитель хлеба" };
        }
    }

}
