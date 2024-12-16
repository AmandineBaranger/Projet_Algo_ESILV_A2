using Xunit;
using Boogle;
using System;

namespace DeTests
{
    public class UnitTest1
    {
        private readonly Random random = new Random();
        private const string TestFichier = "TestLettres.txt";

        // Méthode pour générer un fichier de test temporaire
        private void CreerFichierDeTest()
        {
            string contenu = "A;1;3\nB;1;2\nC;1;4\nD;1;1";
            File.WriteAllText(TestFichier, contenu);
        }

        [Fact]
        public void Constructeur_InitialiseCorrectementAvecFichier()
        {
            // Arrange
            CreerFichierDeTest();

            // Act
            De de = new De(TestFichier, random);

            // Assert
            Assert.Equal(6, de.Lettres.Length); // Le dé doit avoir 6 faces
            Assert.Contains(de.FaceVisible, de.Lettres); //La face visible doit appartenir à une des faces du de
        }

        [Fact]
        public void Constructeur_ThrowsException_SiFichierIntrouvable()
        {
            // Arrange
            string cheminInvalide = "FichierIntrouvable.txt";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => new De(cheminInvalide, random));
        }
        
    }
}