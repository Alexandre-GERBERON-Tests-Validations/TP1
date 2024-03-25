using Xunit;

namespace TP2.Tests
{
    public class CalculateurCreditTests
    {
        [Fact]
        public void CalculerMensualite_RetourneMensualiteCorrecte()
        {
            // Arrange
            double montantEmprunte = 100000;
            int dureeEnMois = 12 * 20; // 20 ans
            double tauxNominal = 2.5; // 2.5%

            // Act
            double mensualite = CalculateurCredit.CalculerMensualite(montantEmprunte, dureeEnMois, tauxNominal);

            // Assert
            Assert.Equal(529.89, mensualite, 0.01); // Tolerance de 0.01
        }
    }
    public class CreateCSVTests
    {
        [Fact]
        public void GenererCSV_CreerFichierCSVCorrectement()
        {
            // Arrange
            string cheminFichier = "test.csv";
            double coutTotalCredit = 150000;
            string[] donnees = new string[]
            {
                    $"Coût total du crédit : {coutTotalCredit}",
                    "1, 1000, 99000",
                    "2, 1100, 97900",
                // Ajoutez plus de lignes selon vos besoins
            };

            // Act
            CreateCSV.GenererCSV(cheminFichier, donnees);

            // Assert
            Assert.True(File.Exists(cheminFichier));

            string[] lignesFichier = File.ReadAllLines(cheminFichier);
            Assert.Equal(donnees.Length, lignesFichier.Length);

            for (int i = 0; i < donnees.Length; i++)
            {
                Assert.Equal(donnees[i], lignesFichier[i]);
            }
        }
    }
}