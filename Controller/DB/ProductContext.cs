using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcoApi.Controller.DB
{
public class ProductContext(DbContextOptions<ProductContext> options) : DbContext(options)
{
public DbSet<ProductModel> Produtos { get; set; }
}
}