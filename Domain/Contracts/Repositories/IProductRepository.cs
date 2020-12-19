using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        // Write
        void Create(Product model);
        void Update(Product model);
        void Delete(Guid id);

        // Read
        Product GetById(Guid id);
        List<Product> GetAll();
        bool Exists(string name);       
        bool ExistsUpdate(string name, Guid id);
        List<Product> Search(string filter);
    }
}