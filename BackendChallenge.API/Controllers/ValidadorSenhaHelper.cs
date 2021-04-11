using System.Text.RegularExpressions;

namespace BackendChallenge.API.Controllers
{
    public class ValidadorSenhaHelper
    {
        private int _tamMinimo;
        private int _qtddMinDigitos;
        private int _qtddMinMinusculas;
        private int _qtddMinMaiusculas;
        private int _qtddMinEspecial;
        private string _charEspeciais;
        private bool _permiteRepeticoes;
        private bool _permiteEspacos;

        /// <summary>
        /// Construtor padrão da classe que recebe os atributos necessários para a validação da mesma
        /// </summary>
        /// <param name="tamMinimo_">Tamanho mínimo de caracteres da senha</param>
        /// <param name="qtddMinDigitos_">Quantidade mínima de digitos numéricos da senha</param>
        /// <param name="qtddMinMinusculas_">Quantidade mínima de letras minúsculas da senha</param>
        /// <param name="qtddMinMaiusculas_">Quantidade mínima de letras maiúsculas da senha</param>
        /// <param name="qtddMinEspecial_">Quantidade mínima de caracteres especiais da senha</param>
        /// <param name="charEspeciais_">String contendo os caractéres especiais permitidos na senha - Caso vazia, permitirá todos os caractéres especiais</param>
        /// <param name="permiteRepeticoes_">A senha permite caractéres repetidos? True = Sim | False = Não</param>
        /// <param name="permiteEspacos_">A senha permite espaços em branco? True = Sim | False = Não</param>
        public ValidadorSenhaHelper(int tamMinimo_,
                                    int qtddMinDigitos_,
                                    int qtddMinMinusculas_,
                                    int qtddMinMaiusculas_,
                                    int qtddMinEspecial_,
                                    string charEspeciais_,
                                    bool permiteRepeticoes_,
                                    bool permiteEspacos_)
        {
            _tamMinimo = tamMinimo_;
            _qtddMinDigitos = qtddMinDigitos_;
            _qtddMinMinusculas = qtddMinMinusculas_;
            _qtddMinMaiusculas = qtddMinMaiusculas_;
            _qtddMinEspecial = qtddMinEspecial_;
            _charEspeciais = charEspeciais_;
            _permiteRepeticoes = permiteRepeticoes_;
            _permiteEspacos = permiteEspacos_;
        }

        /// <summary>
        /// Realiza todas as validações disponíveis para a senha fornecida
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool Validar(string senha_)
        {
            return !string.IsNullOrWhiteSpace(senha_)
                   && TamanhoValido(senha_)
                   && DigitoValido(senha_)
                   && MinusculaValida(senha_)
                   && MaiusculaValida(senha_)
                   && CaracterEspecialValido(senha_)
                   && RepeticaoValida(senha_)
                   && EspacoValido(senha_);
        }

        /// <summary>
        /// Valida se o tamanho da senha é maior ou igual ao tamnho mínimo configurado no construtor 
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool TamanhoValido(string senha_)
        {
            return senha_.Length >= _tamMinimo;
        }

        /// <summary>
        /// Valida se a senha possui uma quantidade de dígitos (0-9)
        /// maior ou igual ao tamnho mínimo configurado no construtor 
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool DigitoValido(string senha_)
        {
            var regexDigito = new Regex("[0-9]");
            return regexDigito.Matches(senha_).Count >= this._qtddMinDigitos;
        }

        /// <summary>
        /// Valida se a senha possui uma quantidade de letras minúsculas (a-z) 
        /// maior ou igual ao tamnho mínimo configurado no construtor 
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool MinusculaValida(string senha_)
        {
            var regexMinuscula = new Regex("[a-z]");
            return regexMinuscula.Matches(senha_).Count >= this._qtddMinMinusculas;
        }

        /// <summary>
        /// Valida se a senha possui uma quantidade de letras maiúsculas (A-Z) 
        /// maior ou igual ao tamnho mínimo configurado no construtor 
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool MaiusculaValida(string senha_)
        {
            var regexMaiuscula = new Regex("[A-Z]");
            return regexMaiuscula.Matches(senha_).Count >= this._qtddMinMaiusculas;
        }

        /// <summary>
        /// Valida se a senha possui uma quantidade de caracteres especiais (fornecidos no construtor) 
        /// maior ou igual ao tamnho mínimo configurado no construtor 
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool CaracterEspecialValido(string senha_)
        {
            var regexCharEspec = new Regex("[^a-zA-Z0-9]");
            if (!string.IsNullOrEmpty(this._charEspeciais))
            {
                regexCharEspec = new Regex($"[{ _charEspeciais }]");
            }
            return regexCharEspec.Matches(senha_).Count >= this._qtddMinEspecial;
        }

        /// <summary>
        /// Valida se a senha possui repetições válidas, de acordo com a configuração
        /// recebida no construtor
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool RepeticaoValida(string senha_)
        {
            if (!this._permiteRepeticoes)
            {
                var regexRepeticao = new Regex(@"(\w)*.*\1");
                return !regexRepeticao.IsMatch(senha_);
            }
            return true;
        }

        /// <summary>
        /// Valida se a senha possui espaços em branco válidos, de acordo com a configuração
        /// recebida no construtor
        /// </summary>
        /// <param name="senha_">Senha a ser avaliada</param>
        /// <returns>True = Válida | False = Inválida</returns>
        public bool EspacoValido(string senha_)
        {
            if (!this._permiteEspacos)
            {
                return !senha_.Contains(' ');
            }

            return true;
        }
    }
}