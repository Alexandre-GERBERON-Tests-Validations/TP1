using Xunit;
using System.IO;

namespace TP2.Tests
{
    public class CreateCSVTests
    {
        [Fact]
        public void CreateFile_ShouldCreateCSVFile()
        {
            // Arrange
            Credit credit = new Credit(10000, 12, 5);
            string path = "test.csv";

            // Act
            CreateCSV.CreateFile(credit, path);

            // Assert
            Assert.True(File.Exists(path));
        }
        [Fact]
        public void CreateFile_ShouldCreateCSVFileWithCorrectContent()
        {
            // Arrange
            Credit credit = new Credit(200000, 5, 5);
            string path = "test.csv";

            // Act
            CreateCSV.CreateFile(credit, path);

            // Assert
            string[] lines = File.ReadAllLines(path);
            Assert.Equal("Coût total du crédit : 2506,92", lines[0]);
            Assert.Equal("Numero;interetRembourse;CapitalRestantDu;CapitalTotalRembourse;Mensualite", lines[1]);
            Assert.Equal("1;833,33;160331,94;39668,05;40501,38", lines[2]);
            Assert.Equal("2;668,04;120498,61;79501,38;40501,38", lines[3]);
            Assert.Equal("3;502,07;80499,30;119500,69;40501,38", lines[4]);
            Assert.Equal("4;335,41;40333,33;159666,66;40501,38", lines[5]);
            Assert.Equal("5;168,05;0,00;200000,00;40501,38", lines[6]);
        }
    }
}
