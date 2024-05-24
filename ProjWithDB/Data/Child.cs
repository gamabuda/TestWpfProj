using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProjWithDB.Data
{
    public class Child
    {
        public Child(string surname, string name, string patronymic, string gender, int age, int roomNumber, DateOnly moveInDate, string photo)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Gender = gender;
            Age = age;
            PhotoLink = photo;
            RoomNumber = roomNumber;
            MoveInDate = moveInDate;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PhotoLink { get; set; }
        public int RoomNumber { get; set; }
        public DateOnly MoveInDate { get; set; }
    }
}