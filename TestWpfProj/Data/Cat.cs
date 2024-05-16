using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfProj.Data
{
    public class Cat
    {
        public Cat(string name, CatType type, DateTime birthday, string gender)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            CatType = type;
            Birthday = new Birthday(birthday);
            Gender = gender;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public CatType? CatType { get; set; }
        public string Gender { get; set; }
        public Birthday Birthday { get; set; }
    }
}
