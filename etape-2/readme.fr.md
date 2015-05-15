# cleancode-webget-tool

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/rhwy/cleancode-webget-tool?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Projet NGET - Spécifications

NGET est un utilitaire en ligne de commande qui permet de voir, télécharger ou afficher des informations à partir d'une url.
L'executable sera nommé `nget.exe`. Il pourra être lancé avec une seule commande à la fois et plusieurs options (comme décrit dans les exemples ci-dessous).


Voici l'ensemble des options disponibles dans l'application:

1. Affiche dans la console le contenu du fichier sité à l'url `abc`:

	nget.exe get -url "http://abc" 


2. Sauvegarde le contenu de l'url `http://abc` dans le fichier `c:\abc.json`:

	nget.exe get -url "http://abc" -save "c:\abc.json"


3. Teste le temps de chargement du ficher à l'url `http://abc` 5 fois et affiche les 5 temps

	nget.exe test -url "http://abc" -times 5 

4. Teste le temps de chargement du fichier à l'url `http://abc` et affiche la moyenne du temps de chargement

	nget.exe test -url "http://abc" -times 5 -avg


## Etape 1

1. Forkez ce repository

1. Créez un répertoire `Students\nom-prenom\nget-v1` dans votre repository projet github.

1. Implémentez le projet de la manière la plus propre possible.

1. Dès que vous avez terminé (ou que le temps imparti touche à sa fin), commitez votre code et effectuez un PR pour signaler que vous avez terminé. 
1. Arrêtez-vous là pour l'instant.



_**Note**_: exemple d'url de test avec du vrai contenu : `http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric`

