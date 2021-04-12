# BackendChallenge

## Sobre
O projeto foi criado para resolver o problema proposto pelo [backend-challenge](https://github.com/itidigital/backend-challenge) realizado em Abril de 2021.

## Tecnologia
Para a criação do projeto utilizei o VisualStudio 2019, criando um ASP.NET Core Web API na versão 5.0 do .Net Core.

## Como Executar?
Para executar a API sem utilizar o modo de depuração do Visual Studio, pode ser utilizado diretamente a API publicada na pasta **Publicado** através dos seguintes passos:
1. Execute o executavel da solução publicada no caminho **BackendChallenge/Publicado/BackendChallenge.API.exe**
2. A janela do prompt será exibida com o caminho no qual a API está sendo executada, como abaixo:
```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
```
3. Acesso a API pelo Navegador ou Postman, como no link de exemplo abaixo, passando a string a ser validade como parâmetro no link:
```
https://localhost:{Porta}/api/Senha/{Senha_A_Ser_Verificada}

Ex:

https://localhost:5001/api/Senha/AbTp9!fok

```
4. A API irá retorna **true** caso a senha seja válida ou **false** caso seja inválida.
5. Pressione 'Ctrl+C' no Prompt para encerrar a execução da API.

## Estratégia
Aproveitando a facilidade que a versão 5.0 do .Net Core nos fornece de criar a estrutura da API já com a implementação do Swagger como página inicial da aplicação em depuração (que optei por manter devida a facilidade que o mesmo nos fornece para testar e documentar os Controllers e Actions), realizei a criação da Controller **SenhaController** responsável por receber a solicitação da validação da senha, através da HttpAction GET no método *GetIsSenhaValida*.

Como toda a estrutura de validação poderia ser reaproveitada por diferentes Controllers e outras peças da aplicação, optei por externalizar toda a lógica de validação da senha em uma classe ajudante (helper), chamada **ValidadorSenhaHelper**. Essa poderia ser responsável por validar os senhas com vários tipos de definições, logo optei por deixar a mesma o mais customizável possível, deixando todos os requisitos de desafio como parâmetros que devem ser fornecidos no construtor da classe. 
Dessa forma, ao utilizar a classe Helper, o Controller referente ao Challenge pode ser preenchido com os parâmetros do mesmo, sem que isso ficasse *hardcoded* no fonte do Helper:

```
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
```

A partir desse ponto, iniciei o desenvolvimento de cada uma das validações solicitadas utilizando TDD, ou seja, criando o método de Teste, definindo o resultado esperado, realizando a chamada do método a ser testado e realizando a comparação de ambos os resultados. Com o teste inicialmente criado, desenvolvi cada método para respeitar as condições de entrada e devolver o resultado conforme o esperado. No final do processo, a classe **ValidadorSenhaHelper** ficou com 8 métodos (criei o método geral *Validar* responsável por disparar todas as validações) cada qual com seus respectivos métodos de teste tanto de Sucesso quanto de Erro, a saber:

* public bool Validar(string senha_)
* public bool TamanhoValido(string senha_)
* public bool DigitoValido(string senha_)
* public bool MinusculaValida(string senha_)
* public bool MaiusculaValida(string senha_)
* public bool CaracterEspecialValido(string senha_)
* public bool RepeticaoValida(string senha_)
* public bool EspacoValido(string senha_)

Por fim, realizei a chamada do método *Validar* dentro do método *GetIsSenhaValida* da Controller, retornando para a chamada da API a ActionResult com o resultado da validação.

## Desafios
Acredito que os foram 2 os principais desafios que encontrei no desenvolvimento do projeto:

1. **Desenvolver uma API utilizando .Net Core.**
> No decorrer da minha vida profissional como Desenvolvedor de Software eu já havia criado algumas API's, porém nenhuma utilizando a tecnologia .Net Core. Optei por utilizar essa tecnologia para aprender e conhecer a mesma e as facilidades que ela nos traz. Tive que estudar um pouco, assistindo alguns vídeos e lendo artigos da própria Microsoft de como criar uma API e adaptando à minha necessidade. No final do desenvolvimento, fiquei contente em ter conseguido criar essa primeira API funcional.
    
    
2. **Otimizar a validação dos campos.**
> Enquanto algumas validações são bem óbvias e simples de serem realizadas, basicamente analisando a própria string, outras foram mais desafiadoras. Faziam anos que não utilizava Regex que estudei de forma bem superficial na faculdade de Ciência da Computação, porém lembrava vagamente que o uso da mesma podia facilitar análises de conjuntos de caracteres, justamente o que precisava nesse desafio. Tive de relembrar vários tópicos e testar outros, tarefa que foi muito facilitada pelo uso do TDD.



