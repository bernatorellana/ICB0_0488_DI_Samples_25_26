using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassesAndClasses.Model
{
    class Classe
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("brief")]
        public string Brief { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("primary_ability")]
        public string PrimaryAbility { get; set; }

        [JsonPropertyName("hit_point_die")]
        public string HitPointDie { get; set; }

        [JsonPropertyName("save_thows")]
        public List<string> SaveThrows { get; set; }

        [JsonPropertyName("skills")]
        public List<string> Skills { get; set; }

        /// <summary>
        /// Llegeix el JSON incrustat com a recurs dins de l’assembly.
        /// El recurs ha d’estar dins de la carpeta "Resources" del projecte
        /// i configurat amb l'acció de compilació "Embedded resource".
        /// </summary>
        public static List<Classe> GetClasses()            
        {
            //string resourceName = "Resources.classes.json";

            //var assembly = Assembly.GetExecutingAssembly();
            //string fullResourceName = $"{assembly.GetName().Name}.{resourceName.Replace('/', '.')}";

            //using Stream? stream = assembly.GetManifestResourceStream(fullResourceName);
            //if (stream == null)
            //    throw new FileNotFoundException($"No s'ha trobat el recurs incrustat: {fullResourceName}");

            //using var reader = new StreamReader(stream);
            //string json = reader.ReadToEnd();

            // Obtenim la ruta de la carpeta Resources al costat de l'executable
            string basePath = Path.Combine(AppContext.BaseDirectory, "Resources");
            string filePath = Path.Combine(basePath, "classes.json");


            if (!File.Exists(filePath))
                throw new FileNotFoundException($"No s'ha trobat el fitxer JSON a: {filePath}");

            string json = File.ReadAllText(filePath);



            // Parsing del JSON
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Classe>? classes = JsonSerializer.Deserialize<List<Classe>>(json, options);

            return classes ?? new List<Classe>();
        }

        public override string ToString()
        {
            return $"{Name} ({PrimaryAbility}) - {Brief}";
        }
    }
}
