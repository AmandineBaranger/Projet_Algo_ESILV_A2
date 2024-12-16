using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class Dictionnaire{
    private string langue;
    private List<string> listeMots;

    public string Langue{get; set; }
    public List<string> ListeMots{get; set; }
    
    // couples nombre de lettres / nombre de mots ayant ce nombre de lettres 
    Dictionary<int,int> nombreMotsParLongueur = new Dictionary<int, int>();
    
    // couples lettre / nombre de mots commencant par cette lettre
    Dictionary<string,int> nombreMotsParLettre = new Dictionary<string, int>();
    public Dictionnaire(string pLangue, string pCheminAcces){
        // gestion de la langue du dictionnaire
        // TODO gerer le cas ou ce n'est pas FR ou EN
        if(pLangue=="FR"||pLangue=="EN")
        {
            Langue=pLangue;
        }
        ListeMots = new List<string>();
        
        string[] lignes = File.ReadAllLines(pCheminAcces);
        
        char[] delimiters ={' ', '\n', '\r', '\t' };
        
        foreach (string ligne in lignes)
        {
            string[] motsLigne = ligne.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach(string mot in motsLigne)
            {
                string motPropre = mot.Trim().ToUpper();
                if (!string.IsNullOrEmpty(motPropre))
                {
                    // on ajoute dans le liste de mots du dictionnaire
                    ListeMots.Add(motPropre);
                    // gestion de la taille/ nbre de mots
                    int longueur=motPropre.Length;
                    // si il y a déjà au moins un mot de cette taille, la clé existe, on ajoute 1
                    int val;
                    if (nombreMotsParLongueur.TryGetValue(longueur, out val)) {
                        nombreMotsParLongueur[longueur] = val+1;

                    }
                    // sinon, il faut créer l'entrée avec la longueur et le nbre de mot à 1
                    else 
                    {
                        nombreMotsParLongueur.Add(longueur, 1);
                    }
                    //on va regarder par lettre maintenant
                    string preLettre = motPropre.Substring(0, 1);
                    if(nombreMotsParLettre.TryGetValue(preLettre, out val))
                    {
                        nombreMotsParLettre[preLettre] = val+1;
                    }
                    else
                    {
                        nombreMotsParLettre.Add(preLettre,1);
                    }
                }
            }
        }
        ListeMots.Sort(StringComparer.OrdinalIgnoreCase);
    }

    public string toString(){
        string res=$"Nombre de mots par longueur : \n";
        // parcours du dictionnaire longueur/nbre de mots
        foreach (var element in nombreMotsParLongueur) 
        {
            res += $"Longueur : {element.Key}         Nombre de mots : {element.Value}\n";
        }
        res+=$"\nNombre de mots par lettre : \n";
        foreach (var element in nombreMotsParLettre) 
        {
            res += $"Lettre : {element.Key}         Nombre de mots : {element.Value}\n";
        }
        res+=$"\nLangue : {Langue}\n";
        return res;
    }
    
    public bool RechDichoRecursif(string pMot, string pLangue,int a, int b)
    {    
        if(a>b)
        {
            return false;
        }
        int milieu=0;   
        if((a+b)%2==0)
        {
            milieu = (a+b)/2;
        }
        else
        {
            milieu = (a+b+1)/2;
        }
        int comparaison = string.Compare(pMot, ListeMots[milieu], StringComparison.OrdinalIgnoreCase);
        switch(comparaison)
        {
            //égal à 0 : on a trouvé notre mot
            case 0:
                return true;
            //sup à 0 : mot a (celui qu'on cherche) après mot b(mot consulté dans le dico - mot du milieu)
            case >0:
                return RechDichoRecursif(pMot, pLangue, milieu+1, b);
            //inf à 0 : mot a (celui qu'on cherche) avant mot b(mot consulté dans le dico - mot du milieu)
            case <0:
                return RechDichoRecursif(pMot, pLangue, a, milieu-1);
        }
    }
}