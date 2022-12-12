
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Linq;

Dictionary<string, double> Menu = new Dictionary<string, double>();

Menu.Add("Spaghetti", 10.99);
Menu.Add("Lasagna", 12.99);
Menu.Add("Pizza", 8);
Menu.Add("Calzone", 6);
Menu.Add("Soda", 6.5);
Menu.Add("Wine", 9);
Menu.Add("Beer", 7.5);

Dictionary<int, double> MenuPrices = new Dictionary<int, double>();

MenuPrices.Add(1, 10.99);
MenuPrices.Add(2, 12.99);
MenuPrices.Add(3, 8);
MenuPrices.Add(4, 6);
MenuPrices.Add(5, 6.5);
MenuPrices.Add(6, 9);
MenuPrices.Add(7, 7.5);


Queue<String> orders = new Queue<String>();
string acum = "";
int count = 0;
int count1 = 0;
double totalOrder = 0;
int MaxOrders = 3;

Console.WriteLine("*Menu");

foreach (KeyValuePair<string, double> item in Menu)
{
    count1++;
    Console.WriteLine(count1 + "=" + item.Key + " : " + "$" + item.Value);
}

Console.WriteLine("--------------------------------");

Console.WriteLine("---Make the order, select quantity,number | 0 to Finish | N for a New Order---");

while (true)
{
    var CustomerOrder = Console.ReadLine();

  

    if (CustomerOrder == "0")
    {
        Console.WriteLine("Insert Customer Name");
        var customerName = Console.ReadLine();
        Console.WriteLine("Insert Payment Method (cash/card)");
        var PayMethod = Console.ReadLine();
        orders.Enqueue(customerName + "=" + acum + Math.Round(totalOrder, 2) + ":" + PayMethod);
        break;
    }
    else if (CustomerOrder == "N")
    {
        Console.WriteLine("Before to Create a New Order Insert Customer Name");
        var SavedcustomerName = Console.ReadLine();
        Console.WriteLine("Insert Payment Method (cash/card)");
        var PayMethod = Console.ReadLine();

        Console.WriteLine("-----------------NEW ORDER--------------------");
        Console.WriteLine("---Make the order, select quantity,number | 0 to Finish | N for a New Order---");
        
            
        orders.Enqueue(SavedcustomerName + "=" + acum + Math.Round(totalOrder, 2) + ":" + PayMethod);
        acum = "";
        totalOrder = 0;
        count++;
    }

    if (orders.Count() == MaxOrders)
    {
        Console.WriteLine("Maximum number of orders reached");
        break;
    }


    if (CustomerOrder != "N")
    {
        string[] splCO = CustomerOrder.Split(',');
        int index = Int32.Parse(splCO[1]);
        totalOrder += (MenuPrices[index] * Int32.Parse(splCO[0]));
        acum = splCO[0] + " " + Menu.Keys.ElementAt(index - 1) + ":" + acum;
    }

}


Console.WriteLine("--------------------------------");


Console.WriteLine("Deliveryng --> "+orders.Peek());

orders.Dequeue();

Console.WriteLine("After That:");

foreach (object item in orders)
{
    Console.Write(item);
    Console.WriteLine();

}

orders.Clear();


