#!/bin/bash
set -e

[[ $DEBUG == true ]] && set -x

ls
service mysql start
mysql -u root -e "GRANT ALL PRIVILEGES ON *.* TO 'dbuser'@'localhost' IDENTIFIED BY 'dbuserpassword'"
dotnet build
dotnet run --project AddressBook.WebApi
