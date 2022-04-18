# ProductSeller (API only) - In progress

Demonstration of DDD architecture with .NET Core 6, MySQL and Docker.

\* This is a WIP project, so still there are many security flaws and bugs.

## Usage
To start the application, just run the following command on the project's root folder:

```bash
docker-compose up
```

**OBS:** Due to unknown error on image creation, some parts of the database creation scripts are not running properly. So, to fix it, one should access the database container manually and execute the following commands:

```bash
# Password requested by mysql here. Use 'dbuserpassword'
mysql -u dbuser -p

# Missing tables creation using the original creation script
source docker-entrypoint-initdb.d/00_SchemaCreation.sql

```

After that, the application API should be available at: **https://localhost:51794**