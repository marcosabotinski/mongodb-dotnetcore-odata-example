using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using mongodb_dotnetcore_odata_example.Models;
using mongodb_dotnetcore_odata_example.Repositories;

namespace mongodb_dotnetcore_odata_example.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return _customerRepository.GetQueryableCollection();
        }
    }
}
