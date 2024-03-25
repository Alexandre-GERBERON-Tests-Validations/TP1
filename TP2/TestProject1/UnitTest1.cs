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
}