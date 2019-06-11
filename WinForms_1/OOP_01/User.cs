using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_01
{
    class User
    {
        string name;
        int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string getName() => name;
        public int getAge() => age;

        public override string ToString()
        {
            return $"{name} {age} лет\n";
        }

        public readonly static string[] names = { "Денис", "Влад", "Катя", "Диана", "Никита", "Павел", "Виталий", "Александр", "Алина", "Вероника", "Татьяна", "Роман", "Ксения" };

        public static void lowerSort(List<User> users)
        {
            Comparison<User> comparison = new Comparison<User>(CompareDinosByAge);
            users.Sort(comparison);
        }

        private static int CompareDinosByAge(User x, User y)
        {
            if (x.age > y.age)
                return 1;
            if (x.age < y.age)
                return -1;
            else
                return 0;
        }
    }
}
