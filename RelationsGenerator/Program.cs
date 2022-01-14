using Otamajakushi;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace GismuRelatedWordsGenerator
{
    class Program
    {
        public class Thesaurus
        {
            [JsonPropertyName("thesaurus")]
            public TagFamily[] TagFamilies { get; set; }
        }

        public class TagFamily
        {
            [JsonPropertyName("tag")]
            public string Tag { get; set; }

            [JsonPropertyName("categories")]
            public Category[] Categories { get; set; }
        }

        public class Category
        {
            [JsonPropertyName("groups")]
            public Group[] Groups { get; set; }
        }

        public class Group
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("relations")]
            public string[] Relations { get; set; }
        }

        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"lojbantan-zei-jbovlaste.json");
            var dictionary = OneToManyJsonSerializer.Deserialize(json);
            Thesaurus thesaurus = JsonSerializer.Deserialize<Thesaurus>(File.ReadAllText(@"relations.json"));

            dictionary.Words.ForEach(word => word.Relations = new List<Relation>());

            foreach (var tagFamily in thesaurus.TagFamilies)
            {
                var words = dictionary.Words.Where(word => word.Tags.Contains(tagFamily.Tag));
                foreach (var category in tagFamily.Categories)
                {
                    var relations = new List<Relation>();
                    foreach (var group in category.Groups)
                    {
                        foreach (var relationWord in group.Relations)
                        {
                            relations.Add(new Relation
                            {
                                Title = group.Title,
                                Entry = dictionary.Words.First(word => word.Entry.Form == relationWord).Entry
                            });
                        }
                    }
                    foreach (var group in category.Groups)
                    {
                        foreach (var relationWord in group.Relations)
                        {
                            var word = dictionary.Words.First(w => w.Entry.Form == relationWord);
                            word.Relations = word.Relations.Union(relations).ToList();
                        }
                    }
                }
            }

            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@"output.json", json);
        }
    }
}
