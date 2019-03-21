Prerequisites:
1. Node.js
2. 

install Ng cli:


in a command window, navigate to: DrSys\DrSys, then run following command:

//Create SQLite database:
dotnet ef migrations add CreateDatabase

//Remove SQLite database:
dotnet ef migrations remove

//Drop SQLite database:
dotnet ef database drop

//Remove a SQLite migration
dotnet ef migrations remove


install Ng cli:
in a command window, navigate to: DrSys\DrSys\ClientApp, then run:

Download SQLite borwser from, if visually examine SQLite DB is needed from an IDE:
http://sqlitebrowser.org/dl/


in Visual Studio,
go to Package Manager Console,
run: add-migration Initial_Migration
then run: update-database
