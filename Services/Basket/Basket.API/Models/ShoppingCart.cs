﻿namespace Basket.API.Models;

public class ShoppingCart
{
    public string UserName { get; set; }= default!; 
    public List<ShoppingCartItem> Items { get; set; } = new();
    public decimal TotalPrice=>Items.Select(sc=>sc.Price*sc.Quantity).Sum();
    public ShoppingCart(string userName)
    {
        userName = userName;
    }
    public ShoppingCart()
    {
            
    }
}
