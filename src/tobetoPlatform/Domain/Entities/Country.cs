using Core.Persistence.Repositories;
using System;
namespace Domain.Entities
{
    public class Country:Entity<int>  //güncellendi
    {
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(int id,string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}

