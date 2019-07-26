namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Entities;
    using Helper;
  
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
         
        }
        /// <summary>
        ///    ADICIONA PRODUCTOS SI LA BASE DE DATOS SE BORRO 
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            /// SUPER USUARIO 
            var user = await this.userHelper.GetUserByEmailAsync("alejandrolijoi@gmail.com");
            if (user == null)
            {
                /// Creo user 
                user = new User
                {
                    FirstName = "Alejandro",
                    LastName = "Lijoi",
                    Email = "alejandrolijoi@gmail.com",
                    UserName = "alejandrolijoi@gmail.com",
                    PhoneNumber = "47561600"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

          
            // Creo product  si la base de datos esta vacia .
            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product",user);
                this.AddProduct("Second Product",user);
                this.AddProduct("Third Product",user);

                await this.context.SaveChangesAsync();
            }
        }
       
        /// <summary>
        ///        PONE CUALQUIER PRECIO Y STOCK PARA PREUBAS 
        /// </summary>
        /// <param name="name"></param>
        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            }) ;
        }
    }

    }
