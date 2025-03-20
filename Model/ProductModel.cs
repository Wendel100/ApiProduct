using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoApi.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public string Description{ get; set; }
        public ProductModel(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}