using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System\n");

        Address address1 = new Address("123 Main Street", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        Product product1 = new Product("Laptop", "LP-001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "MS-234", 29.99, 2);
        Product product3 = new Product("USB Cable", "CB-100", 9.99, 3);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n" + new string('-', 50) + "\n");

        Address address2 = new Address("456 Queen Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Sarah Johnson", address2);
        Order order2 = new Order(customer2);

        Product product4 = new Product("Gaming Keyboard", "KB-500", 149.99, 1);
        Product product5 = new Product("Monitor Stand", "ST-789", 39.99, 2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}