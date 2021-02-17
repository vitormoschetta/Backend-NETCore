# Backend-NETCore

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
Na pasta '**Api**' execute o comando CLI:
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


# Base de Dados

## InMemroy

Estamos utilizando dados em memória (Entity Framework Core InMemory). Você pode aproveitar todo o poder do Entity Framework e conectar a sua
base de dados preferida.


## SQLite

Neste Projeto o acesso ao SQLite já está configurado. Basta alterar / comentar o código abaixo referenciado:

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


### Migrations 

As Migrations são geradas a partir do projeto '**Api**'.  

Para que a pasta Migrations fique localizada na camada '**Infra**', é preciso especificar ao executar o comando:
```
dotnet ef migrations add <NomeDaMigration> --project ../Infra/Infra.csproj
```

Para gerar a base de dados use o seguinte comando:
```
dotnet ef database update
```


Obs: Se você trocar as configurações para usar o **SQLite**, saiba que tanto as **Migrations** quanto a base de dados **já foram Gerados**.
Mas fique a vontade para excluir e gerar novamente. 








