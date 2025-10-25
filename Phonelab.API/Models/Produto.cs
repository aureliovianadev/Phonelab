using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonelab.API.Models;
 [Table("Produto")]
public class Produto
{
    [Key, Column(Order = 1)]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]
    public Produto Produto { get; set; }
    
    [Key, Column(Order = 2)]
    public int IngredienteId { get; set; }
    [ForeignKey("IngredienteId")]
    public Ingrediente Ingrediente { get; set; }

    [StringLength(30)]
    [Required(ErrorMessage = "A Quantidade é obrigatória")]
    public string Quantidade { get; set; }
}