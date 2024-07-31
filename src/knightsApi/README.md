# Knights API

Este projeto é uma API de exemplo construída com C# e .NET 8, seguindo a arquitetura hexagonal. A API permite gerenciar cavaleiros com operações CRUD básicas.

## Tecnologia

## Estrutura do Projeto

- **Knights.Core**: Contém entidades e interfaces de repositórios.
- **Knights.Application**: Contém serviços e casos de uso.
- **Knights.Infrastructure**: Implementações de repositórios.
- **Knights.API**: Controladores e endpoints.
- **Knights.Tests**: Testes unitários.

## Endpoints

- **GET** `/knights`: Retorna todos os cavaleiros.
- **GET** `/knights?filter=heroes`: Retorna cavaleiros filtrados.
- **GET** `/knights/{id}`: Retorna um cavaleiro por ID.
- **POST** `/knights`: Adiciona um novo cavaleiro.
- **PUT** `/knights/{id}`: Atualiza um cavaleiro existente.
- **DELETE** `/knights/{id}`: Exclui um cavaleiro.

## Configuração

1. Clone o repositório:
    ```sh
    git clone https://github.com/seu-usuario/knights-api.git
    cd knights-api
    ```

2. Restaure os pacotes:
    ```sh
    dotnet restore
    ```

3. Execute os testes:
    ```sh
    dotnet test
    ```

4. Execute a aplicação:
    ```sh
    dotnet run --project Knights.API
    ```

## Contribuição

Sinta-se à vontade para contribuir com melhorias ou novos recursos!

## Licença

Este projeto está licenciado sob a licença MIT.