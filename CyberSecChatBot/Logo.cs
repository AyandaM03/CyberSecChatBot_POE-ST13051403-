using System;
using System.Drawing;
using System.IO;

namespace CyberSecChatBot
{
    public class Logo
    {
        public static void Display()
        {
            // Display heading
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("+--------------------------------------------------+");
            Console.WriteLine("|         Hi, I'm your personalized chatbot!       |");
            Console.WriteLine("+--------------------------------------------------+");

            // Get full project path and image
            string path_project = AppDomain.CurrentDomain.BaseDirectory;
            string new_path_project = path_project.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(new_path_project, "chatbot image.jpg");

            // Load and resize image
            Bitmap image = new Bitmap(full_path);
            image = new Bitmap(image, new Size(70, 30)); // use smaller size for visibility

            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    char asciiChar;
                    if (grayScale >= 230)
                        asciiChar = ' ';
                    else if (grayScale >= 200)
                        asciiChar = '.';
                    else if (grayScale >= 180)
                        asciiChar = ':';
                    else if (grayScale >= 160)
                        asciiChar = '-';
                    else if (grayScale >= 130)
                        asciiChar = '=';
                    else if (grayScale >= 100)
                        asciiChar = '+';
                    else if (grayScale >= 70)
                        asciiChar = '*';
                    else if (grayScale >= 50)
                        asciiChar = '%';
                    else if (grayScale >= 20)
                        asciiChar = '#';
                    else
                        asciiChar = '@';

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(asciiChar);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
