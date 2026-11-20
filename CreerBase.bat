@echo off
chcp 65001 >nul
echo === Creation de la base de donnees GestionAchats.db ===
cd /d "%~dp0GestionAchats"

echo.
echo [1/3] Installation de l'outil dotnet-ef...
dotnet tool install --global dotnet-ef >nul 2>&1 || dotnet tool update --global dotnet-ef

echo.
echo [2/3] Creation de la migration...
if not exist Migrations (
    dotnet ef migrations add InitialCreate
) else (
    echo Le dossier Migrations existe deja, etape ignoree.
)

echo.
echo [3/3] Creation / mise a jour de la base...
dotnet ef database update

echo.
echo Termine. Si aucune erreur rouge n'apparait, lancez l'application depuis Visual Studio (F5).
pause
