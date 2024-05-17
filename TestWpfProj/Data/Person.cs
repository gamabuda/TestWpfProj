using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestWpfProj.Data
{
    public class Person
    {
        private string surame;

        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public BitmapImage Photo { get; set; }

        public Person(string surname, string name, string patronymic, string gender, int age, BitmapImage photo)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            Age = age;
            Photo = photo;
        }
    }
}