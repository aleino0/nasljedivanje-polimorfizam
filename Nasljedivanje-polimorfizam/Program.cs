using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nasljedivanje_polimorfizam
{
    class Dessert
    {
        private string name;
        private double weight;
        private int calories;

        public Dessert() { }

        public Dessert(string name, double weight, int calories)
        {
            this.name = name;
            this.weight = weight;
            this.calories = calories;
        }

        public string Name { get => name; set => name = value; }
        public double Weight { get => weight; set => weight = value; }
        public int Calories { get => calories; set => calories = value; }

        public string toString()
        {
            return name + weight + calories;
        }

        public string getDessertType()
        {
            return "dessert";
        }
    }

    class Cake : Dessert
    {
        bool containsGlooten;
        string cakeType;

        public Cake(string name, double weight, int calories, bool v1, string v2) : base(name, weight, calories)
        {
        }

        public bool ContainsGlooten { get => containsGlooten; set => containsGlooten = value; }
        public string CakeType { get => cakeType; set => cakeType = value; }

        public string toString()
        {
            return Name + Weight + Calories + containsGlooten + cakeType;
        }

        public string getDessertType()
        {
            return cakeType + "cake";
        }
    }

    class Sladoled : Dessert
    {
        string flavour;
        string color;

        public string Flavour { get => flavour; set => flavour = value; }
        public string Color { get => color; set => color = value; }

        public string getDessertType()
        {
            return "ice cream";
        }
    }

    class Person
    {
        string name;
        string surname;
        int age;

        public Person() { }

        public Person(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }

        public override bool Equals(object obj)
        {
            if (obj is Student person &&
                   name == person.name &&
                   surname == person.surname &&
                   age == person.age)
            {
                
                if (Student.ReferenceEquals(obj, person))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            
        }

        public string toString()
        {
            return name + surname + age;
        }
    }

    class Student : Person
    {
        string studentId;
        short academicYear;

        public Student(string studentId, short academicYear)
        {
            this.StudentId = studentId;
            this.AcademicYear = academicYear;
        }

        public Student(string name, string surname, int age, string studentId, short academicYear) : base(name, surname, age)
        {
        }

        public string StudentId { get => studentId; set => studentId = value; }
        public short AcademicYear { get => academicYear; set => academicYear = value; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   base.Equals(obj) &&
                   studentId == student.studentId;
        }

        public string toString()
        {
            return studentId + academicYear;
        }
    }

    class Teacher : Person
    {
        string email;
        string subject;
        double salary;
        

        public Teacher(string email, string subject, double salary)
        {
            this.Email = email;
            this.Subject = subject;
            this.Salary = salary;
        }

        public Teacher(string name, string surname, int age, string email, string subject, double salary) : this(email, subject, salary)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public string Email { get => email; set => email = value; }
        public string Subject { get => subject; set => subject = value; }
        public double Salary { get => salary; set => salary = value; }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   base.Equals(obj) &&
                   email == teacher.email;
        }
        public string toString()
        {
            return email + subject + salary;
        }

        public double increaseSalary(int posto)
        {
            salary += salary * posto;
            return salary;
        }

        static double increaseSalary(int posto, Teacher teacher)
        {
            teacher.salary += teacher.salary * posto;
            return teacher.salary;
        }
    }

    class CompetitionEntry
    {
        Teacher ucitelj;
        Dessert desert;
        Student[] ziri = new Student[3];
        int[] ocjene = new int[3];

        public int[] Ocjene { get => ocjene; }
        internal Teacher Ucitelj { get => ucitelj; set => ucitelj = value; }
        internal Dessert Desert { get => desert; set => desert = value; }
        internal Student[] Ziri { get => ziri; }

        public CompetitionEntry(Teacher ucitelj, Dessert desert)
        {
            this.Ucitelj = ucitelj;
            this.Desert = desert;
        }

        public bool addRating(Student student, int grade)
        {
            int brojOcj = 0;
            if (brojOcj == 3)
            {
                return false;
            }

            ziri[brojOcj] = student;
            ocjene[brojOcj] = grade;
            brojOcj++;
            return true;
        }
    }

    class Program
    {
        static void Main(string[] args, Teacher teacher)
        {
            Person[] skola = new Person[5];

            skola[0] = new Teacher("Marko", "Marček", 50, "markoMarcek@gmail.com", "HR", 1500.15);
            skola[1] = new Teacher("Pero", "Perić", 32, "peroPeric@gmail.com", "MAT", 1100.49);
            skola[2] = new Teacher("Jelena", "Jelić", 47, "jelenaJelic@gmail.com", "TZK", 1500);

            skola[3] = new Student("Božo", "Božič", 24, "1111111111", (short)1);
            skola[4] = new Student("Grga", "Grgić", 19, "0002251893", (short)4);

            double punaPlaca = 0;

            for (int i=0; i<5; i++)
            {
                Console.Write(skola[i].Name + " ");
                Console.WriteLine(skola[i].Surname);
            }

            Console.WriteLine("\n");


            Person p1 = new Person("Ivo", "Ivic", 20);
            Person p2 = new Person("Ivo", "Ivic", 20);
            Person p3 = new Student("Ivo", "Ivic", 20, "0036312123", (short)3);
            Person p4 = new Student("Marko", "Marić", 25, "0036312123", (short)5);

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));
            Console.WriteLine(p3.Equals(p4));

            

            Console.ReadKey();
        }
    }
}
