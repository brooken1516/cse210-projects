using System;

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("Guitar Strings", "GS444", 8.50f, 1);
        Product product2 = new Product("Blank Music Sheets", "MS345", 1.00f, 30);
        Product product3 = new Product("Guitar Pick", "GP897", 5.00f, 5);

        Address address1 = new Address("445 W 600 N", "Vernal", "Utah", "USA");

        Customer customer1 = new Customer("Brett Smith", address1);

        List<Product> orderProducts = new List<Product> { product1, product2, product3 };
        Order order1 = new Order(orderProducts, customer1);

        string packingLabel = order1.GetPackingLabel();
        float totalCost = order1.CalculateTotal();
        string shippingLabel = order1.GetShippingLabel();

        Console.WriteLine(packingLabel);
        Console.WriteLine($"Total Cost: {totalCost}\n");
        Console.WriteLine(shippingLabel);
        Console.WriteLine();
        Console.WriteLine();


        Product product4 = new Product("Song Book", "SB555", 20.75f, 1);
        Product product5 = new Product("Piano Light", "PL568", 60.30f, 1);
        Product product6 = new Product("Chocolate Reward", "CR378", 2.50f, 30);

        Address address2 = new Address("Baccio da Montelupo 44", "Scandicci", "Florence", "Italy");

        Customer customer2 = new Customer("Frances Capuozzo", address2);

        List<Product> orderProducts2 = new List<Product> { product4, product5, product6 };
        Order order2 = new Order(orderProducts2, customer2);

        string packingLabel2 = order2.GetPackingLabel();
        float totalCost2 = order2.CalculateTotal();
        string shippingLabel2 = order2.GetShippingLabel();

        Console.WriteLine(packingLabel2);
        Console.WriteLine($"Total Cost: {totalCost2}\n");
        Console.WriteLine(shippingLabel2);
    }
}