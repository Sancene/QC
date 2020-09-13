using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Triangle;

namespace TriangleTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestTriangleProgramWithDifferentInputsFromFile()
        {
            string outputPath = "../../../output.txt";
            File.WriteAllText(outputPath, string.Empty);
            using StreamWriter output = new StreamWriter(outputPath, true);

            int testCounter = 1;

            using (var inputFile = new StreamReader("../../../input.txt"))
            {
                string argsLine;
                while ((argsLine = inputFile.ReadLine()) != null)
                {
                    string[] argsArr = argsLine.Split();
                    string expectedResult = inputFile.ReadLine();

                    var sw = new StringWriter();
                    Console.SetOut(sw);
                    Program.Main(argsArr);
                    string result = sw.ToString();

                    if (result == expectedResult)
                    {
                        output.WriteLine("Test " + testCounter + ": success");
                    }
                    else
                    {
                        output.WriteLine("Test " + testCounter + ": error");
                    }

                    Assert.AreEqual(result, expectedResult);

                    testCounter++;
                }
            }
        }
    }
}
