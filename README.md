#       Dockerisert Applikasjon

Dette prosjeketet består av 
- Nginx som reverse proxy
- .NET API (C# med Entity Framework Core)
- MySQL database for lagring av brukere 

Forutsetninger - Før du starter må følgende være installert på din maskin: 
- Docker
- Docker compose
- Git (valgfritt, men anbefalt)

# Kjøre prosjeketet
1. Klon repoet fra GitHub
git clone https://github.com/CSolberg/docker-prosjekt.git
cd docker-prosjekt

Eller hvis du bare vil laste ned docker-compose.yml, bruk:
curl -O https://raw.githubusercontent.com/CSolberg/docker-prosjekt/main/docker-compose.yml

2. Start alle containere
Med docker compose:
docker compose up -d
Dette starter MySQL (mysql_container), API (api_container) og NGINX (nginx_container) 

3. Test at alt fungerer
Sjekk om API-et kan koble til databasen:
    curl -X GET http://localhost:8080/test-db
Skal returnere: "Database connection successful!"

Opprett en bruker:
    curl -X POST http://localhost:8080/users \
        -H "Content-Type: application/json" \
        -d '{"name": "Christine"}'
Skal returnere: 
{"id":1,"name":"Christine"}

Hente alle brukere:
    curl -X GET http://localhost:8080/users
Skal returnere:
[{"id":1,"name":"Christine"}]

4. Stoppe og slette containerene
Stoppe:
    docker compose down
For å stoppe og slette all data:
    docker compose down -v

