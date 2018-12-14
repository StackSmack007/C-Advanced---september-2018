using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<Product>> shopProductPrice = new Dictionary<string, List<Product>>();
        while (true)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (input[0] == "Revision")
            {
                break;
            }
            string shopName = input[0];
            string productName = input[1];
            decimal productPrice = decimal.Parse(input[2]);
            Product currentProduct = new Product
            {
                Name = productName,
                Price = productPrice
            };
            if (!shopProductPrice.ContainsKey(shopName))
            {
                shopProductPrice[shopName] = new List<Product> { currentProduct };
            }
            else
            {
                int indexOfElement = shopProductPrice[shopName].FindIndex(x => x.Name == productName);
                if (indexOfElement == -1)
                {
                    shopProductPrice[shopName].Add(currentProduct);
                }
                else
                {
                    shopProductPrice[shopName][indexOfElement].Price = productPrice;
                }
            }
        }
        foreach (var kvp in shopProductPrice.OrderBy(x => x.Key))
        {
            Console.WriteLine(kvp.Key + "->");
            foreach (var product in kvp.Value)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price.ToString().TrimEnd('0')}");
            }
        }
    }
}
class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}