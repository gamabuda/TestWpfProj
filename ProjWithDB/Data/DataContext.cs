using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ProjWithDB.Data.Users;

namespace ProjWithDB.Data
{
    public static class DataContext
    {
        //public static Guest Guest { get; set; } = new Guest("Guest", "");

        public static List<string> Genders = new List<string>() { "М", "Ж" };

        //public static List<Child> Children = new List<Child>()
        //{
        //    new Child("Василенко", "Ирина", "Павловна", "Ж", 3, 101, new DateOnly(2024, 2, 10), "../img/people/girl.jpg"),
        //    new Child("Василенко", "Денис", "Павлович", "М", 7, 201, new DateOnly(2020, 1, 22), "../img/people/boy.jpg"),
        //    new Child("Петров", "Игорь", "Дмитриевич", "М", 10, 201, new DateOnly(2019, 9, 9), "../img/people/boy.jpg"),
        //    new Child("Смольников", "Матвей", "Радикович", "М", 2, 205, new DateOnly(2022, 12, 12), "../img/people/boy.jpg"),
        //    new Child("Яруллин", "Талгат", "Рамилевич", "М", 9, 201, new DateOnly(2017, 4, 14), "../img/people/boy.jpg"),
        //    new Child("Ярмоленко", "Светлана", "Павловна", "Ж", 13, 110, new DateOnly(2015, 10, 30), "../img/people/girl.jpg"),
        //    new Child("Терешкова", "Ирина", "Петровна", "Ж", 17, 115, new DateOnly(2015, 7, 27), "../img/people/girl.jpg"),
        //    new Child("Терешков", "Иван", "Александрович", "М", 15, 209, new DateOnly(2024, 5, 1), "../img/people/boy.jpg"),
        //    new Child("Авоська", "Борис", "Александрович", "М", 4, 204, new DateOnly(2021, 8, 18), "../img/people/boy.jpg"),
        //    new Child("Митин", "Волын", "Волынович", "М", 6, 204, new DateOnly(2018, 6, 21), "../img/people/boy.jpg"),
        //    new Child("Датченко", "Олеся", "Игоревна", "Ж", 12, 103, new DateOnly(2014, 7, 10), "../img/people/girl.jpg"),
        //    new Child("Здоровяк", "Марина", "Талгатовна", "Ж", 14, 103, new DateOnly(2023, 11, 29), "../img/people/girljpg"),
        //    new Child("Ромашко", "Незабудка", "Розовна", "Ж", 11, 103, new DateOnly(2016, 1, 31), "../img/people/girl.jpg"),
        //};

    }
}