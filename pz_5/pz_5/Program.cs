using System;

namespace pz_5
{
    class Program
    {
        static void Main(string[] args)
    {
        var Bob = new Student("Bob", 19, ColorHair.Blond);

        Console.WriteLine(Bob.ToString());

        var Lor = Bob;
            Lor.NAME = "Lor";

        Console.WriteLine(Bob.ToString());
        Console.WriteLine(Lor.ToString());

        var Gustav = new Student("Gustav", 21, ColorHair.Split);
        var Johnny = (Student)Gustav.Clone();
            Johnny.NAME = "Max";

        Console.WriteLine(Gustav.ToString());
        Console.WriteLine(Johnny.ToString());
    }
}
    enum ColorHair
    {
        Dark,
        Blond,
        Red,
        Split
    }

    internal class Student : ICloneable, IComparable<Student>
    {

        private string Name;
        private int years;
        private ColorHair col;

        public Student(string name, int yo, ColorHair colorHair)
        {
            Name = name;
            years = yo;
            col = colorHair;
        }

        public string NAME
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public int YearsOld
        {
            get
            {
                return years;
            }
            set
            {
                years = value;
            }
        }

        public ColorHair HairColor
        {
            get
            {
                return col;
            }
            set
            {
                col = value;
            }
        }

        public object Clone()
        {
            return new Student(NAME, YearsOld, HairColor);
        }

        public int CompareTo(Student? other)
        {
            if (other is Student student) return NAME.CompareTo(student.NAME);
            else throw new ArgumentException("некорректное значение"); throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Имя:{Name}, {years} лет, цвет волос: {col}";
        }

    }
}
     internal interface ICloneable
        {
            object Clone();
        }
    internal interface IComparable
    {
        int CompareTo(object? o);
}
