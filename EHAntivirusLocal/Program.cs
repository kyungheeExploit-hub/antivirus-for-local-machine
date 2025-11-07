using System.IO;
using System.Diagnostics;


namespace EHAntivirus
{
    public class Scanner
    {
        public static double CalculateSimilarity(string fpath1, string fpath2)
        {
            Process fcmp = new Process();
            fcmp.StartInfo.FileName = "./fcmpnix";
            fcmp.StartInfo.Arguments = fpath1 + " " + fpath2;
            fcmp.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            fcmp.Start();
            fcmp.WaitForExit();
            StreamReader fr = new StreamReader("./fcmpresult.txt");
            string resultString = fr.ReadLine();
            double result;

            if (resultString != null)
            {
                result = Double.Parse(resultString);
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=============================================================================================================");
            Console.WriteLine("     ______      __  __         ___       __  __  _______  _____  _    __  _____   _____     __   __  _______");
            Console.WriteLine("    / ____/     / / / /        /   |     / | / / /__  __/ /_  _/ | |  / / /_  _/  / ___ \\   / /  / / / _____/");
            Console.WriteLine("   / /___      / /_/ /        / /| |    /  |/ /    / /     / /   | | / /   / /   / /__/ /  / /  / / / /____  ");
            Console.WriteLine("  / ____/     / __  /        / __  |   / | | /    / /     / /    | |/ /   / /   / /-  --  / /  / / /____  /  ");
            Console.WriteLine(" / /___  __  / / / / __     / /  | |  / /|  /    / /    _/ /_    | | /  _/ /_  / /  \\ \\  / /__/ / _____/ /   ");
            Console.WriteLine("/_____/ /_/ /_/ /_/ /_/    /_/   |_| /_/ |_/    /_/    /____/    |__/  /____/ /_/    \\_\\ \\_____/ /______/    ");
            Console.WriteLine("");
            Console.WriteLine("Made by \"The Exploit Hub\"");
            Console.WriteLine("=============================================================================================================");
            Console.WriteLine("");

            bool isexit = false;

            while (!isexit)
            {
                Console.Write("Type command(type 'h' to show help): ");
                string command = Console.ReadLine();
                Console.WriteLine("");

                if (command == null)
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("");
                    continue;
                }
                switch (command.ToLower())
                {
                    case "h":
                        {
                            Console.WriteLine("h: show help");
                            Console.WriteLine("s: scan a directory");
                            Console.WriteLine("c: clear screen");
                            Console.WriteLine("x: exit");
                            Console.WriteLine("");
                            break;
                        }
                    case "s":
                        {
                            Console.Write("Enter a directory path you want to scan: ");
                            string directoryPath = Console.ReadLine();
                            Console.WriteLine("");

                            if (directoryPath == "" || directoryPath == null)
                            {
                                Console.WriteLine("Please enter the directory path.");
                            }
                            else
                            {
                                try
                                {
                                    string[] filePaths = Directory.GetFiles(directoryPath);
                                    string[] directoryPaths = Directory.GetDirectories(directoryPath);

                                    for (int i = 0; i < filePaths.Length; i++)
                                    {
                                        Console.WriteLine(filePaths[i]);
                                    }
                                    for (int i = 0; i < directoryPaths.Length; i++)
                                    {
                                        Console.WriteLine(directoryPaths[i]);
                                    }
                                }
                                catch (DirectoryNotFoundException)
                                {
                                    Console.WriteLine("There is no directory \'" + directoryPath + "\'.");
                                    directoryPath = "";
                                }
                                catch (UnauthorizedAccessException)
                                {
                                    Console.WriteLine("Unauthorized access occurred at \'" + directoryPath + "\'.");
                                    directoryPath = "";
                                }
                            }
                            Console.WriteLine("");
                            break;
                        }
                    case "c":
                        {
                            Console.Clear();
                            break;
                        }
                    case "x":
                        {
                            isexit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please type a proper command.");
                            Console.WriteLine("");
                            break;
                        }
                }
            }
        }
    }
}

/*
public class ScanKeywords
    {
        private static List<string> directory_list = new List<string>();
        private static List<string> keyword_list = new List<string>();
        private static List<string> data_list = new List<string>();
        private static List<string> found_list = new List<string>();

        public static void AddDirectory(List<string> directories)
        {
            directory_list.AddRange(directories);
        }
        public static void ClearDirectory()
        {
            directory_list = [];
        }
        public static void AddKeyword(List<string> keywords)
        {
            keyword_list.AddRange(keywords);
        }
        public static void ClearKeyword()
        {
            keyword_list = [];
        }
        public static List<string> GetFoundList()
        {
            return found_list;
        }
        public static void Scan()
        {
            for (int i = 0; i < directory_list.Count; i++)
            {
                StreamReader reader = new StreamReader(directory_list[i]);
                string line = reader.ReadLine();

                if (line != null)
                {
                    data_list.Add(line);
                }
                while (line != null)
                {
                    data_list[i].Concat(line);
                    line = reader.ReadLine();
                }

                reader.Close();

                for (int j = 0; j < data_list[i].Length; j++)
                {
                    for (int k = 0; k < keyword_list.Count; k++)
                    {
                        if (data_list[i][j] == keyword_list[k][0])
                        {
                            if (data_list[i].Substring(j, keyword_list[k].Length) == keyword_list[k])
                            {
                                found_list.Add(directory_list[i]);
                            }
                        }
                    }
                }
            }
        }
    }


*/