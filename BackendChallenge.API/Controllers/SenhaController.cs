using BackendChallenge.API.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackendChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhaController : ControllerBase
    {
        private ValidadorSenhaHelper _helper;

        /// <summary>
        /// Construtor padrão que inicializa o ValidadorSenhaHelper
        /// </summary>
        public SenhaController()
        {
            _helper = new ValidadorSenhaHelper(tamMinimo_: 9,
                                                    qtddMinDigitos_: 1,
                                                    qtddMinMinusculas_: 1,
                                                    qtddMinMaiusculas_: 1,
                                                    qtddMinEspecial_: 1,
                                                    charEspeciais_: "!@#$%^&*()-+",
                                                    permiteRepeticoes_: false,
                                                    permiteEspacos_: false);
        }

        /// <summary>
        /// Retorna se a senha fornecida é válida ou não
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        [HttpGet("{senha_}")]
        public ActionResult<bool> GetIsSenhaValida(string senha_)
        {
            bool isValid = _helper.Validar(senha_);

            return new ActionResult<bool>(isValid);
        }


    }
}
