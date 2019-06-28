namespace Shop.Web.Data
{


    using Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }
        /// <summary>
        ///    ADICIONA PRODUCTOS SI LA BASE DE DATOS SE BORRO 
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product");
                this.AddProduct("Second Product");
                this.AddProduct("Third Product");
                await this.context.SaveChangesAsync();
            }
        }
        /// <summary>
        ///        PONE CUALQUIER PRECIO Y STOCK PARA PREUBAS 
        /// </summary>
        /// <param name="name"></param>
        private void AddProduct(string name)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            });
        }
    }

    }
