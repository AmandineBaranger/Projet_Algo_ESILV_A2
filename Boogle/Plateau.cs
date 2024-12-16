namespace Boogle
{
    public class Plateau
    {
        private int TAILLE = 4;
        private De[,] des;

        public Plateau(Random random, string cheminFichier, int TAILLEgrille)
        {
            this.TAILLE = TAILLEgrille;
            des = new De[TAILLE,TAILLE];

            for(int i = 0; i<TAILLE; i++)
            {
                for(int j = 0; j<TAILLE; j++)
                {
                    des[i,j] = new De(cheminFichier,random);
                    des[i,j].Lance(random);
                }
            }
        }

        public string toString()
        {
            string resultat = "";

            for (int i = 0; i<TAILLE; i++)
            {
                for (int j = 0; j<TAILLE; j++)
                {
                    resultat += des[i,j].FaceVisible + " ";
                }

                resultat += "\n";
            }
            return resultat;
        }

        public bool Test_Plateau_Rec(string mot, int index, int x, int y, bool[,] casesVisee)
        {
            // Condition de fin : toutes les lettres du mot ont été trouvées
            if (index == mot.Length)
            {
                return true;
            }

            if (x < 0 || y < 0 || x >= 4 || y >= 4 || casesVisee[x, y] || des[x, y].FaceVisible != mot[index])
            {
                return false;
            }

            casesVisee[x,y] = true;

            int[] directions = { -1, 0, 1 };
            foreach (int dx in directions) // Parcours des directions
            {
                foreach (int dy in directions)
                {
                    if (dx != 0 || dy != 0) // Ignorer la case centrale
                    {
                        if (Test_Plateau_Rec(mot, index + 1, x + dx, y + dy, casesVisee))
                        {
                            return true; // Si une direction permet de trouver le mot
                        }
                    }
                }
                
            }  

            casesVisee[x,y] = false;
            return false;
        }

        public bool Test_Plateau(string mot)
        {
            if (string.IsNullOrWhiteSpace(mot) || mot.Length < 2)
            {
                return false;
            }

            bool [,] casesVisee = new bool[TAILLE,TAILLE];

            for(int i = 0; i<TAILLE; i++)
            {
                for(int j = 0; j<TAILLE; j++)
                {
                    if (des[i, j].FaceVisible == mot[0]) // Première lettre trouvée
                    {
                        // Appel de la méthode récursive pour chercher le mot
                        if (Test_Plateau_Rec(mot, 0, i, j, casesVisee))
                        {
                            return true; // Mot trouvé
                        }

                    }
                }
            }
            return false; 
        }
        

    }
}