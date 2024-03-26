using Xunit;

namespace TP2.Tests
{
    public class CalculateurCreditTests
    {
        [Theory]
        [InlineData(10000, 5, 5.0, 2025)]
        [InlineData(20000, 10, 7.5, 2069)]
        [InlineData(5000, 3, 2.5, 1674)]
        public void CalculerMensualite_ShouldReturnCorrectValue(double montant, int duree, double tauxNominal, double expectedMensualite)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            double actualMensualite = CalculateurCredit.CalculerMensualite(credit);

            // Assert
            Assert.Equal(expectedMensualite, actualMensualite, 0);
        }

        [Theory]
        [InlineData(10000, 5, 5.0, 5, 10125, 0)]
        [InlineData(20000, 10, 7.5, 10, 20694, 0)]
        [InlineData(5000, 3, 2.5, 3, 5021, 0)]
        public void CalculerMensualites_ShouldReturnCorrectList(double montant, int duree, double tauxNominal, int expectedCount, double expectedRemboursementCapital, double expectedCapitalRestantDu)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            List<Mensualite> mensualites = CalculateurCredit.CalculerMensualites(credit);

            // Assert
            Assert.Equal(expectedCount, mensualites.Count);
            Assert.Equal(expectedRemboursementCapital, mensualites[expectedCount - 1].RemboursementCapital, 0);
            Assert.Equal(expectedCapitalRestantDu, mensualites[expectedCount - 1].RestantDu, 0);
        }

        [Theory]
        [InlineData(10000, 5, 5.0, 125)]
        [InlineData(20000, 10, 7.5, 694)]
        [InlineData(5000, 3, 2.5, 21)]
        public void CalculerCoutTotal_ShouldReturnCorrectValue(double montant, int duree, double tauxNominal, double expectedCoutTotal)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            double actualCoutTotal = CalculateurCredit.CalculerCoutTotal(credit);

            // Assert
            Assert.Equal(expectedCoutTotal, actualCoutTotal, 0);
        }
    }
    public class CreateCSVTests
    {
        [Fact]
        public void CreateFile_ShouldCreateCSVFile()
        {
            // Arrange
            Credit credit = new Credit(10000, 5, 5.0);
            string path = "test.csv";

            // Act
            CreateCSV.CreateFile(credit, path);

            // Assert
            Assert.True(File.Exists(path));

            // Assert the content in the CSV file
            string[] lines = File.ReadAllLines(path);
            Assert.Equal("Coût total du crédit : 125", lines[0]);
            Assert.Equal("Numero;RemboursementCapital;RestantDu", lines[1]);
            Assert.Equal("1;2025;8100", lines[2]);
            Assert.Equal("2;4050;6075", lines[3]);
            Assert.Equal("3;6075;4050", lines[4]);
            Assert.Equal("4;8100;2025", lines[5]);
            Assert.Equal("5;10125;0", lines[6]);
        }
    }
    public class InputHandlerTests
    {
        [Fact]
        public void HandleInput_ShouldThrowArgumentException_WhenArgsLengthIsNot3()
        {
            // Arrange
            string[] args = new string[] { "10000", "5" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputHandler.HandleInput(args));
        }

        [Fact]
        public void HandleInput_ShouldThrowArgumentException_WhenMontantIsLessThanMONTANT_MIN()
        {
            // Arrange
            string[] args = new string[] { "10000", "120", "5.0" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputHandler.HandleInput(args));
        }

        [Fact]
        public void HandleInput_ShouldThrowArgumentException_WhenDureeIsLessThanDUREE_MIN()
        {
            // Arrange
            string[] args = new string[] { "50000", "8", "5.0" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputHandler.HandleInput(args));
        }

        [Fact]
        public void HandleInput_ShouldThrowArgumentException_WhenDureeIsGreaterThanDUREE_MAX()
        {
            // Arrange
            string[] args = new string[] { "50000", "301", "5.0" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputHandler.HandleInput(args));
        }

        [Fact]
        public void HandleInput_ShouldThrowArgumentException_WhenTauxNominalIsNotANumber()
        {
            // Arrange
            string[] args = new string[] { "50000", "120", "abc" };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => InputHandler.HandleInput(args));
        }

        [Fact]
        public void HandleInput_ShouldReturnCredit_WhenArgsAreValid()
        {
            // Arrange
            string[] args = new string[] { "50000", "120", "5,2" };

            // Act
            Credit credit = InputHandler.HandleInput(args);

            // Assert
            Assert.Equal(50000, credit.Montant);
            Assert.Equal(120, credit.Duree);
            Assert.Equal(5.2, credit.TauxNominal);
        }
    }
    
}