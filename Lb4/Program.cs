using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb4
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        

       
        public Product(string name, decimal price, string description, string category)
        {
            Name = name;
            Price = price;
            Description = description;
            Category = category;
        }
    }

   
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> PurchaseHistory { get; set; }

        
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            PurchaseHistory = new List<Order>();
        }
    }

   
    class Order
    {
        public List<Product> Products { get; set; }
        public Dictionary<Product, int> ProductQuantities { get; set; }
        public decimal TotalCost { get; set; }
        public string Status { get; set; }

        
        public Order(List<Product> products, Dictionary<Product, int> productQuantities, decimal totalCost, string status)
        {
            Products = products;
            ProductQuantities = productQuantities;
            TotalCost = totalCost;
            Status = status;
        }
    }

  
    interface ISearchable
    {
        List<Product> SearchByPrice(decimal price);
        List<Product> SearchByCategory(string category);
       
    }

    
    class Store : ISearchable
    {
        private List<Product> products;
        private List<User> users;
        private List<Order> orders;

        public Store()
        {
   
            products = new List<Product>();
            users = new List<User>();
            orders = new List<Order>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public void PlaceOrder(Order order)
        {
            orders.Add(order);
        }

        public List<Product> SearchByPrice(decimal price)
        {
            return products.FindAll(p => p.Price == price);
        }

        public List<Product> SearchByCategory(string category)
        {
            return products.FindAll(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }
       
    }

    
    class Program
    {
        static void Main(string[] args)
        {
          
            Store store = new Store();

            Product product1 = new Product("Phone", 500, "Smartphone", "Electronics");
            Product product2 = new Product("Book", 20, "Novel", "Books");

            store.AddProduct(product1);
            store.AddProduct(product2);

            

            
            List<Product> electronics = store.SearchByCategory("Electronics");
            foreach (var item in electronics)
            {
                Console.WriteLine($"Product: {item.Name}, Category: {item.Category}, Price: {item.Price}");
            }
        }
    }
}