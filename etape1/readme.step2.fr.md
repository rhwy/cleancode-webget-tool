
## Etape 2

1. Créez un nouveau répertoire `Students\nom-prenom\nget-v2` dans votre repository.

1. Transcrivez les spécifations sous une forme plus descriptive dans un fichier `specs.txt` que vous laisserez à la racine de ce nouveau répertoire.
   Voici le modèle pour la commande GET avec ses 2 options:

		Feature:  GET
			In order : to see the content of a web page
			as a : shell fan
			I want to download a web page

		Scenario: show the content of a page
			Given : I entered a fake url option `-url "http://fake"`
			And : any other option
			When : I press enter
			Then : the result should be `<h1>hello</h1>`

		Scenario: save the content of a page
			Given : I entered a fake url option `-url "http://fake"`
			And : I enter the option `-save` with the value 'fake.txt'
			When : I press enter
			Then : a file called `fake.txt` should be created with the content `<h1>hello</h1>`
	
	Reportez cet exemple dans le fichier `specs.txt` ainsi que celles pour la commande TEST.

1. Créez un nouveau projet de type librairie pour recommencer le projet

2. Créez un projet de tests

1. Implémentez votre moteur de traitement en le validant pour chaque fonctionalité par des tests en suivant les scénarios des spécifications. Par exemple:

		[Test]
		public void Should_show_the_content_of_a_page()
		{
			//given
			var command = null //votre implémentation

			//when
			var result = command.Show(url); //exemple d'implémentation

			//then

			Assert.That(result, Is.EqualTo("<h1>hello</h1>"))
		}
		
Cet exemple représente la transcription sous forme de code de votre scenario de test, mais vous devrez -très certainement- avoir des tests unitaires intermédiaires.

Faites un commit pour chaque Feature quand test/implémentation sont passés au vert.

1. Faites des recherches sur la meilleure manière d'effectuer le traitement des arguments et prennez la librairie qui vous convient (ou passez vous d'une librairie et faites le à la main si tel est votre choix)

1. Implémentez votre application en prennant en compte les arguments de la ligne de commande et branchez le tout avec votre moteur applicatif

1. En dernier, regardez/recherchez comment télécharger du contenu web et implémentez cela dans votre moteur.


### Notes:

* Pensez à découpler au maximum pour pouvoir tout tester
* Ne soyez pas choqués par avoir l'impression de coder cela dans le sens inverse auquel vous êtes habitués.
* testez finalement avec une vrai url mais uniquement à la fin
* pas de commits, pas de note de participation

### Notes 2:

* pensez à bien commencer par implémenter votre coeur applicatif, la partie du code qui va effectivement aller faire une requete n'arrive qu'à la fin, de même que la partie qui gère les inputs.
* l'historique de vos commits sera regargé pour voir comment vous avez construit votre code.
