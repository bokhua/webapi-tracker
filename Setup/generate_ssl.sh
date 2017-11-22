sudo apt-get install openssl
sudo mkdir -p /etc/ssl/private
sudo mkdir -p /etc/ssl/certs
sudo openssl req -x509 -nodes -days 365 -newkey rsa:1024 -keyout /etc/ssl/private/myssl.key -out /etc/ssl/certs/myssl.crt