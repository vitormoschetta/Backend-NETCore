## Início Rápido:

Podemos executar este aplicativo rapidamente de duas formas:

### 1. Com Docker

Não existe forma mais simples de executar qualquer aplicação, em qualquer ambiente.

Se ainda não possui o Docker instalado segue o link:

<https://www.docker.com/products/docker-desktop/>

<br>

Na raiz do projeto executar o comando docker:
```
docker-compose up -d --build
```

<br>

Pode demorar alguns minutos, pois se você ainda não tiver as imagens do SDK .NET 5.0 na máquina, o Docker tratará de fazer o download.

Ao terminar o processo esta aplicação estará disponivel localmente na seguinte url:

<http://localhost:6060/index.html>




<br>
<br>

### 2. Com SDK .NET Core

Se não quiser usar o Docker vocẽ pode optar por executar no próprio _host_, mas precisará do SDK .NET 5.0 ou superior.

Se ainda não possui o .NET SDK instalado, segue o link:   

<https://dotnet.microsoft.com/download>


<br>

Com o SDK .NET Core instalado podemos executar os seguinte comandos, a partir do diretório **_Source/Api/_**:

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

http://localhost:5050/index.html

ou:

https://localhost:5051/index.html




<br>
<br>

---


# Arquitetura DDD

Nosso projeto de backend está dividido em três partes principais, mais a camada de testes:

###### dotnet new webai
```
Api
```

###### dotnet new classlib netstandar2.1
```
Domain
Infra
```

###### dotnet new mstest
```
Tests
```


### Referências entre as camadas

- **Infra** faz referência ao **Domain**  
- **Api** faz referência ao **Domain** e **Infra**  
- **Test** faz referência ao **Domain**  




<br>
<br>

--- 

# ORM

Este projeto utiliza o ORM Entity Framework Version="5.0.5".

<br>
<br>


# Base de Dados

Neste projeto estamos utilizando o banco de dados MS SqlServer. Podemos mudar para qualquer outra banco de dados que tenha suporte ao Entity Framework de forma rápida e fácil.


### Migrations 

As Migrations são geradas a partir do diretório **Source/Api/**.

Para que a pasta Migrations fique localizada na camada '**Infra** (seria o correto)', é preciso especificar executando o seguinte comando:
```
dotnet ef migrations add inity --project ../Infra/Infra.csproj
```

Para gerar a base de dados use o seguinte comando:
```
dotnet ef database update
```

<br>

**Detalhe**: Se for utilizar o docker para instanciar um container da aplicação, saiba que a criação e inicialização do banco de dados já está configurada.

