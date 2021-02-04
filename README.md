*Repositório apenas para estudo*

# Curso: Criando APIs com ASP.NET Core e EF Core (1976)

Neste curso vamos ver uma abordagem diferente na criação de APIs com ASP.NET Core, aprendendo a criar aplicações para cenários mais simples (CRUD Based).

Instrutor:

* [André Baltiéri](https://balta.io)

Referências:

* https://app.balta.io/player/1976
* https://github.com/balta-io/1976

<br>
<br>

**Anotações**

<hr>
<hr>

## Introdução e Configurações do Ambiente

### Aula 01 - Introdução

**Ao término do curso**

- Criar uma API Simples
- Documentar uma API
- Padronizar uma API
- Versionar uma API
- Otimizar uma API
- Escalável
- Pronta para nuvem
  - Agenda:
- Introdução
- Ferramentas
- Configuração:
  - .NET Core
  - Docker
  - SQL Server
  - SQL Server Operations Studio
  - Visual Studio Code
- Modelagem de Dados
- Entity Framework Core (Intrudução)
- Mapeamento Objeto Relacional
- Criação da API
- Adição do MVC
- Rotas e CRUD
- ViewModel
- Fail Fast Validations
- Repository Pattern
- Queries
- Versionamento
- Cache
- Compressão
- Documentação
- Publicação
- Monitoramento

### Aula 02 - Ferramentas

**Ferramentas**

- Windows, Mac ou Linux
- .NET Core
- Docker
- SQL Server
- SQL Server Operations Studio
- Visual Studio Code

### Aula 03 - .NET Core

```sh
dotnet --version
```

### Aula 04 – Docker

- Abstração da infraestrutura
- Execução em contêiners

Dowload do Docker
Criar um DockerID

### Aula 07 – Visual Studio Code

Extensões

- Beaultify
- C#
- ESLint

## Imersão

### Aula 08 - Modelagem de Dados

- Cenário Data-Driven
- Domínios Amênicos
- Cenários mais simples
- CRUDs com facilidade

Criação do projeto

```sh
dotnet new web
```

‘web’ usa o template “ASP.NET Core Empty”

Criar solution

```sh
dotnet new sln
```

Adicionar projeto a solução

```sh
dotnet sln add ProductCatalog.csproj
```

### Aula 09 – Entity Framework Core

- Solução ORM da Microsoft
- Faz o Dê-Para das classes para as tabelas
- Facilita muito a vida do desenvolvedor
- Instalação fácil
- Versão atual
- Mapeamento NxN
- Recursos ainda limitados

Instalação

```sh
dotnet add package Microsoft.EntityFrameworkCore
```

### Aula 10 – Mapeamento Objeto Relacional

Não usarei o SQL Server e sim o PostgreSQL
Instalaçao do PostgreSQL:

```sh
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

Referencia: https://www.npgsql.org/efcore/

Para poder rodar comando no CLI. Adicionar no arquivo `ProductCatalog.csproj`

```xml
<ItemGroup>
  <dotnet CliToolReference Include="Microsoft.EntityFrameworkCore.Tools.dotnet " Version="2.0.1" />
</ItemGroup>
```

Para restaurar todos os pacotes

```sh
dotnet restore
```

Para iniciar a primeira versão do banco de dados através de migrations

```sh
dotnet ef migrations add initial
```

Para executar a migração

```sh
dotnet ef database update
```

Mapear as Entidades para criação das colunas corretamente

- Criar pasta ‘Data/Maps’ e adicionar uma classe para cada entidade. Exemplo: /Data/Maps/CategoryMap.cs

Depois da alteração no banco de dados, versionar uma nova migration

```sh
dotnet ef migrations add v1
```

```sh
dotnet ef database update
```

### Aula 11 – Criando a API

**Criando a API**

- Permite a comunicação entre aplicações
- Concentra as regras de negócio do seu Software
- Necessárias para comunicação com dispositivos móveis
- Utilizada por Gigantes como Facebook, Instagram, Twitter
  ASP.NET Core
- Permite a criação de APIs de forma fácil
- Extremamente performático
- Self-host
- Multiplataforma
- Totalmente modularizado
  Middlewares
- Toda app possui um pipeline
- No ASP.NET ele começa vazio
- O que é adicionado entre o Request/Response são chamados de Middlewares
  Explicação sobre os arquivos /Program.cs e /Startup.cs

### Aula 12 – Adicionando MVC

**MVC**

- Model, View Controller
- Padrão para organização do projeto
- Utilizada por várias linguagens
- Simples e objetivo
- Neste Caso, utilizaremos apenas os Controllers
  - Nossas Models já foram criadas
  - Nossas Views não existirão (Retornos serão JSON)

Adicionar o MVC ao App

```sh
dotnet add pckage Microsoft.AspNetCore.Mvc
```

### Aula 13 – Rotas e CRUD

**Rotas**

- As rotas são importantes
- Pode-se utilizar as rotas e verbos
- Pode-se receber parâmetros pela URL ou Corpo da Requisição
  Verbos
- GET - Cabeçalho penas
- POST - Cabeçalho e corpo
- PUT - Cabeçalho e corpo
- DELETE - Cabeçalho e corpo
  Roteamento
- GET – http://localhost:5000/v1/products/
  - Lista os produtos
- POST – http://localhost:5000/v1/products/
  - Cria um produto
- PUT – http://localhost:5000/v1/products/
  - Atualiza um produto
- DELETE – http://localhost:5000/v1/products/ \* Exclui um produto
  CRUD
- Create, Read, Update e Delete
- Refletem diretamente o GET, POST, PUT e DELETE

**Codificação do Controller**

...

Executar o app

```sh
dotnet run
```

### Aula 14 – ViewModels

**ViewModels**

- Adequação das informações para a “tela”
- Nem sempre, o resultado esperado é um Produto ou uma Categoria
- Pode ser a mescla de ambos
- Pode ter mais ou menos informações
- ViewModel nada mais são do que objetos de transporte
- Entrada/Saída

### Aula 15 - Fail Fast Validations

**Fail Fast Validations**

- Validar e falhar o mais rápido possível
- Valida as ViewModels de entrada
- Armazena todos os “erros”
- Retorna falha antes de prosseguir
- Evita requests desnecessários ao banco e afins
  Flunt
- Pacote para criar validações
- Validação através de contratos
- Testado
- Diversas opções de validação
- Open Source
  Instalar

```sh
dotnet add package Flunt
```

https://github.com/andrebaltieri/flunt
https://github.com/andrebaltieri/flunt/wiki

### Aula 16 – Repository Pattern

Repository Pattern

- Cada entidade/modelo tem seu repositório
- Abstrai o acesso à dados
- Permite a troca da fonte de dados sem afetar o resto do sistema

### Aula 17 – Queries

**Queries**

- LINQ
- Retorna um ViewModel
- Podemos mapear Views
- Podemos mapear Producers
- Podemos executar queries SQL
- Utilizar sempre AsNoTracking

### Aula 18 – Versionamento

**Versionamento**

- A API receberá acesso de diferentes Apps
- Visioná-la auxilia os Apps

### Aula 19 – Cache (Aula 54 do curso 1974)

### Aula 20 – Compression (Aula 55 do curso 1974)

Instalar o pacote para compressão

```sh
dotnet add package Microsoft.AspNetCore.ResponseCompression
```

### Aula 21 – Documentção da API

Instalar o pacote para compressão

```sh
dotnet add package Swashbuckle.AspNetCore
```

http://localhost:5000/swagger

### Aula 22 – Deploy da Applicação na Nuvem

...

### Aula 23 - Monitoramento - (Aula 60 do curso 1974)

...
