using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpProfessional.Tests
{
    [TestClass]
    public class ReadBookMarks
    {
        [TestMethod]
        public void Read()
        {
            string fileName = @"F:\书库\_net框架\Entity Framework 6 Recipes 2nd Edition\FreePic2Pdf_bkmk.txt";

            if (!File.Exists(fileName)) return;

            using (StreamReader stream = new StreamReader(fileName, true))
            {
                string str = stream.ReadLine();
                Debug.WriteLine(str);
                while (str != null)
                {
                    str = stream.ReadLine();
                    if (string.IsNullOrEmpty(str)) continue;
                    if (str.Contains("Problem") || str.Contains("Solution") || str.Contains("How It Works") || str.Contains("Best Practice")) continue;

                    if (str.Contains("9781430257882"))
                        str = str.Substring(0, str.IndexOf("9781430257882")).TrimEnd();

                    Debug.WriteLine(str);
                }
            }

        }
    }
}
