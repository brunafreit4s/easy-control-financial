using System.ComponentModel.DataAnnotations;

namespace EasyControl.Api.Domain.Models
{
    public class Usuario
    {
        // 1º - Configuração - Construir a classe modelo
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo E-mail é de preenchimento obrigatório!")]        
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Senha é de preenchimento obrigatório!")]        
        public string Senha { get; set; } = string.Empty;

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataInativacao { get; set; }

    }
}