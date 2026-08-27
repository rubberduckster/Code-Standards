// Categories of flaws:
// 1. Naming conventions: Class names, method names, and variable names do not follow PascalCase or camelCase as per C# standards.
// 2. Hungarian notation: Prefixes like "str", "i", "d"
// 3. Magic numbers: Hardcoded values without explanation.
// 4. Bad naming: Variables and methods have unclear names that do not convey their purpose.
// 5. Inconsistent formatting: Underscores in method names, inconsistent casing, etc.

// Most of these issues are fixed now (: and expanded the program according to what the first assignment required

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

class ProductCalculator
{
    const int MaxQuantity = 100;
    const decimal DiscountThreshold = 500m;
    const decimal DiscountRate = 0.15m;
    const int LargeOrderQuantity = 50;

    static void Main(string[] args)
    {
        bool orderMore = true;

        List<Product> productList = new List<Product>();

        decimal totalPrice = 0;

        do
        {
                Product product = new Product();

                Console.Write("Indtast vare navn: ");
                product.Name = Console.ReadLine();

                Console.Write("Indtast antal varer: ");
                product.Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Indtast pris pr. vare: ");
                product.UnitPrice = Convert.ToDecimal(Console.ReadLine());

                productList.Add(product);

                string message = CalculateStatus(product.Quantity);
                Console.WriteLine(message);

                Console.Write("Vil du bestille mere? (j/n)");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "n")
                {
                    Console.WriteLine("Vare og pris");

                    foreach (Product currentProduct in productList)
                    {
                        Console.WriteLine(
                            $"{currentProduct.Name} x {currentProduct.Quantity}: {currentProduct.TotalPrice:F2} kr.");

                        totalPrice += currentProduct.TotalPrice;
                    }

                    Console.WriteLine($"Samlet pris før rabat: {totalPrice:F2} kr.");

                    if (totalPrice > DiscountThreshold)
                    {
                        decimal discount = totalPrice * DiscountRate;
                        decimal priceAfterDiscount = totalPrice - discount;

                        Console.WriteLine($"Rabat: {discount:F2} kr.");
                        Console.WriteLine($"Samlet pris: {priceAfterDiscount:F2} kr.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen rabat (under 500 kr.)");
                        Console.WriteLine($"Samlet pris: {totalPrice:F2} kr.");
                    }

                    orderMore = false;
                }

        } while (orderMore);
    }

    class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
        }

    }

    static string CalculateStatus(int quantity)
    {
        if (quantity > LargeOrderQuantity)
        {
            return "Stor ordre";
        }
        return "Almindelig ordre";
    }
}

class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
