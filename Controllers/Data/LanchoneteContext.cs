using LanchoneteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchoneteApi.Data{
    public class LanchoneteContext: DbContext{
             public LanchoneteContext(DbContextOptions<LanchoneteContext>opts) : base(opts)
        {
            
        }  
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Garcom> Garcons { get; set; }
        public DbSet<ItemComanda> ItensComandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}