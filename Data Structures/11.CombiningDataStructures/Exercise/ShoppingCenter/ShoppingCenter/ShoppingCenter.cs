using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenter
{
    class ShoppingCenter
    {
        private SortedDictionary<string, List<Product>> byName = new SortedDictionary<string, List<Product>>();
        private SortedDictionary<string, List<Product>> byProducer = new SortedDictionary<string, List<Product>>();

        public void Add(string name, string price, string producer)
        {
            Product product = new Product(name, price, producer);
           
            // by Name
            if (!this.byName.ContainsKey(name))
            {
                this.byName.Add(name, new List<Product>());
            }
            this.byName[name].Add(product);

            // by Producer
            if (!this.byProducer.ContainsKey(producer))
            {
                this.byProducer.Add(producer, new List<Product>());
            }
            this.byProducer[producer].Add(product);

            Console.WriteLine("Product added");
        }

        public void DeleteProducts(string producer)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                Console.WriteLine("No products found");
                return;
            }

            int count = this.byProducer[producer].Count;
            foreach (var entry in this.byName.Keys)
            {
                this.byName[entry].RemoveAll(p => p.Producer == producer);
            }
            this.byProducer[producer].Clear();

            Console.WriteLine($"{count} products deleted");
        }

        public void DeleteProducts(string name, string producer)
        {
            if (!this.byProducer.ContainsKey(producer))
            {
                Console.WriteLine("No products found");
                return;
            }
            else if (!this.byProducer[producer].Any(p => p.Name == name))
            {
                Console.WriteLine("No products found");
                return;
            }

            int count = 0;

            this.byProducer[producer].RemoveAll(p => p.Name.Equals(name));

            count += this.byName[name].Count;
            this.byName[name].RemoveAll(p => p.Producer.Equals(producer));
            count -= this.byName[name].Count;
            

            Console.WriteLine($"{count} products deleted");
        }

        public void FindProductsByName(string name)
        {
            if (!this.byName.ContainsKey(name) || this.byName[name].Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var product in this.byName[name].OrderBy(w => w.Name))
            {
                sb.AppendLine(product.ToString());
            }
            Console.Write(sb.ToString());
        }

        public void FindProductsByProducer(string producer)
        {
            if (!this.byProducer.ContainsKey(producer) || this.byProducer[producer].Count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var product in this.byProducer[producer].OrderBy(w => w.Name))
            {
                sb.AppendLine(product.ToString());
            }
            Console.Write(sb.ToString());
        }

        public void FindProductsByPriceRange(string start, string end)
        {
            StringBuilder sb = new StringBuilder();
            decimal rangeStart = decimal.Parse(start);
            decimal rangeEnd = decimal.Parse(end);
            IEnumerable<Product> current = new List<Product>();
            IList<Product> result = new List<Product>();
            int count = 0;

            foreach (var product in this.byProducer.Keys)
            {
                current = this.byProducer[product].Where(p => decimal.Parse(p.Price) >= rangeStart && decimal.Parse(p.Price) <= rangeEnd);
                count += current.Count();
                foreach (var item in current)
                {
                    result.Add(item);
                }
            }
            if (count == 0)
            {
                Console.WriteLine("No products found");
                return;
            }

            result.OrderBy(p => p.Name);
            foreach (var item in result)
            {
                sb.AppendLine(item.ToString());
            }
            Console.Write(sb.ToString());
        }
    }
}
