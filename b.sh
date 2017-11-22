mkdir -p data
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet build
dotnet publish