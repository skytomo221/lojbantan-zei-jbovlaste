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
            },
            new GismuRelation {
                Title = "国と地域に関するギスム",
                Entries = new List<string> {
                    "baxso",
                    "bemro",
                    "bengo",
                    "bindo",
                    "brazo",
                    "brito",
                    "dotco",
                    "dzipo",
                    "filso",
                    "fraso",
                    "friko",
                    "gento",
                    "glico",
                    "jerxo",
                    "jordo",
                    "jungo",
                    "kadno",
                    "ketco",
                    "kisto",
                    "latmo",
                    "libjo",
                    "lojbo",
                    "lubno",
                    "meljo",
                    "merko",
                    "mexno",
                    "misro",
                    "morko",
                    "polno",
                    "ponjo",
                    "porto",
                    "rakso",
                    "ropno",
                    "rusko",
                    "sadjo",
                    "semto",
                    "sirxo",
                    "skoto",
                    "slovo",
                    "softo",
                    "spano",
                    "sralo",
                    "srito",
                    "vukro",
                    "xazdo",
                    "xebro",
                    "xelso",
                    "xindo",
                    "xispo",
                    "xrabo",
                    "xurdo",
                }
            },
            new GismuRelation {
                Title = "味に関するギスム",
                Entries = new List<string> {
                    "cpina",
                    "titla",
                    "kurki",
                    "slari",
                }
            },
            new GismuRelation {
                Title = "季節に関するギスム",
                Entries = new List<string> {
                    "vensa",
                    "crisa",
                    "critu",
                    "dunra",
                }
            },
            new GismuRelation {
                Title = "時間帯に関するギスム",
                Entries = new List<string> {
                    "murse",
                    "cerni",
                    "donri",
                    "vanci",
                    "nicte",
                }
            },
            new GismuRelation {
                Title = "期間に関するギスム",
                Entries = new List<string> {
                    "snidu",
                    "mentu",
                    "cacra",
                    "djedi",
                    "masti",
                }
            },
        };

        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"lojbantan-zei-jbovlaste.json");
            var dictionary = OneToManyJsonSerializer.Deserialize(json);

            foreach (var gismuRelation in gismuRelations)
            {
                var entries = gismuRelation.Entries;
                var relations = entries.Select(
                    gismu => new Relation
                    {
                        Title = gismuRelation.Title,
                        Entry = dictionary.Words.First(word => word.Entry.Form == gismu).Entry
                    }
                );
                foreach (var gismu in entries)
                {
                    var word = dictionary.Words.First(word => word.Entry.Form == gismu);
                    word.Relations = word.Relations.Union(relations).ToList();
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
