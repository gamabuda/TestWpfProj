using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestWpfProj.Data
{
    public class Child
    {
        public Child(string surname, string name, string patronymic, string gender, int age, int roomNumber, DateOnly moveInDate, BitmapImage photo)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            Age = age;
            Photo = photo;
            RoomNumber = roomNumber;
            MoveInDate = moveInDate;
        }

        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public BitmapImage Photo { get; set; }
        public int RoomNumber { get; set; }
        public DateOnly MoveInDate { get; set; }
    }
}