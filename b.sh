sudo service nginx stop
sudo systemctl stop kestrel-mvc.service
sudo mkdir -p /var/aspnetcore/webapi
sudo mkdir -p data
sudo cp -rf /var/aspnetcore/webapi/data/* ./data

dotnet restore 
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet publish

sudo cp -rf ./Setup/nginx_site /etc/nginx/sites-available/default
sudo cp -rf ./bin/Debug/netcoreapp2.0/publish/* /var/aspnetcore/webapi
sudo cp -rf ./Setup/kestrel-mvc.service /etc/systemd/system/kestrel-mvc.service
sudo systemctl enable kestrel-mvc.service
sudo systemctl start kestrel-mvc.service
sudo service nginx start