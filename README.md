# Backend-NETCore

## Início Rápido:

Podemos executar este aplicativo rapidamente de duas formas:

### 1. Com Docker

Não existe forma mais simples de executar qualquer aplicação, em qualquer ambiente.

Se ainda não possui o Docker instalado segue o link:

<https://www.docker.com/products/docker-desktop/>

<br>

Na raiz do projeto executar o comando docker:
```
docker-compose up -d
```

<br>

Pode demorar alguns minutos, pois se você ainda não tiver as imagens do SDK .NET Core 3.1 na máquina, o Docker tratará de fazer o download.

Ao terminar o processo esta aplicação estará disponivel localmente na seguinte url:

<http://localhost:5000/index.html>




<br>
<br>

### 2. Com SDK .NET Core

Se não quiser usar o Docker vocẽ pode optar por executar no próprio _host_, mas precisará do SDK .NET Core 3.1 ou mais atual.

Se ainda não possui o .NET Core SDK instalado, segue o link:   

<https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31>


<br>

Com o SDK .NET Core instalado podemos executar os seguinte comandos (a partir do diretório "_src/Api/_"):

### Restaurar pacotes
```
dotnet restore
```
<br>

### Execute a Aplicação:
```
dotnet run
```

<br>

Se tudo ocorreu como esperávamos, a seguinte URL ficará disponível:   

http://localhost:5000/index.html

ou:

https://localhost:5001/index.html




<br>
<br>

---


# Arquitetura DDD

Nosso projeto de backend está dividido em três partes principais, mais a camada de testes:

###### dotnet new webai
```
Api
```

###### dotnet new classlib
```
Domain
Infra
```

###### dotnet new mstest
```
Tests
```

<br>

### Referências entre as camadas

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








