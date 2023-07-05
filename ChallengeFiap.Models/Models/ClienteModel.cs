using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeFiap.Models.Models
{
    public class ClienteModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome completo é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O Email completo é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Este campo deve ter no mínimo 5 e no máximo 100 caracteres!")]
        public string Email { get; set; }

        [NotMapped]
        public string? Imagem { get; set; }

    }
}
