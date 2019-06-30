namespace Shop.Web.Data
{
    using Shop.Web.Data.Entities;

    public class Country : IEntity
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
    }
}
