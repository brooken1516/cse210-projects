using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _product;
    private Customer _customer;

    public Order(List<Product> product, Customer customer)
    {
        _product = product;
        _customer = customer;
    }

    public float CalculateTotal()
    {
        float total = 0;
        foreach (Product product in _product)
            total += product.GetTotalCost();
        if (_customer.IsInUSA())
            total += 5;
        else
            total += 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _product)
        {
            packingLabel += $"Item: {product.Name}, Product ID: {product.ID}\n";
        }
        return "Packing Label:\n" + packingLabel;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.GetFullAddress()}";
    }
}