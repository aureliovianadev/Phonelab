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
                Id = "a3e4f59e-9b1a-4c61-b4c2-8b4dc3b0c7b2",
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
            new Produto { Id = 1, CategoriaId = 1, Nome = "iPhone 17 Pro Max", Descricao = "iPhone 17 Pro Max. O iPhone mais potente já produzido.Tela brilhante de 6,9 polegadas¹, estrutura unibody em alumínio, chip A19 Pro, câmeras traseiras de 48 MP e a maior duração de bateria em um iPhone.", Qtde = 10, ValorCusto = 8599.10m, ValorVenda = 12599.10m, Destaque = true, Foto = "/img/apple/17/Iphone 17 pro max.webp" },

            new Produto { Id = 2, CategoriaId = 1, Nome = "iPhone 17", Descricao ="iPhone 17. Mais durável. Mais adorável.Tela de 6,3 polegadas com ProMotion¹, Ceramic Shield 2, câmeras traseiras de 48 MP, câmera frontal Center Stage, chip A19 e muito mais.",Qtde = 12, ValorCusto = 4599.10m, ValorVenda = 8599.10m, Destaque = true, Foto = "/img/apple/17/Iphone 17.webp" },

            new Produto { Id = 3, CategoriaId = 2, Nome = "Samsung Galaxy S25 Ultra", Descricao = "A Samsung apresenta o mais novo lançamento da linha S. Seu verdadeiro aliado AI, o Galaxy S25 é o novo celular com o poder da nova geração da inteligência artificial. Tenha em suas mãos uma nova experiência com Galaxy AI, com seus novos recursos. Eleve o seu dia a dia com assistência rápida e completa, graças à execução de tarefas diretamente no dispositivo.", ValorCusto = 8598.28m, ValorVenda = 11599.10m, Destaque = true, Foto = "/img/samsung/S/S25 Ultra.webp"  },

            new Produto { Id = 4, CategoriaId = 2, Nome = "Samsung Galaxy S25",Descricao = "Fotografia profissional no seu bolso. Descubra infinitas possibilidades para suas fotos com as 3 câmeras principais da sua equipe. Teste sua criatividade e brinque com iluminação, diferentes planos e efeitos para obter ótimos resultados.", ValorCusto = 4441.11m, ValorVenda = 3599.10m, Destaque = true, Foto = "/img/samsung/S/S25.webp" },

            new Produto { Id = 5, CategoriaId = 3, Nome = "Motorola Edge 60 Pro",Descricao= "O Motorola Edge 60 PRO 5G é um smartphone de alto desempenho que combina tecnologia avançada e design elegante. Com uma tela Quad-Curve de 6,7 polegadas e resolução de 1220x2712, oferece uma experiência visual imersiva, ideal para jogos e streaming. Seu processador de 3,35 GHz e 24 GB de RAM (12 GB + 12 GB de Ram Boost) garantem que você possa executar múltiplos aplicativos sem lentidão.", ValorCusto = 2399.99m , ValorVenda = 3299.10m, Destaque = true, Foto = "/img/motorola/Moto Edge 60 pro.webp" },

            new Produto { Id = 6, CategoriaId = 3, Nome = "Motorola Edge 60 Fusion", Descricao= "Descubra o Motorola Edge 50s Fusion 5G, um smartphone que combina desempenho excepcional e design elegante. Com uma tela pOLED de 6,7 polegadas e resolução Super HD de 1220x2712, cada imagem ganha vida com cores vibrantes e detalhes nítidos. O processador de 2,5 GHz e 8 GB de RAM, com um impulso adicional de 8 GB, garantem uma experiência fluida, ideal para jogos e multitarefas.",  ValorCusto = 1279.99m, ValorVenda = 1979.10m, Destaque = true, Foto = "/img/motorola/EDGE/Moto edge 60 fusion.webp"},

            new Produto { Id = 7, CategoriaId = 4, Nome = "Xiaomi 15T", Descricao ="Curta aventuras e surpresas do dia sem se preocupar. O Xiaomi 15T está pronto para o seu dia, com bateria de longa duração de 5500mAh, proteção Corning® Gorilla® Glass 7i e certificação IP68, garantindo resistência a impactos, poeira e submersão em água.", ValorCusto = 3930.99m, ValorVenda = 5979.10m, Destaque = true, Foto = "/img/xiaomi/Xiaomi 15t 5g.webp"},

            new Produto { Id = 8, CategoriaId = 4, Nome = "Xiaomi Poco X7 Pro", Descricao= "Um smartphone 5G premium com tela AMOLED 1.5K de 6,67″ a 120 Hz, processador Dimensity 8400-Ultra, câmera principal de 50 MP com OIS, bateria de 6.000 mAh + carregamento rápido de 90 W — tudo isso com design fino, brilho de até 3.200 nits e resistências IP68/Corning Gorilla Glass 7i para acompanhar você em qualquer situação.", ValorCusto = 1133.03m, ValorVenda = 2133.10m, Destaque = true, Foto = "/img/xiaomi/Xiaomi Poc X7 Pro.webp" }
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}

