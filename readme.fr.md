NGET est un utilitaire en ligne de commande qui permet de voir, télécharger ou afficher des informations à partir d'une url. L'executable sera nommé nget.exe. Il pourra être lancé avec une seule commande à la fois et plusieurs options (comme décrit dans les exemples ci-dessous).

Voici l'ensemble des options disponibles dans l'application:

Affiche dans la console le contenu du fichier sité à l'url abc:

java -jar nget.jar get -url "http://abc"

Sauvegarde le contenu de l'url http://abc dans le fichier c:\abc.json:

java -jar nget.jar get -url "http://abc" -save "c:\abc.json"

Teste le temps de chargement du ficher à l'url http://abc 5 fois et affiche les 5 temps

java -jar nget.jar test -url "http://abc" -times 5

Teste le temps de chargement du fichier à l'url http://abc et affiche la moyenne du temps de chargement

java -jar nget.jar test -url "http://abc" -times 5 -avg
