# BDSA2021-ProjectBank

$password = New-Guid
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=$password" -p 1433:1433 -d mcr.microsoft.com/azure-sql-edge:latest
$database = "ProjectBank"
$connectionString = "Server=localhost;Database=$database;User Id=sa;Password=$password"
dotnet user-secrets set "ConnectionStrings:ProjectBank" "$connectionString" --project .\Server\
cd .\Infrastructure\
dotnet ef migrations add InitialMigration -s ..\Server\
dotnet ef database update -s ..\Server\
cd ..
dotnet run --project .\Server\


