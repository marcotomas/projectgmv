namespace website.DomainEntities
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public int Id { get; }

        public string Name { get; set; }

        public bool Bought { get; set; }
    }
}