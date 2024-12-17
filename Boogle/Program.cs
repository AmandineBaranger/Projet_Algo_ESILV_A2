// See https://aka.ms/new-console-template for more informationusing System;

using Boogle;

class Program
{
    static void Main()
    {
        
        
        
         try
            {
                // Initialisation des variables
                Random random = new Random();
                string cheminFichierPonderation = "Lettres.txt";
                // Charger les points des lettres
                De.ChargerPointsParLettre(cheminFichierPonderation);

                string cheminDictionnaire = "";

                // Choix de la langue pour le dictionnaire
                string langueChoisie = "";
                while (langueChoisie != "FR" && langueChoisie != "EN")
                {
                    Console.Write("Choisissez la langue du dictionnaire (FR/EN) : ");
                    langueChoisie = Console.ReadLine().ToUpper();
                }

                // Chemin du fichier dictionnaire en fonction de la langue choisie
                if (langueChoisie == "FR")
                {
                    cheminDictionnaire = "MotsPossiblesFR.txt";
                }
                else if (langueChoisie == "EN")
                {
                    cheminDictionnaire = "MotsPossiblesEN.txt";
                }

                // Création du dictionnaire
                Dictionnaire dictionnaire = new Dictionnaire(langueChoisie, cheminDictionnaire);

                // Saisie du nombre de joueurs
                Console.Write("Entrez le nombre de joueurs : ");
                int nombreJoueurs = int.Parse(Console.ReadLine());

                // Saisie des noms des joueurs
                List<string> nomsJoueurs = new List<string>();
                for (int i = 0; i < nombreJoueurs; i++)
                {
                    Console.Write($"Nom du joueur {i + 1} : ");
                    nomsJoueurs.Add(Console.ReadLine());
                }

                // Saisie de la taille de la grille
                Console.Write("Entrez la taille de la grille (ex : 4 pour une grille 4x4) : ");
                int tailleGrille = int.Parse(Console.ReadLine());

                // Configuration du temps
                Console.Write("Entrez le temps total de la partie en minutes : ");
                int tempsTotalMinutes = int.Parse(Console.ReadLine());

                Console.Write("Entrez le temps par round en minutes : ");
                int tempsParRoundMinutes = int.Parse(Console.ReadLine());

                // Initialisation des scores
                Dictionary<string, int> scores = new Dictionary<string, int>();
                foreach (var joueur in nomsJoueurs)
                {
                    scores[joueur] = 0;
                }

                // Début de la partie
                DateTime debutPartie = DateTime.Now;
                TimeSpan tempsTotal = TimeSpan.FromMinutes(tempsTotalMinutes);

                Console.WriteLine("\n--- Début du jeu ! ---");

                bool finDePartie = false;

                while (!finDePartie)
                {
                    foreach (var joueur in nomsJoueurs)
                    {
                        if (DateTime.Now - debutPartie >= tempsTotal)
                        {
                            finDePartie = true;
                            break;
                        }

                        // Création du plateau 
                        Plateau plateau = new Plateau(random,cheminFichierPonderation, tailleGrille);
                        Console.WriteLine($"\n--- Tour de {joueur} ---");
                        Console.WriteLine(plateau.toString());

                        HashSet<string> motsTrouves = new HashSet<string>();
                        DateTime debutRound = DateTime.Now;
                        TimeSpan tempsParRound = TimeSpan.FromMinutes(tempsParRoundMinutes);

                        while (DateTime.Now - debutRound < tempsParRound)
                        {
                            Console.Write("Entrez un mot (ou 'fin' pour terminer votre tour) : ");
                            string mot = Console.ReadLine().ToUpper();

                            if (mot == "FIN") break;

                            bool presentSurPlateau = plateau.Test_Plateau(mot);
                            bool presentDansDico = dictionnaire.RechDichoRecursif(mot, langueChoisie, 0, dictionnaire.ListeMots.Count - 1);

                            if (presentSurPlateau && presentDansDico)
                            {
                                if (!motsTrouves.Contains(mot))
                                {
                                    motsTrouves.Add(mot);

                                    // Calculer les points du mot en utilisant les lettres pondérées
                                    int points = De.CalculerPointsMot(mot);
                                    scores[joueur] += points;

                                    Console.WriteLine($"✅ Mot valide ! Vous gagnez {points} points.");
                                }
                                else
                                {
                                    Console.WriteLine("❌ Mot déjà trouvé !");
                                }
                            }
                            else
                            {
                                Console.WriteLine("❌ Mot invalide.");
                            }
                        }
                        Console.WriteLine($"⏳ Fin du tour de {joueur}. Score actuel : {scores[joueur]} points.");
                    }
                }

                // Affichage des résultats
                Console.WriteLine("\n--- Fin de la partie ! ---");
                foreach (var joueur in scores)
                {
                    Console.WriteLine($"{joueur.Key} : {joueur.Value} points");
                }

                // Détermination du gagnant
                string gagnant = null;
                int meilleurScore = 0;
                foreach (var joueur in scores)
                {
                    if (joueur.Value > meilleurScore)
                    {
                        gagnant = joueur.Key;
                        meilleurScore = joueur.Value;
                    }
                }

                Console.WriteLine($"\n🎉 Le gagnant est {gagnant} avec {meilleurScore} points ! 🎉");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
    }
}

