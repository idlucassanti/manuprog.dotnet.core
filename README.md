- Criação do Projeto
- Arquitetura Limpa
- Injeção de Dependência
- Validação Domínio
- Relacionamento virtual

- Criação de Banco de Dados
- Criação das Tabelas
- Criação de Chaves Primárias e Estrangeiras


- Criar conexão com Banco de Dados
- Mapear classe Pessoa




# Requisitos

- Cadastrar Pessoa
- Cadastrar Produto
- Cadastrar Compras
- Listar Compras de cada Pessoa



# Ambiente

- .NET 6
- PostgreSQL
- Visual Studio
- PgAdmin 4

# Criação do Projeto e Arquitetura

- Criar Solution => Dentro da solution vamos vincular os projetos



- Camada Domain => Responsável por armazenar classes de entidades, validações das entidades e interfaces de domínio.
- Camada Infra.Data => Responsável por armazenar as classes concretas dos repositórios que faz conexão com o banco de dados.
- Camada Infra.IoC => Responsável por armazenar a injeção de dependência.
- Camada Application => Responsável por armazenar os serviços da aplicação.
- Camada API => Responsável por armazenar



- Associação 
- Domain não pode ter referencia a nenhum projeto, por se tratar do principal e centro da aplicação.
- Application -> Domain
- Infra.Data -> Domain
- Infra.IoC -> Domain, Data e Application
- API -> Infra.IoC



A importancia da camada Infra.IoC:

API iria precisar fazer referencia(depender) da camada de Infra.Data, onde essa camada depende de algo externo(banco de dados, blob).

# Criando a Entidade de Pessoa

- Criar pasta Entities na Camada Domain
- Criar pasta Validations na Camada Domain

- Criar classe Pessoa 
- Criar classe Pessoa como selead para garantir que ninguém tente herdar desta classe. Em um projeto real pode ser que isso aconteça.

- Criar os atributos: Id, Nome, Documento, Telefone.
- Criar métodos set como privados, para não permitir que os atributos sejam acessados fora da classe

- Criar construtor para preencher as informações de Pessoa.


- Validação Genérica que será utilizada em todas as entidades.
- Criar classe DomainValidationException
- essa classe vai herdar de Excpetion
- no construtor receberemos uma string error e iremos passar para a base (Exception)
- Criar método  para saber se vai lançar exception ou não.


- Criar validação para criar Pessoa. Construtor específico para validar e criar Pessoa.
- Criar validação para alterar Pessoa. Construtor específico para validar e alterar uma Pessoa.


# Criando as Entidades Produtos e Compras

- Criar classe Produto
- Classe Produto como selead para garantir que ninguém tente herdar desta classe. Em um projeto real pode ser que isso aconteça.

- Criar os atributos do Produto: Id, Nome, CodErp, Preço.
- Criar os métodos set como privados, para não permitir que os atributos sejam acessados fora da classe.






- Criar classe Compra
- Criar os atributos da Compra: 
- Criar os atributos virtuais de relacionamento

- Criar atributo virtual na classe Pessoa como Collection, fazendo isso, uma pessoa pode ter mais de uma Compra e um Produto pode estar em mais de uma Compra, ou seja, mesmo produto em compras diferentes.




# Criando Banco de Dados e das Tabelas

Na maioria dos cenários, o nome da tabela ou das colunas, são divergentes dos nomes das classes e atributos da classe C#. Então é necessário realizar o mapeamento o banco de dados na API e vincular os nomes no momento do mapeamento.


- Criar banco de dados: 
- Criar tabelas:

- Criar chaves estrangeiras na tabela Compras


CREATE TABLE IF NOT EXISTS PRODUTOS(
  IDPRODUTO,
  NOME VARCHAR(),
  CODIGO VARCHAR(),
  PRECO NUMERIC(10,2)
)

CREATE TABLE IF NOT EXISTS COMPRAS(
  IDCOMPRA,
  PRODUTOID INT,
  PESSOAID INT,
  DATACADASTRO DATE,

  CONSTRAINT FK_PESSOA_COMPRA FOREIGN KEY (PESSOAID) REFERENCES PESSOAS(PESSOAID),
  CONSTRAINT FK_PRODUTO_COMPRA FOREIGN KEY (PRODUTOID) REFERENCES PRODUTOS(PRODUTOID)
)


# Criar Conexão com Banco de dados

- Instalar pacote na Camada Infra.Data: Npgsql.EntityFramework.PostgreSQL 
- Instalar pacote na Camada Infra.Data: Npgsql.EntityFramework.PostgreSQL.Design

- Instalar pacote na Camada Infra.Data: Microsoft.EntityFrameworkCore



- Criar pasta Context na Camada Infra.Data
- Criar classe MPDbContext, responsável por estabelecer a conexão com o banco de dados
- essa classe precisa herdar de DbContext do EntityFramework
- Criar construtor passando DbContextOptions para base


- Sobreescrever o método OnModelCreating passando ModelBuilder
- usar override e void





# Mapeamento classe Pessoa

- Nome da tabela que a classe representa no banco.
- Propriedade Key que a tabela representa.
- Nome da Coluna que a tabela representa.
- Coluna identity (coluna é autoincrementada)
- Chave estrangeira


Quando o ID da tabela que estamos realizando o mapeamento for chave estrangeira de outra tabela, precisamos criar essa relação no mapeamento.

