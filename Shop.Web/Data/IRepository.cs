namespace Shop.Web.Data
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    /// <summary>
    ///          THESE METHODS ARE NOT USED
    ///          THIS METHOD NOT SE USA .
    ///          LOS DEJO SOLO DE CONNECTION OPCIONAL
    /// </summary>
    public interface IRepository
    {
        void AddProduct(Product product);

        Product GetProduct(int id);

        IEnumerable<Product> GetProducts();

        bool ProductExists(int id);

        void RemoveProduct(Product product);

        Task<bool> SaveAllAsync();

        void UpdateProduct(Product product);

    }
}