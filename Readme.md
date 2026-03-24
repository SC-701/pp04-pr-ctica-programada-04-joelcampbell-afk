# Autorizacion. Middleware

Middleware de ASP.NET Core 8 que consulta los perfiles (roles) del usuario
autenticado en la base de datos de seguridad y los agrega como 'Claim'
al 'HttpContext.User'.

#l@ Paso 1 - Configurar el feed de GitHub Packages (una sola vez por maquina)

Crea un PAT en tu cuenta GitHub con scope 'read:packages', luego ejecuta:

'"*powershell
dotnet nuget add source https://nuget.pkg.github.com/SC-701/index. jmon
-- name github '
== username TU USUARIO GITHUB '
-- pasaword TU PERSONAL ACCESS TOKEN '
-= atore-pasaword-in-clear-text