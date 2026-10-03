namespace G_NET106_Advanced_Assignment02
{
    internal class Program
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public double Price { get; set; }
            public int Stock { get; set; }
        }

        static List<Product> SearchProduct(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            for (int i = 0; i < products.Count; i++)
            {
                if (filter(products[i]))
                {
                    result.Add(products[i]);
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };

            #region Task01
            /*
               Write a single method called SearchProducts that accepts two parameters The method should return a List containing only
               the products that satisfy the condition. Then, call this method four times with different lambda expressions to perform the following searches
            */

            Console.WriteLine("Elictronics : ");
            List<Product> electronics = SearchProduct(catalog,product => product.Category == "Electronics");

            foreach (Product product in electronics)
            {
                Console.WriteLine(product.Name+" -"+" Price:"+product.Price+"$"+" -"+" Stock : "+product.Stock);
            }


            Console.WriteLine("Under $50 : ");
            List<Product> under50 = SearchProduct(catalog,product => product.Price < 50);

            foreach (Product product in under50)
            {
                Console.WriteLine(product.Name+" -"+" Price:"+product.Price+"$"+" -"+" Stock : "+product.Stock);
            }
            #endregion
        }
    }
}
