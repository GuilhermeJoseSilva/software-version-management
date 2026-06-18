# SoftwareManagement API

API REST para gestão de softwares e suas versões, desenvolvida em C# com .NET 10, EF Core e PostgreSQL.

## Como clonar e executar

```bash
https://github.com/GuilhermeJoseSilva/software-version-management.git
cd SoftwareManagement
docker compose up -d
```

A aplicação aplica as migrations automaticamente na inicialização. Não é necessário rodar nenhum comando de banco manualmente.

API disponível em `http://localhost:8080`.

## Como parar

```bash
docker compose down
```

## Como testar os endpoints

O arquivo `SoftwareManagement.http`, na raiz do projeto, contém todas as requisições prontas (criar, listar, buscar, atualizar e excluir, tanto de Software quanto de Versão). Basta abrir esse arquivo no VS Code (com a extensão REST Client) ou no Visual Studio/Rider, e clicar em "Send Request" em cada bloco.

A especificação da API também pode ser consultada em `http://localhost:8080/openapi/v1.json`.

## Modelagem

Foi identificada uma relação de 1 Software para N Versões: cada Software pode ter várias versões ao longo do tempo, e cada versão pertence a um único Software.

```
Software
├── Id
├── Nome
├── Fornecedor
└── DataCriacao

Versao
├── IdVersao
├── SoftwareId (FK)
├── Descricao
├── DataRelease
└── Depreciado
```

O campo `Depreciado` é informado manualmente em cada versão, sem nenhuma regra automática, o enunciado não pede esse comportamento, então cada versão pode ser marcada como depreciada ou não, de forma independente das demais.

A exclusão de um Software é física e em cascata: excluir um Software remove também todas as suas versões vinculadas.

## Arquitetura

O projeto é dividido em camadas, dentro de uma única solution:

```
Controllers/    → recebe as requisições HTTP
Application/    → regra de negócio (Services) e contratos de entrada/saída (DTOs)
Data/           → acesso ao banco (DbContext, Configurations, Repositories)
Domain/         → entidades puras, sem dependência de EF Core ou ASP.NET
Migrations/     → histórico de schema do banco
```

Essa separação foi escolhida pra manter baixo acoplamento entre as camadas: o Domain não sabe como é salvo no banco, o Service não sabe como o dado chega via HTTP, e o Repository é a única camada que conversa diretamente com o EF Core. Isso facilita trocar qualquer peça (banco, framework de API) sem precisar reescrever o resto.

## Por que só EF Core

 Neste projeto, optei por usar apenas EF Core: o cenário é um CRUD simples, sem volume de dados e sem consultas complexas que justifiquem uma camada de leitura otimizada separada. Dapper resolve um problema de performance em leitura que não existe nesse escopo, então usá-lo aqui seria adicionar uma tecnologia sem necessidade real, em vez de resolver um problema concreto.

## Docker

O `docker-compose.yml` sobe dois containers: o banco PostgreSQL e a API. A API só inicia depois que o banco estiver de fato pronto para aceitar conexões (configurado via healthcheck), evitando erro de conexão na inicialização.
