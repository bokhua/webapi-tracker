mkdir -p data
dotnet restore
dotnet ef migrations InitialCreate
dotnet ef database update
dotnet build
dotnet publish