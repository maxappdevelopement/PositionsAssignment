using System;
using System.IO;
using System.Collections.Generic;

namespace Labb2
{
    public class PersistanceHandler
    {
        private readonly string filePath;
        public PersistanceHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public void SavePositions(List<Position> positions)
        {
            {
                if (File.Exists($@"{filePath}"))
                {
                    try
                    {
                        using (StreamWriter file = new StreamWriter($@"{filePath}"))
                        {
                            foreach (Position p in positions)
                            {
                                file.WriteLine(p);
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Failed to save positions");
                    }
                }
                else
                {
                    using (FileStream fileStream = File.Create(filePath));
                }
            }
        }

        public List<Position> LoadPositions()
        {
            List<Position> positions = new List<Position>();
            if (File.Exists($@"{filePath}"))
            {
                try
                {
                    string[] readLines = File.ReadAllLines(filePath);
                    if (readLines.Length > 0)
                    {
                        List<string> textLines = new List<string>(readLines);

                        foreach (string textLine in textLines)
                        {
                            int x = int.Parse(textLine.Split(new[] { '(', ',' })[1]);
                            int y = int.Parse(textLine.Split(new[] { ')', ',' })[1]);
                            positions.Add(new Position(x, y));
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Failed to load positions");
                }
            }         
            return positions;
        }
    }
}
