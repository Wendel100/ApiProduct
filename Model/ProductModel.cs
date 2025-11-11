using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcoApi.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public decimal? Price { get; set; }
        public byte[]? Dados { get; set; }
        [NotMapped]
        public IFormFile? ImagemUpload { get; set; }
        public string? Description { get; set; }
        public ProductModel(int id, string? name, decimal? price, string? description, byte[] dados)
        {
            Id = id;
            Name = name;
            Price = price;
            Dados = dados;
            Description = description;
        }
        public ProductModel()
        {   
        }
    }
}