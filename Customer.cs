using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Introduction
{
    class Customer : Person
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Card { get; set; }
        public List<Order> Purchases { get; set; }

        public Customer()
        {
            
        }

        public Customer(string name, int age, string address, string card) : base(name, age)
        {
            Address = address;
            Card = card;
        }
    }
}
