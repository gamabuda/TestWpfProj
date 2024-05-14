using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public static class DataContext
    {
        public static List<string> Genders = new List<string>() { "М", "Ж" };

        public static List<Child> Children = new List<Child>()
        {
            new Child("Василенко", "Ирина", "Павловна", "Ж", 3, 101, new DateOnly(2024, 2, 10)),
            new Child("Василенко", "Денис", "Павлович", "М", 7, 201, new DateOnly(2020, 1, 22)),
            new Child("Петров", "Игорь", "Дмитриевич", "М", 10, 201, new DateOnly(2019, 9, 9)),
            new Child("Смольников", "Матвей", "Радикович", "М", 2, 205, new DateOnly(2022, 12, 12)),
            new Child("Яруллин", "Талгат", "Рамилевич", "М", 9, 201, new DateOnly(2017, 4, 14)),
            new Child("Ярмоленко", "Светлана", "Павловна", "Ж", 13, 110, new DateOnly(2015, 10, 30)),
            new Child("Терешкова", "Ирина", "Петровна", "Ж", 17, 115, new DateOnly(2015, 7, 27)),
            new Child("Терешков", "Иван", "Александрович", "М", 15, 209, new DateOnly(2024, 5, 1)),
            new Child("Авоська", "Борис", "Александрович", "М", 4, 204, new DateOnly(2021, 8, 18)),
            new Child("Митин", "Волын", "Волынович", "М", 6, 204, new DateOnly(2018, 6, 21)),
            new Child("Датченко", "Олеся", "Игоревна", "Ж", 12, 103, new DateOnly(2014, 7, 10)),
            new Child("Здоровяк", "Марина", "Талгатовна", "Ж", 14, 103, new DateOnly(2023, 11, 29)),
            new Child("Ромашко", "Незабудка", "Розовна", "Ж", 11, 103, new DateOnly(2016, 1, 31)),
        };
    }
}