using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenter
{
    class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Producer { get; set; }

        public Product(string name, string price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public override string ToString()
        {
            decimal price = decimal.Parse(this.Price);

            return $"{{{this.Name};{this.Producer};{price.ToString("0.00")}}}";
        }
    }
}
