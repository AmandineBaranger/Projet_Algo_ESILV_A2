using System;
using System.Collections.Generic;
public class Joueur
{
    private string nom;
    private int score;
    private List<string> motsTrouvés = new List<string>();

    //Constructeur
    public Joueur(string nom)
    {
        if(string.IsNullOrEmpty(nom))
        {
            Console.WriteLine("Erreur : le Nom n'est pas valide");
            return;
        }
        this.nom = nom; // (??) vérifie si nom est null. Si nom est null, il attribue "Nom par défaut". Sinon, il utilise la valeur de nom telle qu'elle est.
        this.score = 0;
        this.motsTrouvés = new List<string>();

    }
    // Méthode qui permet de vérifier que le mot est dans la liste
    public bool Contain(string mot)
    {
        return motsTrouvés.Contains(mot);
    }
    
    //Méthode qui ajoute un mot à l liste et met à jour le score
    public void Add_Mot(string mot)
    {
        if (!Contain(mot))
        {
            motsTrouvés.Add(mot);
            score += 1; // Mise à jour du score (+1) à chaque mot ajouté
        }
    }

    //Méthode qui retourne le string et donc les infos du joueur
    public override string ToString()
    {
        return $"Joueur: {nom}, Score: {score}, Mots trouvés: {string.Join(", ", motsTrouvés)}";
    }
}