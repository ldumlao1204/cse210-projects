using System;
using System.Text;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public Customer GetCustomer() { return customer; }
    public List<Product> GetProducts() { return products; }

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in products)
        {
            total += product.GetTotalCost();
        }

        if (customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("=== PACKING LABEL ===");

        foreach (Product product in products)
        {
            label.AppendLine($"Product: {product.GetName()} (ID: {product.GetProductId()})");
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("=== SHIPPING LABEL ===");
        label.AppendLine($"Customer: {customer.GetName()}");
        label.AppendLine("Address:");
        label.AppendLine(customer.GetAddress().GetFullAddress());

        return label.ToString();
    }
}