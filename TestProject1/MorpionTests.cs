using MorpionApp;

namespace TestProject1
{
    public class MorpionTests
    {
        [Fact]
        public void TestTourJoueur()
        {
            // Arrange
            var morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                    { 'X', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
            };

            // Act
            morpion.tourJoueur();

            // Assert
            Assert.Equal('X', morpion.grille[0, 0]);
        }

        [Fact]
        public void TestTourJoueur2()
        {
            // Arrange
            var morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                    { 'O', ' ', ' '},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
            };

            // Act
            morpion.tourJoueur2();

            // Assert
            Assert.Equal('O', morpion.grille[0, 0]);
        }

        [Fact]
        public void TestVerifVictoireLigne()
        {
            // Arrange
            var morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                    { 'X', 'X', 'X'},
                    { ' ', ' ', ' '},
                    { ' ', ' ', ' '},
            };

            // Act
            var result = morpion.verifVictoire('X');

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestVerifVictoireDiagonale()
        {
            // Arrange
            var morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                    { 'O', ' ', ' '},
                    { ' ', 'O', ' '},
                    { ' ', ' ', 'O'},
            };

            // Act
            var result = morpion.verifVictoire('O');

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TestVerifEgalite()
        {
            // Arrange
            var morpion = new Morpion();
            morpion.grille = new char[3, 3]
            {
                    { 'X', 'O', 'X'},
                    { 'O', 'X', 'O'},
                    { 'O', 'X', 'O'},
            };

            // Act
            var result = morpion.verifEgalite();

            // Assert
            Assert.True(result);
        }
    }
}