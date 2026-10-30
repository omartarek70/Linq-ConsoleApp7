using System;
using System.Linq;
using static ListGenerators;

internal class ListGenerators
{
    public static List<Product> ProductList { get; } = new()
    {
        new Product("Chai", "Beverages", 18m, 39),
        new Product("Chang", "Beverages", 19m, 17),
        new Product("Aniseed Syrup", "Condiments", 10m, 13),
        new Product("Chef Anton's Cajun Seasoning", "Condiments", 22m, 53),
        new Product("Ikura", "Seafood", 31m, 20),
        new Product("Konbu", "Seafood", 6m, 24)
    };

    public static List<Customer> CustomerList { get; } = new()
    {
        new Customer("ALFKI", new List<Order>
        {
            new Order(new DateTime(1997, 8, 25))
        }),
        new Customer("ANATR", new List<Order>
        {
            new Order(new DateTime(1996, 9, 18))
        })
    };
}

internal sealed record Product(string ProductName, string Category, decimal UnitPrice, int UnitsInStock);

internal sealed record Customer(string CustomerID, List<Order> Orders);

internal sealed record Order(DateTime OrderDate);

namespace Linq_ConsoleApp7
{

    internal class Program
    {
     
        static void Main()
        {
            //Console.WriteLine("Hello, World!");


         

                var q1 = ProductList.Where(p => p.Category == "Seafood");
                foreach (var p in q1) Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");


                var q2 = ProductList.Select(p => p.ProductName);
                foreach (var n in q2) Console.WriteLine(n);


                var q3 = ProductList.OrderBy(p => p.UnitPrice);
                foreach (var p in q3) Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");


                var q4 = ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
                foreach (var p in q4) Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");


                var q5 = ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");
                foreach (var p in q5) Console.WriteLine(p.ProductName);


                var q6 = ProductList.Select(p => new
                {
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                });
                foreach (var x in q6) Console.WriteLine($"{x.Name} | {x.Price} | {x.StockStatus}");


                var q7 = ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");
                foreach (var s in q7) Console.WriteLine(s);


                var q8 = ProductList.OrderBy(p => p.Category)
                                    .ThenByDescending(p => p.UnitPrice);
                foreach (var p in q8) Console.WriteLine($"{p.Category} - {p.ProductName} - {p.UnitPrice}");


                var q9 = ProductList.Where(p => p.Category == "Beverages")
                                    .OrderByDescending(p => p.UnitsInStock);
                foreach (var p in q9) Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");


                var q10 = from c in CustomerList
                          from o in c.Orders
                          where o.OrderDate.Year >= 1997
                          select new { c.CustomerID, o.OrderDate };
                foreach (var x in q10) Console.WriteLine($"{x.CustomerID} - {x.OrderDate:d}");


                var q11 = ProductList.Select((p, i) => new { Index = i + 1, p.ProductName });
                foreach (var x in q11) Console.WriteLine($"{x.Index}. {x.ProductName}");


                string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                var q12 = Arr.OrderBy(w => w.Length)
                             .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
                foreach (var w in q12) Console.WriteLine(w);


                string[] digits = { "zero", "one", "two", "three", "four",
                            "five", "six", "seven", "eight", "nine" };
                var q13 = digits.Where(d => d[1] == 'i').Reverse();
                foreach (var d in q13) Console.WriteLine(d);
            }
        }




}
