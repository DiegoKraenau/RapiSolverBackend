using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface ICustomerRepository
    {
        CustomerDTO SearchCustomer(int id);

        IEnumerable<CustomerDTO> ShowCustomers();

        bool RegisterCustomer(Customer entity);

        bool UpdateCustomer(Customer entity);

        bool BuySubscription(int id);


    }
}
