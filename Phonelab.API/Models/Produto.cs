using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonelab.API.Models;
[Table("Produto")]
public class Produto
{
    [Key] public int Id { get; set; }
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    
    [StringLength(100)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }
    
    [StringLength(3000)]
    [Required(ErrorMessage = "A trancrição é obrigatória")]
    public string Descricao { get; set; }
    public int QtdeId { get; set; }
    [ForeignKey("QtdeId")]

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Custo")]
    [Required(ErrorMessage = "O valor de custo é obrigatório")]
    public decimal ValorCusto { get; set; }
   
    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Venda")]
    [Required(ErrorMessage = "O valor de venda é obrigatório")]
    public decimal ValorVenda { get; set; }

    [Display(Name = "Destaque")]
    [Required]
    public bool Destaque { get; set; } = false;

    [StringLength(300)]
    public string Foto { get; set; }

}