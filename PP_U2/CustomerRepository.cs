using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_U2
{
    public class CustomerRepository
    {
        private Customer customer1 = new Customer(1, "Deivid", "Address1", 1);
        private Customer customer2 = new Customer(2, "Ivan", "Address2", 2);
        private Customer customer3 = new Customer(3, "Petur", "Address3", 3);
        public CustomerRepository()
        {
            Customers.Add(customer1);
            Customers.Add(customer2);
            Customers.Add(customer3);
        }
        public List<Customer> Customers = new List<Customer>();
        public async Task<Customer> SearchForCustomer(int id)
        {
            //await Task.Delay(1);
            return Customers.FirstOrDefault(x => x.Id == id);
        }
        public async Task<List<Customer>> SearchByIDsAsync(List<int> ids)
        {
            List<Customer> result = new List<Customer>();
            List<Task<Customer>> tasks = new List<Task<Customer>>();
            for (int i = 0; i < ids.Count; i++)
            {
                Task<Customer> task = SearchForCustomer(ids[i]);
                tasks.Add(task);
            }

            await Task.WhenAll();

            foreach (Task<Customer> task in tasks)
            {
                result.Add(task.Result);
            }

            return result;
        }
    }
}
