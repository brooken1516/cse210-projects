using System;
using System.Collections.Generic;

public class Product
{
    private string _name;
    private string _ID;
    private float _price;
    private int _quantity;

    public Product(string name, string ID, float price, int quantity)
    {
        _name = name;
        _ID = ID;
        _price = price;
        _quantity = quantity;
    }

    public float GetTotalCost()
    {
        return _price * _quantity;
    }

    public string Name
    {
        get { return _name; }
    }

    public string ID
    {
        get { return _ID; }
    }
}