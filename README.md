# Ambiente de desenvolvimento com VSCode e Docker

Baixar o remote debugger para VSCode:

```ps1
powershell -NoProfile -ExecutionPolicy unrestricted -Command "[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12; &([scriptblock]::Create((Invoke-WebRequest -useb 'https://aka.ms/getvsdbgps1'))) -Version vs2019 -RuntimeID linux-x64 -InstallPath ~\.vsdbg\"
```

Clique, com o botão direito, no arquivo `docker-compose.debug.yml` e escolha a opção `Compose Up`, para iniciar os containeres.

Execute as migrations:

```ps1
dotnet ef database update --connection "Host=localhost;Port=5432;Database=becomex_platform_dev;User ID=postgres;Password=admin;" -p .\src\Bcx.Platform.EntityFrameworkCore.DbMigrations\Bcx.Platform.EntityFrameworkCore.DbMigrations.csproj
```

No arquivo `src\Bcx.Platform.HttpApi.Host\appsettings.json`, substitua a connection string Default remota, pela localhost:

```
    "Default": "Host=localhost;Port=5432;Database=becomex_platform_dev;User ID=postgres;Password=admin;"
    //"Default": "Server=172.21.7.98;Port=5432;Database=becomex_platform_dev;User Id=becomex_platform_dev@bcx-postgres-dev01;
```

Inicie a depuração, com a configuração `.NET Core Docker Attach (Preview).`, escolhendo as opções `bcx-platform-server` e `bcxplatformhttpapihost`.

Acesso a API no navegador, através do endereço http://localhost:5000/.

## Referências

[Offroad Debugging of .NET Core on Linux OSX from Visual Studio](https://github.com/microsoft/MIEngine/wiki/Offroad-Debugging-of-.NET-Core-on-Linux---OSX-from-Visual-Studio)

[VScode debug using docker-compose](https://code.visualstudio.com/docs/containers/docker-compose)