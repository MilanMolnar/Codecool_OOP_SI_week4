namespace InvProj
{
    public abstract class Product : PersistentStore
    {
        public int Price { get; set; }
        public string Name { get; set; }

        protected Product(int price, string name)
        {
            Price = price;
            Name = name;
        }
    }
}