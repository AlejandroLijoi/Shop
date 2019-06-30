namespace Shop.Web.Data
{
    public class CountryRepository : GenericRepository<Country>, ICountryReposoitory
    {
        public CountryRepository(DataContext context) : base(context)
        {

        }
    }
}
