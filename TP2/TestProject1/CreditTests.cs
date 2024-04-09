using Xunit;

namespace TP2.Tests
{
    public class CalculateurCreditTests
    {
        [Theory]
        [InlineData(10000, 180, 5.0, 79)]
        [InlineData(20000, 360, 7.5, 140)]
        [InlineData(500000, 120, 2.5, 4713)]
        public void CalculerMensualite_ShouldReturnCorrectValue(decimal montant, int duree, decimal tauxNominal, decimal expectedMensualite)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            decimal actualMensualite = Math.Round(CalculateurCredit.CalculerMensualite(credit), 0);

            // Assert
            Assert.Equal(expectedMensualite, actualMensualite);
        }

        [Theory]
        [InlineData(10000, 180, 5.0, 180, 10000, 0, 79, 42)]
        [InlineData(20000, 360, 7.5, 360, 20000, 0, 140, 125)]
        [InlineData(500000, 120, 2.5, 120, 500000, 0, 4713, 1042)]
        public void CalculerMensualites_ShouldReturnCorrectList(decimal montant, int duree, decimal tauxNominal, int expectedCount, decimal expectedRemboursementCapital, decimal expectedCapitalRestantDu, decimal mensualite, decimal interetRembourse)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            List<Mensualite> mensualites = CalculateurCredit.CalculerMensualites(credit);

            // Assert
            Assert.Equal(expectedCount, mensualites.Count);
            Assert.Equal(expectedRemboursementCapital, Math.Round(mensualites[expectedCount - 1].CapitalTotalRembourse), 0);
            Assert.Equal(expectedCapitalRestantDu, Math.Round(mensualites[expectedCount - 1].CapitalRestantDu), 0);
            Assert.Equal(mensualite, Math.Round(mensualites[expectedCount - 1].CoutMensualite), 0);
            Assert.Equal(interetRembourse, Math.Round(mensualites[0].InteretRembourse), 0);
        }

        [Theory]
        [InlineData(10000, 180, 5.0, 4234)]
        [InlineData(20000, 360, 7.5, 30343)]
        [InlineData(500000, 120, 2.5, 65619)]
        public void CalculerCoutTotal_ShouldReturnCorrectValue(decimal montant, int duree, decimal tauxNominal, decimal expectedCoutTotal)
        {
            // Arrange
            Credit credit = new Credit(montant, duree, tauxNominal);

            // Act
            decimal actualCoutTotal = CalculateurCredit.CalculerCoutTotal(credit);

            // Assert
            Assert.Equal(expectedCoutTotal, Math.Round(actualCoutTotal, 0));
        }
    }

}