- Tipo de Relacionamento: 1 x N
- Tipo de Relacionamento: 


Qual é a ligação? PessoaId, ProdutoId

# Mapeamento classe Produto


- Chave estrangeira: 

Exemplo do Relacionamento Produto x Compra

O produto Coca-Cola pode estar presente em várias lista de Compras, porém, existirá apenas um Produto Coca-Cola na tabela Produto.


# Mapeamento classe Compra


# Criando Repositório Pessoa e Produto

- Criar pasta Repositories na Camada Domain responsável por armazenar os contratos dos repositórios de cada entidade.
- Criar interfaces: IProdutoRepository e IPessoaRepository
- Criar contrato dos métodos: ObterPorId, ObterTodos, Inserir, Atualizar e Deletar



- Criar pasta Repositories na Camada Infra.Data responsável por armazenar as classes concretas dos repositórios.
- Criar classe concreta dos repositórios: ProdutoRepository e PessoaRepository, responsável 

- Retornar void no Update e Remove
- Receber Entity no Update e Remove

Quando retornar algo do Repositório nos métodos Alterar ou Remover objeto do banco?

- Retornamos NADA quando ...
- Retornamos boolean quando ...
- Retornamos inteiro quando ...


# Criando DTO de Pessoa e suas Validações

As DTOs serão responsáveis por todos os dados que entrarão na aplicação pela Camada API (pelos controllers) e posteriormente convertidos/transformados em Entidades que poderão ou não ser salvos no banco de dados.

Responsável por fazer a ponte entre o mundo externo e nossa aplicação.

- Criar pasta DTOs na Camada Application
- Criar classes Dtos de: Pessoa, Produto
- Criar as mesmas propriedades que a Entidade possui


- Criar pasta Validations na Camada Application


O que o Dto precisa ter?
- os atributos das entidades
- validações dos dados de entrada


- Instalar pacote FluentValidation na Camada Application

- Criar classes Validators: PessoaValidator, ProdutoValidator
- herdar de AbstractValidator<T>
- criar regras dentro construtor dos validators


"REGRA PARA QUAL ATRIBUTO?"
RuleFor

"QUAL REGRA? "
NotNull
NotEmpty

"QUAL MENSAGEM DE ERRO DEVE MOSTRAR? "
WithMessage




# Criando classe Genérica para Retorno dos nossos Serviços [09]


- Criar classe ErroValidation
- Criar classe genérica ResultService que será utilizada por todos os serviços da aplicação, responsável por tratar todos os retornos. Se der certo, retorna OK. Se der falha, retorna um tipo de falha.

Tratar OK
Tratar todos os tipos de falhas: 


Possíveis retornos

- Criar como genérico é para a mesma classe aceitar vários tipos de retornos.


Como estamos tratando os erros com Fluent Validation, toda vez que houver algum erro de validação será armazenado no Validation Result.



Padronizando assim o retorno de todos os serviços, 

Desafios: Complexidade
Benefícios: Padronização do retorno, facilitando seu uso nos Controllers, pois ja sabe como vai vir e como vamos tratar cada retorno.




# Criando o Serviço de Pessoa [10]

- Criar pasta Services na camada Applications

- Criar pasta Interfaces
- Criar classe interface IPessoaService
- Criar os métodos de contrato: CriarAsync
- retornar todos os contratos com o ResultService<T> ou ResultService


- Criar classe de serviço PessoaService, responsável por implementar todos os serviços declarados no contrato da interface IPessoaService referente ao domínio Pessoa.





- Instalar pacote AutoMapper na Camada Application
- responsável por comparar os atributos das entidades e os que foram iguais, irá converter automaticamente para dtos.

- Criar pasta Mappings/Mappers
- Criar classes de Mappings: DomainToDtoMapping e DtoToDomainMapping , responsáveis por realizar a conversão automática de Dto para Entidade e de Entidade para Dto.
- herdar de Profile
- no construtor, criar o mapemaento



- Injeção de Dependencia do Repositório
- Injeção de Dependência do AutoMapper

# Ajustes

- Nas Entidades que possui Listas, é necessário inicializar as listas no construtor para que no nomento de realizar uma inserção não de erro, por estar NULL.

- Validação da Data para atributo Data Registro/Cadastro não faz sentido, uma vez que deve ser setada no momento que é instanciando o objeto pela primeira vez. Essa data de NOW que será registrado.




# Criando Injeção de Dependência [11]


- Criar classe DependencyInjection na camada IoC
- classe estática com métodos também estáticos
- retorna IServiceCollection
- AddDbContext<>


- Instalar pacote na Camada IoC AutoMapper.Extensions.Microsoft.DI

Nos services, está utilizando apenas a interface no Mapper, para funcionar precisa injetar a dependencia.

- Injetou o Banco de dados na Injeção de Dependencia
- Injetou os Repositórios
- Injetou os Services
- Injetou o AutoMapper


# Criação do Controller de Pessoa

- Criar classe Controladora de requisições: PessoasController
- herdar de ControllerBase
- criar IoC dos serviços de Pessoa

- adicionar apiCOntroller
- adicionar Route

- adicionar verbo http HttpPost
- passar valores por FromBody da requisição





# Criar Métodos Get de Pessoas


- Criar contrato
- Criar implementação do contrato
- busca entidade e retorna DTO.
- converter para DTO