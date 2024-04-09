using Xunit;

namespace TP2.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_ValidInput_CreatesCSVFile()
        {
            // Arrange
            string[] args = new string[] { "100000", "159", "5" };
            DateTime currentDate = DateTime.Now;

            // Act
            Program.Main(args);

            // Assert
            Assert.True(File.Exists("credit.csv"));
            DateTime creationDate = File.GetCreationTime("credit.csv");
            Assert.Equal(currentDate.Date, creationDate.Date);
        }

        [Fact]
        public void Main_InvalidInput_ThrowsArgumentException()
        {
            // Arrange
            string[] args = new string[] { "John Doe", "123456789", "abc", "12" };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Program.Main(args));
        }
    }
}
