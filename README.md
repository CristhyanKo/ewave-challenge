# Ewave Challenge - Bibliotech - Livre para Todos

Desafio feito pela empresa Ewave, para avalição de conhecimento.

Está aplicação foi desenvolvida com .NET Core e React, o backend foi feito em formato de API utilizando a arquitetura de DDD (DomainDriver Design) fazendo o máximo de abstrações para fácil manutenção e crescimento do código, já o FrontEnd foi feito utilizando React, separando uma camada de service com AXIOS para consumo da API criada.

![Imagem](https://image.prntscr.com/image/148jVvs8Qz_7fdlfK1sT2w.png)

## Como usar

Pré requisitos

- [MySql](https://mariadb.org/)
- [Node.js](https://nodejs.org/en/)
- [Visual Studio 2017 ou Visual Studio Code](https://visualstudio.microsoft.com/)
- [DotNet Core](https://dotnet.microsoft.com/download)

Baixe este repositório
Acesse a pasta de onde foi baixado o seu projeto por um terminal

```bash
cd Bibliotech
```

Acesse a pasta do WebApp e instale as dependências

```bash
npm install
```

Acesse a pasta da API pelo explorer e abra a solução no Visual Studio 2017

## Dados do banco de dados

- MySql - Maria DB
- host: localhost
- user: root
- password: 1234

## Possivel correção de problemas

Caso o FrontEnd venha a apenas ficar carregando, verifique se a API está rodando, e verifique a porta na qual ela está rodando.
Compare com a url de acesso a api que esta no arquivo _Bibliotech.WebApp\src\services\api.js_
