using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace WindowsFormsApp1.Core
{
    public class ProfileManager
    {
        private static ProfileManager _instance;
        public static ProfileManager Instance
        {
            get
            {
                if (_instance == null) _instance = new ProfileManager();
                return _instance;
            }
        }

        private const string FilePath = "profiles.json";
        private List<Profile> _profiles;
        public Profile CurrentProfile { get; private set; }

        private ProfileManager()
        {
            _profiles = new List<Profile>();
            LoadProfiles();
        }

        // Техніка: Encapsulate Collection
        public IReadOnlyList<Profile> GetAllProfiles() => _profiles.AsReadOnly();

        public void CreateProfile(string name)
        {
            var newProfile = new Profile(name);
            _profiles.Add(newProfile);
            SaveProfiles();
        }

        public void SetCurrentProfile(string name)
        {
            foreach (var profile in _profiles)
            {
                if (profile.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    CurrentProfile = profile;
                    return;
                }
            }
            throw new Exception("Профіль не знайдено!");
        }

        public void SaveProfiles()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(_profiles, options);
                File.WriteAllText(FilePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка збереження профілів: {ex.Message}");
            }
        }

        private void LoadProfiles()
        {
            if (!File.Exists(FilePath))
            {
                CreateProfile("Guest");
                SetCurrentProfile("Guest");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(FilePath);
                _profiles = JsonSerializer.Deserialize<List<Profile>>(jsonString) ?? new List<Profile>();
                if (_profiles.Count > 0) CurrentProfile = _profiles[0];
            }
            catch
            {
                _profiles = new List<Profile>();
                CreateProfile("Guest");
                SetCurrentProfile("Guest");
            }
        }
    }
}