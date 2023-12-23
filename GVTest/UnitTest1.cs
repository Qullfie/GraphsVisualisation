using GraphsVisualisation;
namespace GVTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MaxMultiplicity_littleGraph_Test_eq4()
        {
            //Arrange
            Graph littleGraph;
            string filename = "C:\\Users\\User\\source\\repos\\GraphsVisualisation\\littleGraph.txt";
            using (StreamReader reader = new StreamReader(filename))
                littleGraph = Graph.LoadFromFile(reader);
            int expected_result = 4;

            //Act
            int result = littleGraph.MaxMultiplicity(new System.Windows.Forms.TextBox());

            //Assert
            Assert.AreEqual(expected_result, result);
        }
        [TestMethod]
        public void MaxMultiplicity_bigGraph_Test_eq2()
        {
            //Arrange
            Graph bigGraph;
            string filename = "C:\\Users\\User\\source\\repos\\GraphsVisualisation\\bigGraph.txt";
            using (StreamReader reader = new StreamReader(filename))
                bigGraph = Graph.LoadFromFile(reader);
            int expected_result = 2;

            //Act
            int result = bigGraph.MaxMultiplicity(new System.Windows.Forms.TextBox());

            //Assert
            Assert.AreEqual(expected_result, result);
        }
    }
}