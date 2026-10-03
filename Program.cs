using static G_NET106_Advanced_Assignment02.Program;

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

        static List<Product> SearchProduct(List<Product> products, Func<Product, bool> filter) // Func is used because the filter returns true or false
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

        static List<string> TransformProducts(List<Product> products,Func<Product, string> function) // Func is used because the function returns a value for each product
        {
            List<string> result = new List<string>();
            foreach (Product product in products)
            {
                result.Add(function(product));
            }
            return result;
        }

        static List<Product> FilterProducts(List<Product> products,Predicate<Product> condition) // Predicate is used because the condition returns true or false
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (condition(product))
                {
                    result.Add(product);
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

            static void PrintReport(List<Product> products, Action<Product> action) // Action is used because the action does not return a value
            {
                for (int i = 0; i < products.Count; i++)
                {
                    action(products[i]);
                }
            }

            #region Task01
            /*
               Write a single method called SearchProducts that accepts two parameters The method should return a List containing only
               the products that satisfy the condition. Then, call this method four times with different lambda expressions to perform the following searches
            */

            Console.WriteLine("Elictronics : ");
            List<Product> electronics = SearchProduct(catalog, product => product.Category == "Electronics");

            foreach (Product product in electronics)
            {
                Console.WriteLine(product.Name + " -" + " Price:" + product.Price + "$" + " -" + " Stock : " + product.Stock);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.WriteLine("Under $50 : ");
            List<Product> under50 = SearchProduct(catalog, product => product.Price < 50);

            foreach (Product product in under50)
            {
                Console.WriteLine(product.Name + " -" + " Price:" + product.Price + "$" + " -" + " Stock : " + product.Stock);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.WriteLine("In Stock : ");
            List<Product> inStock = SearchProduct(catalog, product => product.Stock > 0);

            foreach (Product product in inStock)
            {
                Console.WriteLine(product.Name + " -" + " Price:" + product.Price + "$" + " -" + " Stock : " + product.Stock);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Clothing Under $100 : ");

            List<Product> clothingUnder100 = SearchProduct(catalog, product => product.Category == "Clothing" && product.Price < 100);

            foreach (Product product in clothingUnder100)
            {
                Console.WriteLine(product.Name + " -" + " Price:" + product.Price + "$" + " -" + " Stock : " + product.Stock);
            }
            #endregion

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            #region Task03
            //Write a method called PrintReport that accepts the product list and an Action. The method loops through all products and calls the action on each one. The caller decides what to print by passing a lambda. 

            Console.WriteLine("Short Report : ");
            PrintReport(catalog, product => Console.WriteLine(product.Name + " -" + product.Price + "$"));
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("Detailed Report : ");
            PrintReport(catalog, product => Console.WriteLine("[" + product.Category + "] " + product.Name + " | " + "Price:" + product.Price + "$" + " | " + "Stock:" + product.Stock));
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            //Write a method called TransformProducts that accepts the product list and a Func.

            Console.WriteLine("Summary List : ");
            List<string> summary = TransformProducts(catalog,product => product.Name+" ("+product.Price+")");

            foreach (string item in summary)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------------------------------------------------------------");

            Console.WriteLine("Price Labels : ");
            List<string> priceLabels = TransformProducts(catalog,product =>product.Name+": "+(product.Price > 100 ? "Expensive!" : "Affordable"));

            foreach (string item in priceLabels)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            //Write a method called FilterProducts that accepts the product list and a Predicate.The method returns a List of products that match the condition. 

            Console.WriteLine("Low-Stock Alert : ");

            List<Product> lowStock = FilterProducts(catalog, product => product.Stock < 20);

            foreach (Product product in lowStock)
            {
                Console.WriteLine("[LOW STOCK] "+ product.Name+": only "+ product.Stock+" left");
            }
            #endregion
        }
    }
}
