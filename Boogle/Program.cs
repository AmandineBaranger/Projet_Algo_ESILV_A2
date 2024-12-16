// See https://aka.ms/new-console-template for more informationusing System;

using Boogle;

class Program
{
    static void Main()
    {
        // Create a 6-element array to store the characters 
        char[] charArray = new char[6];
        // Initialize the array with some characters 
        charArray[0] = 'a'; 
        charArray[1] = 'b'; 
        charArray[2] = 'c'; 
        charArray[3] = 'd'; 
        charArray[4] = 'e'; 
        charArray[5] = 'f';

        De new_de = new De(charArray) ;
        Console.Write("Hellowordl \n");
        Console.Write(new_de.toString());

        //Partie Inès : 
        Joueur joueur = new Joueur("Alice");
        joueur.Add_Mot("arbre");
        joueur.Add_Mot("maison");
        joueur.Add_Mot("arbre"); // Vérification qu'avec un mot dupliqué, le code ne le remette pas une seconde fois
        Console.WriteLine(joueur.ToString()); //Affiche les détails du joueur

        try
        {
            //langue de jeu
            string langueJeu = "EN";
            string cheminFichier = "";
            if(langueJeu=="FR")
            {
                cheminFichier = "MotsPossiblesFR.txt";
            }
            else if (langueJeu=="EN")
            {
                cheminFichier = "MotsPossiblesEN.txt";
            }
            // Création du dictionnaire français
            Dictionnaire dico = new Dictionnaire(langueJeu, cheminFichier);

            // Affichage des informations sur le dictionnaire
            Console.WriteLine(dico.toString());

            // Recherche d'un mot dans le dictionnaire
            // là, on met en dur, mais il faudra prendre la saisie du joueur et faire un ToUpper() et un toTrim()
            // car les mots sont stockés en majuscule
            string motARechercher = "TREE";
            bool trouve = dico.RechDichoRecursif(motARechercher, langueJeu, 0, dico.ListeMots.Count - 1);
            Console.WriteLine($"Le mot '{motARechercher}' est-il dans le dictionnaire ? {trouve}");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("Erreur : Le fichier de mots est introuvable. " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Une erreur s'est produite : " + e.Message);
        }

    }
}

