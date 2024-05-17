using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TestWpfProj.Data
{
    public class Child : Person
    {
        public Child(string surame, string name, string patronymic, string gender, int age, int roomNumber, DateOnly moveInDate, BitmapImage photo) : base(surame, name, patronymic, gender, age, photo)
        {
            RoomNumber = roomNumber;
            MoveInDate = moveInDate;
        }

        public int RoomNumber { get; set; }
        public DateOnly MoveInDate { get; set; }
    }
}