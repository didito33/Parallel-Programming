using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_U2
{
    public class Customer
    {
        public Customer(int id, string name, string address, int numberOfOrders)
        {
            Id = id;
            Name = name;
            Address = address;
            NumberOfOrders = numberOfOrders;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
