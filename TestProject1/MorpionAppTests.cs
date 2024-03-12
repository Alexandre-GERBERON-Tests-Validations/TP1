using MorpionApp;

namespace TestProject1
{
    public class MorpionTests
    {
        [Fact]
        public void TestVerifVictoire_Player1Wins_ReturnsTrue()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.InitialiserGrille(3, 3);
            morpion.grille.SetCell(0, 0, CellValue.X);
            morpion.grille.SetCell(0, 1, CellValue.X);
            morpion.grille.SetCell(0, 2, CellValue.X);

            // Act
            bool result = morpion.verifVictoire(CellValue.X);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestVerifVictoire_Player2Wins_ReturnsTrue()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.InitialiserGrille(3, 3);
            morpion.grille.SetCell(1, 0, CellValue.O);
            morpion.grille.SetCell(1, 1, CellValue.O);
            morpion.grille.SetCell(1, 2, CellValue.O);

            // Act
            bool result = morpion.verifVictoire(CellValue.O);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestVerifVictoire_NoWinner_ReturnsFalse()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.InitialiserGrille(3, 3);
            morpion.grille.SetCell(0, 0, CellValue.X);
            morpion.grille.SetCell(0, 1, CellValue.O);
            morpion.grille.SetCell(0, 2, CellValue.X);
            morpion.grille.SetCell(1, 0, CellValue.O);
            morpion.grille.SetCell(1, 1, CellValue.X);
            morpion.grille.SetCell(1, 2, CellValue.O);
            morpion.grille.SetCell(2, 0, CellValue.X);
            morpion.grille.SetCell(2, 1, CellValue.O);
            morpion.grille.SetCell(2, 2, CellValue.X);

            // Act
            bool result = morpion.verifVictoire(CellValue.X);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestVerifEgalite_BoardNotFull_ReturnsFalse()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.InitialiserGrille(3, 3);
            morpion.grille.SetCell(0, 0, CellValue.X);
            morpion.grille.SetCell(0, 1, CellValue.O);
            morpion.grille.SetCell(0, 2, CellValue.X);
            morpion.grille.SetCell(1, 0, CellValue.O);
            morpion.grille.SetCell(1, 1, CellValue.X);
            morpion.grille.SetCell(1, 2, CellValue.O);

            // Act
            bool result = morpion.verifEgalite();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TestVerifEgalite_BoardFull_ReturnsTrue()
        {
            // Arrange
            Morpion morpion = new Morpion();
            morpion.InitialiserGrille(3, 3);
            morpion.grille.SetCell(0, 0, CellValue.X);
            morpion.grille.SetCell(0, 1, CellValue.O);
            morpion.grille.SetCell(0, 2, CellValue.X);
            morpion.grille.SetCell(1, 0, CellValue.O);
            morpion.grille.SetCell(1, 1, CellValue.X);
            morpion.grille.SetCell(1, 2, CellValue.O);
            morpion.grille.SetCell(2, 0, CellValue.X);
            morpion.grille.SetCell(2, 1, CellValue.O);
            morpion.grille.SetCell(2, 2, CellValue.X);

            // Act
            bool result = morpion.verifEgalite();

            // Assert
            Assert.True(result);
        }
    }


    public class PuissanceQuatreTests
    {

    }
}