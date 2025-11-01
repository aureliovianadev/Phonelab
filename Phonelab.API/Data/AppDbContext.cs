using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phonelab.API.Models;

namespace Phonelab.API.Data;
   public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
             new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "aureliovianadev@gmail.com",
                NormalizedEmail = "AURELIOVIANADEV@GMAIL.COM",
                UserName = "aureliovianadev@gmail.com",
                NormalizedUserName = "AURELIOVIANADEV@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Aurélio Viana",
                DataNascimento = DateTime.Parse("02/09/2003"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
                new Categoria() {
                Id = 1,
                Nome = "Apple"
            },
            new Categoria() {
                Id = 2,
                Nome = "Samsung"
            },
            new Categoria() {
                Id = 3,
                Nome = "Motorola"
            },
            new Categoria() {
                Id = 4,
                Nome = "Xiaomi"
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto { Id = 1, CategoriaId = 1, Nome = "iPhone 17 Pro Max", Descricao = "asedgfdasgasd", Qtde = 10, ValorCusto = 5599.10m, ValorVenda = 12599.10m, Destaque = true, Foto = "/img/produtos/1.webp" },
            new Produto { Id = 2, CategoriaId = 1, Nome = "iPhone 17", ValorCusto = 7198.96m },
            new Produto { Id = 3, CategoriaId = 2, Nome = "Samsung Galaxy S25 Ultra", ValorCusto = 8598.28m },
            new Produto { Id = 4, CategoriaId = 2, Nome = "Samsung Galaxy S25", ValorCusto = 4441.11m },
            new Produto { Id = 5, CategoriaId = 3, Nome = "Motorola Edge 60 Pro", ValorCusto = 3399.99m },
            new Produto { Id = 6, CategoriaId = 3, Nome = "Motorola Edge 60 Fusion", ValorCusto = 1979.99m },
            new Produto { Id = 7, CategoriaId = 4, Nome = "Xiaomi 15T", ValorCusto = 3930.99m },
            new Produto { Id = 8, CategoriaId = 4, Nome = "Xiaomi Poco X7 Pro", ValorCusto = 2133.03m }
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}

