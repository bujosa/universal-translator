using System;
using System.IO;

namespace UniversalTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the temperature conversion system enter the file path: ");
            string Path = Console.ReadLine();
            string[] archive = File.ReadAllLines(Path);
            Temperature X = new Temperature();
            X.Valid(archive);
        }
    }

    /// <summary>
    /// This class is in charge of receiving the file, 
    /// validating it, converting it and then exporting 
    /// it to a file.txt.With all the results generated.
    /// </summary>
    public class Temperature
    {
        string[] Archive;

        public void Valid(string[] Path)
        {
            Archive = Path;
            // Valid File and Parameters 
            for(int i = 0; i < Path.Length; i++)
            {
                string[] TMP = Path[i].Split(",");

                if (TMP.Length < 3 || TMP.Length > 3)
                {
                    throw new InvalidOperationException(
                      "missing parameters, check documentation");
                }

                try
                {
                    double prueba = Convert.ToDouble(TMP[0]);
                }
                catch
                {
                    throw new InvalidDataException("only number in the first column");
                }


                for(int j = 1; j < TMP.Length; j++)
                {
                    switch (TMP[j])
                    {
                        case "C":
                        case "c":
                        case "F":
                        case "f":
                        case "K":
                        case "k":
                            break;
                        default:
                            throw new InvalidDataException(
                               "Only parameters C, F or K. Are accepted!!. " +
                               "Please Read documentacion");
                    } 
                }
            }

            Converter();
        }

        internal void Converter()
        {
            for (int i = 0; i < Archive.Length; i++)
            {
                string[] TMP = Archive[i].Split(",");
                double value = Convert.ToInt32(TMP[0]);
                string C1 = TMP[1];
                string C2 = TMP[2];
                if (C1 == C2)
                { Archive[i] += "," + value;
                    continue;
                }
                else if (C2 == "K" || C2 == "k")
                {
                    if (C1 == "C" || C1 == "c")
                        value += 273.15;
                    else
                    {
                        value -= 32; value *= 0.55555;
                        value += 273.15;
                    }
                }
                else if (C2 == "F" || C2 == "f")
                {
                    if (C1 == "C" || C1 == "c")
                    {
                        value *= 1.80;
                        value += 32;
                    }
                    else
                    {
                        value -= 273.15;
                        value *= 1.80;
                        value += 32;
                    }
                }
                else
                {
                    if (C1 == "K" || C1 == "k")
                        value -= 273.13;
                    else
                    {
                        value -= 32;
                        value *= 0.55555;
                    }
                }

                Archive[i] += "," + value;
            }
            CreatedFile();
        }

        internal void CreatedFile()
        {
            Console.WriteLine("Enter the path where you want the file conversion: ");
            string PathTwo = Console.ReadLine();
            if ((!File.Exists(PathTwo + "\\ConverterFile.txt")))
            {
                TextWriter tw = new StreamWriter(PathTwo + "\\ConverterFile.txt");

                foreach (String s in Archive)
                    tw.WriteLine(s);

                tw.Close();
            }
        }
    }
}
