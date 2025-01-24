using System.Text.Json;
using bibliotech.Models;


namespace bibliotech.Helpers
{
    public static class JsonFileHelper
    {
        public static List<Livre> LoadLivresFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Le fichier JSON n'existe pas.", filePath);

            var jsonContent = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Livre>>(jsonContent) ?? new List<Livre>();
        }
    }
}
