using BackendChallenge.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendChallenge.API.Teste
{
    [TestClass]    
    public class SenhaControllerTeste
    {
        [TestMethod]
        public void SenhaController_GetSenhaValida_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "AbTp9!fok";
            var controller = new SenhaController();

            var resultado = controller.GetSenhaValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultado.Value);

        }
    }
}
