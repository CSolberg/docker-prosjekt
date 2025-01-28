#       Dockerisert Applikasjon

Dette prosjeketet består av 
- Nginx som reverse proxy
- .NET 8 REST API
- MySQL database

Forutsetninger - Før du starter må følgende være installert på din maskin: 
- Docker
- Docker compose
- Git (valgfritt, men anbefalt)

# Installasjon og kjøring
1. Klon repoet (hvis du bruker GitHub):
git clone https://github.com/dittbrukernavn/docker-prosjekt.git
cd docker-prosjekt
2. Start prosjektet med Docker Compose: 
docker compose up -d
3. Sjekk at alle containere kjører
docker ps
4. Test API-et vi CURL eller en nettleser
curl -X GET http://localhost:8080/users
5. Swagger UI er tilgengelig her:
Åpne nettleseren og gå til: http://localhost:8080/swagger

# API
    Metode  Endepunkt   Beskrivelse
    GET     /users      Henter alle brukere
    POST    /users      Oppretter en ny bruker
    GET     /test-db    Tester databaseforbindelse

- Legg til en bruker: 
curl -X POST http://localhost:8080/users -H "Content-Type: application/json" -d '{"name": "Ditt Navn"}'
- Hent alle brukere:
curl -X GET http://localhost:8080/users
- Test databaseforbindelse
curl -X GET http://localhost:8080/test-db

# Docker hub
Dette prosjektet bruker et ferdig bygget Dockerimage fra Docker Hub
Docker hub repository: christiine/myapi
For å hente og kjøre det siste imaget manuelt:
1. docker pull christiine/myapi:latest
2. docker run -p 5000:5000 christiine/myapi:latest

# Struktur
docker-prosjekt/
│── api/
│   ├── MyApi/
│   │   ├── Program.cs
│   │   ├── AppDbContext.cs
│   │   ├── User.cs
│   │   ├── MyApi.csproj
│   │   ├── appsettings.json
│   │   ├── Dockerfile
│── docker-compose.yml
│── nginx.conf
│── README.md  <-- Denne filen


