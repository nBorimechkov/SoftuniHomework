﻿using System;
using System.Collections;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;
    private IList<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold {
        get
        {
            return this.coffeesSold;
        }
    }

    public void BuyCoffee(string size, string type)
    {
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type); 
        if (this.coins >= (int)coffeePrice)
        {
            this.coffeesSold.Add(coffeeType);
            this.coins = 0;
        }
    }
    public void InsertCoin(string coin)
    {
        Coin coffeeCoin = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)coffeeCoin;
    }
   
}

