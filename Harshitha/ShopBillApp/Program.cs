using System;
using System.Collections.Generic;

Console.WriteLine("Welcome to My Shop!");
Console.WriteLine("------------------");

Console.Write("Enter customer name: ");
string customerName = Console.ReadLine();
Console.WriteLine($"Hello, {customerName}!");

List<string> items = new List<string>();
double totalAmount = 0;

Console.Write("How many items? ");
int count = int.Parse(Console.ReadLine());

for (int i = 1; i <= count; i++)
{
    Console.Write($"Item {i} name: ");
    string name = Console.ReadLine();

    Console.Write($"Price of {name}: ₹");
    double price = double.Parse(Console.ReadLine());

    items.Add($"{name} — ₹{price}");
    totalAmount += price;
}

Console.WriteLine("\n===== BILL =====");
Console.WriteLine($"Customer: {customerName}");
Console.WriteLine("Items:");

foreach (string item in items)
{
    Console.WriteLine($"  - {item}");
}

Console.WriteLine("----------------");
Console.WriteLine($"Total: ₹{totalAmount}");
Console.WriteLine("Thank you! Come again!");