using Xunit;

namespace TP2.Tests
{
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
            Assert.Equal(5.2m, credit.TauxNominal);
        }
    }
}
