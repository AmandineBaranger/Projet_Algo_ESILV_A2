namespace Boogle
{
    public class De
    {
        private char[] lettres;
        private char faceVisible;

        //Constructeur de la classe Dé qui oblige un dé à avoir 6 lettres pour chaque face.
        public De(String cheminFichier, Random random)
        {
            if (!File.Exists(cheminFichier))
            {
                throw new FileNotFoundException($"Le fichier {cheminFichier} est introuvable.");
            }

            char[] tableauPondere = GenererTabPondere(cheminFichier);

            lettres = new char[6];
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(tableauPondere.Length);
                lettres[i] = tableauPondere[index];
            }

            // Check if "lettres" is null or empty
            if (lettres == null || lettres.Length == 0)
            {
                throw new ArgumentException("The 'lettres' array cannot be null or empty.");
            }

            // Check if "lettres" has exactly 6 elements
            if (lettres.Length != 6)
            {
                throw new ArgumentException("The 'lettres' array must contain exactly 6 characters.");
            }

            faceVisible = lettres[0];
        }

        // Liste de tuples contenant lettre et ses points
        private static List<(char Lettre, int Points)> pointsParLettre;

        // Chargement des points depuis le fichier
        public static void ChargerPointsParLettre(string cheminFichier)
        {
            pointsParLettre = new List<(char, int)>();
            string[] lignes = File.ReadAllLines(cheminFichier);

            foreach (string ligne in lignes)
            {
                string[] parties = ligne.Split(';');
                char lettre = parties[0][0];          // Lettre
                int points = int.Parse(parties[1]);   // Points

                pointsParLettre.Add((lettre, points)); // Ajout à la liste de tuples
            }
        }
        public static int CalculerPointsMot(string mot)
        {
            int score = 0;

            foreach (char lettre in mot)
            {
                foreach (var tuple in pointsParLettre)
                {
                    if (lettre == tuple.Lettre) // Trouver la lettre dans la liste
                    {
                        score += tuple.Points;  // Ajouter les points associés
                        break;                  // Sortir de la boucle une fois trouvée
                    }
                }
            }

            return score;
        }

        public char[] GenererTabPondere(string cheminFichier)
        {
            List<char> tableauPondere = new List<char>();
            string[] lignes = File.ReadAllLines(cheminFichier);

            foreach (string ligne in lignes)
            {
                string[] parties = ligne.Split(';');
                char lettre = parties[0][0];
                int recurrence = int.Parse(parties[2]);
                for (int i = 0; i < recurrence; i++)
                {
                    tableauPondere.Add(lettre);
                }
            }

            return tableauPondere.ToArray();
            
        }

        // Accesseur pour récupérer la face visible du dé et le tableau qui contient toutes les faces du tableau 
        public char FaceVisible
        {
            get { return faceVisible; }
        }

        public char[] Lettres
        {
            get { return lettres; }
        }

        public void Lance(Random r)
        {
            //Selec tion d'un index aléatoire de la liste "lettres"
            int indexAléatoire = r.Next(lettres.Length);
            //Récupération de lalettre correspondante 
            this.faceVisible = lettres[indexAléatoire];
        }
        public string toString()
        {
            return $"La face visible du dé est {this.faceVisible}";
        }

    }
}