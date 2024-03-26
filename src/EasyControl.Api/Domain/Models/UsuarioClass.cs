using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyControl.Api.Domain.Models
{
    public class Usuario
    {
        // 1º - Configuração - Construir a classe modelo
        // 1º - CRUD - Construir a classe modelo
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo E-mail é de preenchimento obrigatório!")]        
        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Senha é de preenchimento obrigatório!")]        
        [Column("Senha")]
        public string Password { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataInativacao { get; set; }

    }
}