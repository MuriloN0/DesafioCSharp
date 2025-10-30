# Desafio C# Back-End - MURALIS

Este projeto é uma solução para o Desafio C# proposto pela [MURALIS](https://www.muralis.com.br/), focado em medir capacidades técnicas para requisitos back-end usando C# e a plataforma .NET Core.

## 1. Objetivo do Desafio

O objetivo principal é criar uma API RESTful para permitir o gerenciamento completo de Clientes, incluindo as operações de cadastramento, consulta, exclusão, listagem, pesquisa e alteração.

## 2. Modelagem de Dados

A solução segue a modelagem de dados proposta, que inclui as seguintes entidades:

* **Cliente**
    * `Id: int`
    * `Nome: String`
    * `DataCadastro: String`
* **Contato** (Um cliente pode ter vários contatos)
    * `Id: int`
    * `Tipo: String`
    * `Texto: String`
* **Endereco** (Um cliente possui um endereço)
    * `Cep: String`
    * `Logradouro: String`
    * `Cidade: String`
    * `Numero: String`
    * `Complemento: String`

## 3. Stack Tecnológica e Requisitos

A API foi construída utilizando as seguintes tecnologias e padrões, conforme solicitado:

* **.NET Core** como framework principal.
* **Entity Framework** para o ORM e comunicação com o banco de dados (MySQL).
* **API RESTful** como arquitetura de comunicação.
* **DTOs (Data Transfer Objects)** para separar os modelos de dados internos dos modelos de API.
* **AutoMapper** para realizar o mapeamento entre Entidades e DTOs.
* **Injeção de Dependência** para gerenciar serviços, como o `ViaCepService`.

## 4. Regra de Negócio Principal

A regra de negócio mais importante do desafio foi implementada:

> Ao receber o CEP do cliente (durante o cadastro ou alteração), a API consulta automaticamente uma API externa (ViaCEP) para adquirir os dados de `Logradouro` e `Cidade`. Esses dados adquiridos pela API são os que são registrados no banco de dados, garantindo a consistência dos endereços.

## 5. Como Testar

### Pré-requisitos

1.  **.NET SDK:** (O projeto foi construído com a versão 7.0.7)
2.  **Banco de Dados:** Um servidor MySQL usado.
3.  **Configuração:** Antes de rodar, atualize a `ConnectionStrings` no arquivo `appsettings.json` com os dados do seu banco MySQL (usuário, senha, nome do banco).

### Rodando a Aplicação

1.  Clone este repositório.
2.  Abra um terminal na pasta raiz do projeto.
3.  Rode `dotnet restore` para baixar as dependências.
4.  Rode `dotnet ef database update` para aplicar as migrations e criar as tabelas no seu banco.
5.  Rode `dotnet run` para iniciar a API.
6.  O terminal indicará a URL (ex: `http://localhost:5048`).

### Testando com Postman

A API estará disponível na URL indicada (ex: `http://localhost:5048/`).

| Verbo | Endpoint | Descrição |
| :--- | :--- | :--- |
| `POST` | `/api/clientes` | **Cadastra** um novo cliente. (Veja o JSON de exemplo abaixo) |
| `GET` | `/api/clientes` | **Lista** todos os clientes cadastrados. |
| `GET` | `/api/clientes/{id}` | **Consulta** um cliente específico pelo seu ID. |
| `DELETE` | `/api/clientes/{id}` | **Exclui** um cliente pelo seu ID. |
| `PUT` | `/api/clientes/{id}` | **Altera** os dados de um cliente. |

---

### Exemplo de JSON para `POST /api/clientes`

Use o método `POST` com o seguinte `JSON` no "body" da requisição.

```json
{
  "nome": "Pedro da Silva (Teste)",
  "endereco": {
    "cep": "01001000",
    "numero": "123",
    "complemento": "Apto 45"
  },
  "contatos": [
    {
      "tipo": "Email",
      "texto": "joao.teste@email.com"
    },
    {
      "tipo": "Telefone",
      "texto": "11912345678"
    }
  ]
}
