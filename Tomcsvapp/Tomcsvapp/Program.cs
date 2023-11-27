namespace Tomcsvapp
{
    internal class Program
    {
        const string FILEPATH = @"C:\USERS\ICTLearner02\Desktop\";
        static void Main(string[] args)
        {
            string fileName = FILEPATH + "ClassGroups.CSV";
            /*StreamReader csvFileReader = new StreamReader(fileName);*/
            string[] allLines = File.ReadAllLines(fileName);
            int studentCount = allLines.Length;
            Console.WriteLine(studentCount);
            //use a forb loop to display each line as follows: 
            //Line 1 - ----------------------
            //for (int i = 0; i < lineCount; i++)
            //{
            //    Console.WriteLine($"Line {i +1} = {allLines[i]}");
            //}
            Console.Clear();
            studentCount = 0;
            bool isHeader = true;
            int linesToSkip;
            int totalAge = 0;
            if(isHeader)
            {
                linesToSkip = 1;
            }
            else 
            {
                linesToSkip = 0;
            }
            foreach (string line in allLines.Skip(linesToSkip)) 
            { 
                studentCount++;
                Console.WriteLine($"Line {studentCount} = {line}");

                string[] dataFields = line.Split(",");
                Console.WriteLine(dataFields.Length);
                int age = Convert.ToInt32(dataFields[2]);
                Console.WriteLine(age);
                totalAge += age;
                
            }

            Console.WriteLine($"The total age is: {totalAge}");
            double meanAge = (double)totalAge / studentCount;
            meanAge = Math.Round(meanAge, 2);
            Console.WriteLine($"The mean age is: {meanAge}");
            Console.WriteLine($"The number of students: {studentCount}");

            static void ProcessLines()
            {

                try
                {
                    string fileName = FILEPATH + "ClassGroups.CSV";
                    StreamReader csvFileReader = new StreamReader(fileName);
                    int lineCount = 0;

                    while (!csvFileReader.EndOfStream)
                    {
                        string csvLine = csvFileReader.ReadLine();
                        lineCount++;
                        switch (lineCount)
                        {

                            case 1:
                                //this is the header -First Line
                                Console.WriteLine($"The header line  is {csvLine}");
                                break;

                            case 11:
                                //line 1 is a header not a dataline, so the 10th entry is on line 11.
                                Console.WriteLine($"The tenth line is {csvLine}");
                                break;
                            default:
                                //Console.WriteLine();
                                break;

                        }
                    }
                    Console.WriteLine($"The total number of lines = {lineCount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}