namespace Shop.Web.Helper
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Shop.Web.Data;


    public interface IUserHelper
    {

        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

    }
}
