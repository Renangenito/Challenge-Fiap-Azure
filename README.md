Link do repositório:
https://github.com/Renangenito/Challenge-Fiap-Azure


# Challenge-Fiap-Azure


O projeto foi todo implementado em arquitetura de camadas, contendo o projeto Web MVC, e o projeto Web API, projeto Negocio com as interfaces, projeto Infra com a parte de conexão com o banco, projeto common só para compartilhar a string da Web API, e o projeto models copm as modelos.

### Rodar o projeto

Foi utilizado o Entity Framework, para rodar precisa colocar o Projeto API como principal através do "Set as Startup Project" no Visual Studio, e no "Package Manager Console" precisa
selecionar o projeto de Infra como default, e então fazer os seguintes comandos: **Add-Migration mensagemMigracao** para criar a migração e depois **Update-Database** para criar o banco.

Para o banco foi utilizado o **SQL Server**

Precisa startar a API e o projeto Web.

O Projeto salva os dados do Cliente no banco, no caso O Nome e o Email, já a Imagem é salva no Blob Storage.

**OBS:** A string de conexão está no arquivo "ServicoExtensoes" dentro da pasta "Extensoes" no projeto API.

Para salvar a imagem no Blob Storage foi criado um container com nome de dados.

# Pages
## Swagger
![image](https://github.com/Renangenito/Challenge-Fiap-Azure/assets/77756047/c4cbef60-8b32-404a-bd79-da658986de80)

## Início
![image](https://github.com/Renangenito/Challenge-Fiap-Azure/assets/77756047/cd5e7191-06c0-417d-9628-5a9c28f5f915)

## Cadastro
![image](https://github.com/Renangenito/Challenge-Fiap-Azure/assets/77756047/46c8a5df-8c52-4031-8331-64dada36bf8b)

## Clientes
![image](https://github.com/Renangenito/Challenge-Fiap-Azure/assets/77756047/b2cea00e-fcc4-4ebd-b84e-aba6003323e3)


# Algumas tecnologias usadas nesse projeto:
* C# .NET 
* SQL Server
* Entity Framework
