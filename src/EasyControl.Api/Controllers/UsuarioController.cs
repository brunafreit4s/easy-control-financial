using System.Security.Authentication;
using EasyControl.Api.Contract.Usuario;
using EasyControl.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyControl.Api.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuarioController : ControllerBase
    {
        #region Construtor e Injeção de Dependência
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion

        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticar(UsuarioLoginRequestContract contract){
            try{
                return Ok(await _usuarioService.Authenticate(contract));
            }
            catch(AuthenticationException ex){
                return Unauthorized(new { StatusCode = 401, message = ex.Message});
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(UsuarioRequestContract contract){
            try{
                return Created("", await _usuarioService.Add(contract, 0));
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(){
            try{
                return Ok(await _usuarioService.GetAll());
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id){
            try{
                return Ok(await _usuarioService.GetById(id));
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }

        // [HttpGet]
        // [Route("email/{email}", Name = "GetByEmail")]
        // [AllowAnonymous]
        // public async Task<IActionResult> GetByEmail(string email){
        //     try{
        //         return Ok(await _usuarioService.GetByEmail(email));
        //     }
        //     catch(Exception ex){
        //         return Problem(ex.Message);
        //     }
        // }

        [HttpPut]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(long id, UsuarioRequestContract contract){
            try{
                return Created("", await _usuarioService.Update(id, contract, 0));
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(long id){
            try{
                await _usuarioService.Delete(id, 0);
                return NoContent();                
            }
            catch(Exception ex){
                return Problem(ex.Message);
            }
        }
    }
}