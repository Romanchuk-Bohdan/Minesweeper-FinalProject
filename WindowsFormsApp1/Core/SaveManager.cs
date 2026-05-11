using System;
using System.IO;
using System.Text.Json;

namespace WindowsFormsApp1.Core
{
    public static class SaveManager
    {
        private const string SaveFolder = "Saves";

        public static void SaveGame(GameMemento memento)
        {
            if (!Directory.Exists(SaveFolder))
            {
                Directory.CreateDirectory(SaveFolder);
            }

            // Зберігання гри для конкретного профілю
            string filePath = Path.Combine(SaveFolder, $"save_{memento.PlayerName}.json");
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(memento, options);
            File.WriteAllText(filePath, jsonString);
        }

        public static GameMemento LoadGame(string playerName)
        {
            string filePath = Path.Combine(SaveFolder, $"save_{playerName}.json");
            if (!File.Exists(filePath))
            {
                return null;
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameMemento>(jsonString);
        }

        public static bool HasSave(string playerName)
        {
            string filePath = Path.Combine(SaveFolder, $"save_{playerName}.json");
            return File.Exists(filePath);
        }

        public static void DeleteSave(string playerName)
        {
            string filePath = Path.Combine(SaveFolder, $"save_{playerName}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}