using System;

class Program
{
    static void Main(string[] args)
    {
        // Create customers with addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Doe", address2);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "P1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P1002", 25.50, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "P2001", 799.99, 1));
        order2.AddProduct(new Product("Headphones", "P2002", 149.99, 1));
        order2.AddProduct(new Product("Charger", "P2003", 29.99, 3));

        // Display order details
        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}\n");
    }
}
