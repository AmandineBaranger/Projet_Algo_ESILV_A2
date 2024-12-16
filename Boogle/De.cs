namespace Boogle
{
    public class De
    {
        private char[] lettres;
        private char faceVisible;

        //Constructeur de la classe Dé qui oblige un dé à avoir 6 lettres pour chaque face.
        public De(char[] lettres)
        {
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

            this.lettres = lettres;
            faceVisible = lettres[0];
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