public class De
{
    private char[] lettres; 
    private char faceVisible;

//Constructeur de la classe Dé qui oblige un dé à avoir 6 lettres pour chaque face.
    public De(char[] lettres )
    {
        if (lettres == null || lettres.Length != 6)
        {
            Console.WriteLine("Erreur : Le Dé doit avoir 6 lettres.");
            return;
        }

        this.lettres = lettres;
        faceVisible = lettres[0];
    }

// Accesseur pour récupérer la face visible du dé.
    public char FaceVisible
    {
        get{return faceVisible;}
    }

public void Lance( Random r)
{
    
}
}