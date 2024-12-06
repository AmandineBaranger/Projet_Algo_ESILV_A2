using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Dictionnaire
{
    private List<string> mots;
    private string langue;

    // Constructeur
    public Dictionnaire(string fichier, string langue)
    {
        this.langue = langue;
        mots = new List<string>(File.ReadLines(fichier)); // Lecture lignes + stockage dans liste
        mots.Sort(); // Facilitation recherche dichotomique grâce au tri
    }
    // Méthode 
    public override string ToString()
    {
        // Création du dictionnaire trié par longueur
        Dictionary<int, int> motsParLongueur = new Dictionary<int, int>(); // définition des génériques (clé + valeur) en tant qu'entier
        //Compter nb mots pour chaque longueur mot dans liste mots
        //Parcourt chaque mot + calcule sa longueur + met à jour dico (clé = longueur du mot + valeur = nb mots dans ce groupe de cette longueur)
        foreach (string mot in mots)
        {
            int longueur = mot.Length;
            if (motsParLongueur.ContainsKey(longueur))
            {
                motsParLongueur[longueur]++;
            }
            else
            {
                motsParLongueur[longueur] = 1;
            }
        }
        string description = $"Langue : {langue}\nNombre total de mots : {mots.Count}\n";
        description += "Mots par longueur :\n";
        //Parcourt chaque élément du dico + ajout description chaque entrée à description (chaîne de texte)
        foreach (var entry in motsParLongueur)
        {
            description += $"  Longueur {entry.Key} : {entry.Value} mots\n";
        }
        return description;
    }
    // Recherche Dichotomique récursive
    public bool RechDichoRecursif(string mot)
    {
        return RechDichoRecursifAide(mots, mot, 0, mots.Count - 1);
    }
    // Vérification mot donné dans une liste triée
    private bool RechDichoRecursifAide(List<string> list, string mot, int debut, int fin)
    {
        if (debut > fin)
        {
            return false; //mot pas trouvé
        } 
        int milieu = (debut + fin) / 2;
        if (list[milieu] == mot)
        {
            return true; // mot trouvé
        }
        // Cette division des cas permet à mon algorithme d'éliminer plus facilement la moitié des éléments donc le temps de recherche --> optimisation
        if (string.Compare(mot, list[milieu]) < 0)
        {
            return RechDichoRecursifAide(list, mot, debut, milieu - 1); // Cherche dans la moitié gauche
        }
        else
        {
            return RechDichoRecursifAide(list, mot, milieu + 1, fin); // Cherche dans la moitié droite
        }
    }
}