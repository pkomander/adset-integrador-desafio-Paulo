<img src="https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-integrador.png">

# Desafio para candidatos (AdSet Integrador)

## Solicitação:

- Criar funcionalidade para incluir, consultar, excluir e alterar cadastro de carros e na tela de consulta dos veículos possibilitar a seleção por veículo de apenas um pacote para cada portal iCarros e WebMotors, os pacotes serão (Bronze, Diamante, Platinum ou Básico), conforme layout.
- O cadastro deverá possuir os campos (Marca, Modelo, Ano, Placa, Km, Cor, Preço, lista de opcionais para atribuir ao veículo ex.: (Ar Condicionado, Alarme, Airbag, Freio ABS)).
- Deverá ser possível incluir até 15 fotos para o veículo.
- Apenas a km, opcionais e fotos não devem ser obrigatórios.
- O layout codificado deverá ser exatamente o mesmo do arquivo disponível (adset-layout.ai).
- Nos filtros de dropdown deverão ter as seguintes opções por cada drop (<b>Ano Min</b> = 2000, 2001, 2002.. até 2024 | <b>Ano Max</b> = 2000, 2001, 2002.. até 2024 | <b>Preço</b> = 10mil a 50mil, 50mil a 90mil, +90mil | <b>Fotos</b> = Com Fotos, Sem Fotos | <b>Cor</b> = Listar as cores com os valores em distinct dos veículos inseridos).

Após terminar seu teste submeta um pull request e aguarde seu feedback.

## Instruções:
- Criar Projeto do tipo Class Library para separar a camada de Dados.
- Criar Projeto do tipo ASP.NET Web Application com Template MVC/Razor (Front-End)
- A tela de estoque / consulta deverá ser desenvolvida conforme o layout (https://github.com/adset-innov/adset-integrador-desafio/blob/main/adset-layout.ai) criado no programa Adobe Illustrator.
- Na camada de dados deixe a estrutura completa do Migration para o Entity Framework Code-First pronta para apenas executarmos e gerar o banco e tabelas.
- Caso você julgar necessário, utilize Design patterns e nos informe quais utilizou e porque.

## Pré-requisitos:
- HTML5, CSS, JavaScript, Bootstrap, POO, C#, .NET 4.0+, WebApi, C#, ASP NET, SQL, LINQ, Entity Framework, Code First, Design Responsivo, WebServices *(SOAP)*, APIs Restfull e Windows Services

### IDE:
 - Visual Studio 2013+
 
### Servidor de Banco:
 - Microsoft SQL Server 2012+

## Notas:
* Lembre-se de fazer um fork deste repositório! Apenas cloná-lo vai te impedir de criar o pull request e dificultar a entrega;

## Notas:
![image](https://github.com/pkomander/adset-integrador-desafio-Paulo/assets/54222357/c1c57333-da1d-494a-9ef9-896288ba967d)
# Projeto desenvolvido utilizado ASP NET MVC/Razor .NET CORE 8, utilizando o padão de projetos de desenvolvimento em camadas.
- AdsetIntegrador responsavel pelo Front-end e requisições para as bibliotecas de classes.
- AdsetIntegrador.Business, responsavel pelas validações implementadas no Domain e Dto.
- AdsetIntegrador.Domain, responsavel pelas classes do banco de dados.
- AdsetIntegrador.DTO, responsavel por implementar as abstrações dos objetos do banco de dados, separadamente como (CreateCarroDto, UpdateCarroDto, ReadCarroDto).
- AdsetIntegrador.Repository, responsavel por implementar as interfaces e repository, responsavel pelos metodos do crud do projeto.

## Padrão de projetos:
- Foi utilizado o padrão de projetos Arquitetura em Camadas, pois na arquitetura em camadas, a aplicação é dividida em várias camadas, cada uma responsável por uma parte específica da funcionalidade da aplicação. Cada camada tem uma responsabilidade bem definida e comunica-se com as outras camadas de maneira controlada.

## Inicializar Projeto:
- para inicializar o projeto devera setar a biblioteca de classe AdsetIntegrador.Repository, como projeto padrão no terminal do Nuget, todas as migrations do banco estão contidas lá.

## Observações:
- Devido esta envolvido com outras tarefas que não possibilitaram a concluão do projeto, referenciando o Front-end do projeto, porem o back-end esta completamente funcional, espero poder participar novamente em outro momento com mais tempo para mostrar minhas desde já grato.
