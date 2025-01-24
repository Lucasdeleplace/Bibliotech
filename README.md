# Bibliotech

## Description

Bibliotech est une application web développée en .NET 8 avec Blazor. Elle permet de gérer une bibliothèque, incluant la gestion des livres, des membres et des emprunts.

## Fonctionnalités

- **Gestion des livres** : Ajouter, modifier, afficher et supprimer des livres.
- **Gestion des membres** : Ajouter, modifier, afficher et supprimer des membres.
- **Gestion des emprunts** : Créer, modifier, afficher et supprimer des emprunts.
- **Historique des emprunts** : Afficher l'historique des emprunts d'un membre.
- **Documentation API** : Documentation de l'API avec Swagger.

## Prérequis

- .NET 8 SDK
- Visual Studio 2022

## Installation

1. Clonez le dépôt :
    
git clone https://github.com/Lucasdeleplace/Bibliotech.git

2. Accédez au répertoire du projet :
    
cd bibliotech

3. Restaurez les packages NuGet :
    
dotnet restore

4. Mettez à jour la base de données :

Add-Migration {Nom de la migration}
Update-Database


## Utilisation

1. Lancez l'application :
    
2. Ouvrez votre navigateur et accédez à `https://localhost:8080`.

## Endpoints

### Livres

- `GET /livre` : Afficher tous les livres.
- `GET /livre/{id}` : Afficher un livre par ID.
- `POST /livre` : Ajouter ou modifier un livre.
- `POST /livre/{id}` : Supprimer un livre.

### Membres

- `GET /membre` : Afficher tous les membres.
- `GET /membre/{id}` : Afficher un membre par ID.
- `POST /membre` : Ajouter ou modifier un membre.
- `POST /membre/{id}` : Supprimer un membre.
- `GET /membre/{id}/emprunt` : Afficher l'historique des emprunts d'un membre.

### Emprunts

- `GET /emprunts` : Afficher tous les emprunts.
- `GET /emprunts/{id}` : Afficher un emprunt par ID.
- `POST /emprunts` : Créer ou modifier un emprunt.
- `POST /emprunts/{id}` : Supprimer un emprunt.
- `GET /retourEmprunt/{id}` : Rendre un livre emprunté.

## Documentation API

La documentation de l'API est disponible via Swagger. Pour y accéder, lancez l'application en mode développement et accédez à `https://localhost:8080/swagger`.