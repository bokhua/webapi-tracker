mkdir -p data
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet build
dotnet publish
sudo cp -rf ./Setup/nginx_site /etc/nginx/sites-available/default
mkdir -p /var/aspnetcore/webapi
sudo cp -rf ./bin/Debug/netcoreapp2.0/publish/* /var/aspnetcore/webapi
sudo cp -rf ./Setup/kestrel-mvc.service /etc/systemd/system/kestrel-mvc.service