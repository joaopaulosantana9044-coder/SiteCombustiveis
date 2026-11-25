# SiteCombustiveis

Site para pesquisar preços de combustíveis.

Projeto desenvolvido para a disciplina **AOP2 ADR - Arquitetura de Dados Relacionais 1**.

## Tecnologias

- C# / .NET 10
- HTML
- CSS
- Docker (deploy no Railway)

## Estrutura do projeto

- `Data/`: acesso e configuração de dados
- `Models/`: modelos de dados da aplicação
- `Pages/`: páginas do site
- `Repositories/`: camada de acesso ao banco de dados
- `Properties/`: configurações de execução
- `wwwroot/`: arquivos estáticos (CSS, imagens, JavaScript)
- `Program.cs`: ponto de entrada da aplicação
- `Dockerfile`: configuração para build e deploy em container

## Como executar localmente

1. Clone o repositório:
   ```bash
   git clone https://github.com/joaopaulosantana9044-coder/SiteCombustiveis.git
   ```
2. Entre na pasta do projeto:
   ```bash
   cd SiteCombustiveis
   ```
3. Execute a aplicação:
   ```bash
   dotnet run
   ```
4. Acesse no navegador o endereço exibido no terminal.

Requisitos: [.NET SDK 10](https://dotnet.microsoft.com/download).

## Deploy

O projeto possui um `Dockerfile` e está preparado para deploy no Railway.

## Autor

João Paulo Santana - [joaopaulosantana9044-coder](https://github.com/joaopaulosantana9044-coder)
