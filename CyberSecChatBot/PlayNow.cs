using System;
using System.IO;
using System.Media;

namespace CyberSecChatBot
{
  public class PlayNow
    {
        public static void PlayGreeting()
        {
            try
            {
                string projectPath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "");
                string audioPath = Path.Combine(projectPath, "Welcome message.wav");
                using (SoundPlayer player = new SoundPlayer(audioPath))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }
    }
}

