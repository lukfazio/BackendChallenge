using BackendChallenge.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackendChallenge.API.Teste
{
    [TestClass]
    public class ValidadorSenhaHelperTeste
    {

        private ValidadorSenhaHelper validador;

        [TestInitialize]
        public void Inicializador()
        {

            validador = new ValidadorSenhaHelper(tamMinimo_: 9,
                                                 qtddMinDigitos_: 1,
                                                 qtddMinMinusculas_: 1,
                                                 qtddMinMaiusculas_: 1,
                                                 qtddMinEspecial_: 1,
                                                 charEspeciais_: "!@#$%^&*()-+",
                                                 permiteRepeticoes_: false,
                                                 permiteEspacos_: false);
        }

        [TestMethod]
        public void Validador_Validar_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "AbTp9!fok";

            var resultadoTeste = validador.Validar(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_Validar_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "         ";

            var resultadoTeste = validador.Validar(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_TamanhoValido_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "123456789";

            var resultadoTeste = validador.TamanhoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_TamanhoValido_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "12345678";

            var resultadoTeste = validador.TamanhoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_DigitoValido_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "abc1";

            var resultadoTeste = validador.DigitoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_DigitoValido_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "abcd";

            var resultadoTeste = validador.DigitoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_MinusculaValida_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "abc";

            var resultadoTeste = validador.MinusculaValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_MinusculaValida_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "ABC";

            var resultadoTeste = validador.MinusculaValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_MaiusculaValida_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "ABC";

            var resultadoTeste = validador.MaiusculaValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_MaiusculaValida_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "abc";

            var resultadoTeste = validador.MaiusculaValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_CharacterEspecialValido_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "abc!";

            var resultadoTeste = validador.CaracterEspecialValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_CharacterEspecialValido_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "abcd";

            var resultadoTeste = validador.CaracterEspecialValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_RepeticaoValida_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "abcd";

            var resultadoTeste = validador.RepeticaoValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_RepeticaoValida_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "aabbcc";

            var resultadoTeste = validador.RepeticaoValida(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_EspacoValido_ComSucesso()
        {
            var resultadoEsperado = true;
            var senhaTestada = "aabbcc";

            var resultadoTeste = validador.EspacoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

        [TestMethod]
        public void Validador_EspacoValido_ComErro()
        {
            var resultadoEsperado = false;
            var senhaTestada = "aa bb cc";

            var resultadoTeste = validador.EspacoValido(senhaTestada);

            Assert.AreEqual(resultadoEsperado, resultadoTeste);
        }

    }
}
