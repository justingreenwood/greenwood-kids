using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameToEarnLegos.Save
{
    public class SavedGame
    {
        private static readonly string SavedGamesFolder = Path.Combine(Environment.CurrentDirectory, "SavedGames");

        [JsonIgnore]
        public string Filename { get; set; }

        public string Name { get; set; }
        public DateTime TimeSaved { get; set; } = DateTime.Now;
        public List<SavedLevel> Levels { get; set; } = new List<SavedLevel>();

        public static List<SavedGame> GetSavedGames()
        {
            var sgs = new List<SavedGame>();
            if (!Directory.Exists(SavedGamesFolder)) Directory.CreateDirectory(SavedGamesFolder);

            var dir = new DirectoryInfo(SavedGamesFolder);
            if (dir.Exists)
            {
                var files = dir.GetFiles("*.sav");
                foreach (var file in files)
                {
                    var xx = Load(file.FullName);
                    if (xx != null) sgs.Add(xx);
                }
            }
            return sgs;
        }

        public static SavedGame? Load(string filePath)
        {
            var sg = JsonSerializer.Deserialize<SavedGame>(File.ReadAllText(filePath), new JsonSerializerOptions
            {
                WriteIndented = true
            });
            if (sg != null) sg.Filename = filePath;
            return sg;
        }
        public void Delete()
        {
            if (File.Exists(this.Filename))
            {
                try
                {
                    File.Delete(this.Filename);
                } catch { }
            }
        }
        public void Save()
        {
            if (!Directory.Exists(SavedGamesFolder)) Directory.CreateDirectory(SavedGamesFolder);

            var text = JsonSerializer.Serialize<SavedGame>(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(
                Path.Combine(SavedGamesFolder, $"saved-game_{this.TimeSaved.ToString("yyyy-MM-dd-HH-mm-ss")}.sav"), 
                text);
        }

        public class SavedLevel
        {
            public string Name { get; set; }
            public bool IsWon { get; set; }
            public int HighScore { get; set; }
            public int CurrentScore { get; set; }

        }
    }
}
