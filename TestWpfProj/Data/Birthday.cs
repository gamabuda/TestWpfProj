using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Birthday
    {
        public string BirthdayString 
        { 
            get
            {
                return _birthdayString;
            }
            set
            {
                _birthdayString = value;
                int[] date = new int[3];
                for (int i = 0; i < date.Length; i++)
                {
                    date[i] = Convert.ToInt32(value.Split(".")[i]);
                }
                _birthdayDateTime = new DateTime(date[2], date[1], date[0]);
            }
        }
        public DateTime BirthDayDateTime
        {
            get
            {
                return _birthdayDateTime;
            }
            set
            {
                _birthdayDateTime = value;
                _birthdayString = (value.Day.ToString().Length == 1 ? $"0{value.Day}" : $"{value.Day}") + (value.Month.ToString().Length == 1 ? $".0{value.Month}" : $".{value.Month}") + $".{value.Year}";
            }
        }
        private string _birthdayString;
        private DateTime _birthdayDateTime;
        public Birthday(DateTime dateTime)
        {
            BirthDayDateTime = dateTime;
        }

        public Birthday(string dateTime)
        {
            BirthdayString = dateTime;
        }

        public void AddDay()
        {
            BirthDayDateTime = BirthDayDateTime.AddDays(1);
        }

        public void RemoveDay()
        {
            BirthDayDateTime = BirthDayDateTime.AddDays(-1);
        }
    }
}
