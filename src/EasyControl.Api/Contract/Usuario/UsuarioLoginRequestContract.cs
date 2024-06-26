
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyControl.Api.Contract.Usuario
{
    //9º - CRUD - Criar os contratos (Contract)/DTO - Data transfer object 
    public class UsuarioLoginRequestContract
    {
        public string Email { get; set; } = string.Empty;          
        public string Password { get; set; } = string.Empty;
    }
}