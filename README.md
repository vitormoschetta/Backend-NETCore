# Backend-NETCore
###### Estrutura backend .NET Core simples e ao mesmo tempo robusta.  
###### Arquitetura DDD.  
###### API com Documentação do Swagger.  
###### Testes de Unidade.  


## Início Rápido:

Se ainda não possui o .NET Core SDK instalado, segue o [link](https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31) de suporte a instalação. 
Obs: instale a versão 3.1


#### Restarure os pacotes utilizados no projeto, usando o seguinte comando CLI na pasta onde está a Solution (Backend.sln):
```
dotnet restore
```

#### Execute a Aplicação:
Na pasta 'Api' execute o comando CLI:
```
dotnet run
```

Se tudo ocorreu bem, a seguinte URL ficará disponível:  
http://localhost:5000





## Tipos de projetos utilizados:

###### WebApi:
```
Api
```

###### Classlib:
```
Domain
Infra
```

###### Mstest:
```
Tests
```
Testes de unidade.


#### Comandos CLI usados na criação dos projetos:
```
dotnet new webapi
dotnet new classlib
dotnet new mstest 
```

#### Adicionado uma solução na raiz: 
```
dotnet new sln
```
'Backend.sln'


#### Adicionar referência entre os domínios:

- **Infra** faz referência ao **Domain**  
- **Api** faz referência ao **Domain** e **Infra**  
- **Test** faz referência ao **Domain**  



## Migrations
As Migrations são geradas a partir do projeto 'Api'.  

Para que a pasta Migrations fique localizada na camada 'Infra', é preciso especificar ao executar o comando:
```
dotnet ef migrations add <NomeDaMigration> --project ../Infra/Infra.csproj
```

Obs: As migrations já foram geradas, mas fique a vontade para excluir e gerar novamente.

## Data Base
Estamos utilizando banco de dados embarcado SQLite. Logo, os dados necessários já estão disponíveis no arquivo 'DataBase.db' localizado raíz do repositório.

Obs: Fique a vontade para excluir e gerar um novo banco de dados, segue o comando que deve ser executado no projeto 'Api':
```
dotnet ef database update
```





