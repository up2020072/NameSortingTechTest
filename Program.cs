using System;
using System.Linq;
using System.IO;

class NameSortingTest
{
    static void Main()
    {
        string filePath = "names.txt";

        //reads the text file, then seperates each name into its raw text, and finally places them into a sorted array
        string[] sortedNames = File.ReadAllText(filePath).Split(',').Select(n => n.Trim('"')).OrderBy(n => n).ToArray();

        int allNameTotalScore = 0;

        //iterates through each name in the list, calculating its score and adding it to a total, while also outputting each score with its corresponding name
        for (int i = 0; i < sortedNames.Length; i++)
        {
            //converts the ascii value of each letter in a name into a zero-based index, which is then offset by one to give a normalised value. such as A = 1
            int nameScore = sortedNames[i].Sum(c => c - 'A' + 1) * (i + 1);
            Console.WriteLine(sortedNames[i] + ": " + nameScore);
            allNameTotalScore += nameScore;
        }

        Console.WriteLine($"Total Score: {allNameTotalScore}");
    }
}