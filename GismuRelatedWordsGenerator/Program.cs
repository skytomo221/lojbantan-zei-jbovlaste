using Otamajakushi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace GismuRelatedWordsGenerator
{
    struct GismuRelation
    {
        public string Title { get; set; }
        public List<string> Entries { get; set; }
    }

    class Program
    {
        private static readonly List<GismuRelation> gismuRelations = new List<GismuRelation> {
            new GismuRelation {
                Title = "色に関するギスム",
                Entries = new List<string> {
                    "blabi",
                    "blanu",
                    "bunre",
                    "cicna",
                    "crino",
                    "grusi",
                    "narju",
                    "nukni",
                    "pelxu",
                    "xekri",
                    "xunre",
                    "zirpu",
                }
            }
        };

        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"lojbantan-zei-jbovlaste.json");
            var dictionary = OneToManyJsonSerializer.Deserialize(json);

            foreach (var gismuRelation in gismuRelations)
            {
                var relation = gismuRelation.Entries.Select(
                    gismu => new Relation
                    {
                        Title = gismuRelation.Title,
                        Entry = dictionary.Words.First(word => word.Entry.Form == gismu).Entry
                    }
                );
                foreach (var gismu in gismuRelation.Entries)
                {
                    var word = dictionary.Words.First(word => word.Entry.Form == gismu);
                    word.Relations = word.Relations.Union(relation).ToList();
                }
            }

            var options = new System.Text.Json.JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@"output.json", json);
        }
    }
}
