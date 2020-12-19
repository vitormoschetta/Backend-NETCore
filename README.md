# Backend-NETCore
###### Estrutura backend .NET Core simples e ao mesmo tempo robusta.  
###### Arquitetura DDD.  
###### API com Documentação do Swagger.  
###### Testes de Unidade.  
###### Arquivo Dockerfile pronto para publicar API no Heroku.


---


# Início Rápido:

Se ainda não possui o .NET Core SDK instalado, segue o link de suporte a instalação:   
[link](https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31)  

Obs: instale a versão 3.1


Seguimos com comandos CLI utilizados:

### Restaurar pacotes:
```
dotnet restore
```

### Execute a Aplicação:
Na pasta 'Api' execute o comando CLI:
```
dotnet run
```

Se tudo ocorreu bem, a seguinte URL ficará disponível:   
http://localhost:5000

Para acessar a documentação da API:  
http://localhost:5000/index.html



---



# Tipos de projetos utilizados:

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
Para testes de unidade


---


# Comandos CLI usados na criação dos projetos:
```
dotnet new webapi
dotnet new classlib
dotnet new mstest 
```

### Adicionado uma solução na raiz: 
```
dotnet new sln
```
'**Backend.sln**'


### Adicionar referência entre os domínios:

- **Infra** faz referência ao **Domain**  
- **Api** faz referência ao **Domain** e **Infra**  
- **Test** faz referência ao **Domain**  


--- 


# Migrations
As Migrations são geradas a partir do projeto '**Api**'.  

Para que a pasta Migrations fique localizada na camada '**Infra**', é preciso especificar ao executar o comando:
```
dotnet ef migrations add <NomeDaMigration> --project ../Infra/Infra.csproj
```

Obs: As migrations já foram geradas, mas fique a vontade para excluir e gerar novamente. Só observe que para gerá-las novamente
é necessário modificar os seguintes arquivos:

```
**Api**
   Configurations

    -->  services.AddDbContext<AppDbContext>(options =>
               options.UseInMemoryDatabase(Settings.ConnectionString()));               
```
Altere '**UseInMemoryDatabase**' para '**UseSqlite**':  

Faça a mesma coisa em:
```
**Infra***
    Context
       AppDbContext

       --> options.UseInMemoryDatabase(Settings.ConnectionString());
```






