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
        private static readonly List<List<GismuRelation>> gismuRelationsList = new List<List<GismuRelation>> {
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "動作に関するギスム",
                    Entries = new List<string> {
                        "bajra",
                        "banro",
                        "basti",
                        "batci",
                        "benji",
                        "bevri",
                        "bikla",
                        "binxo",
                        "canci",
                        "canja",
                        "carna",
                        "carvi",
                        "casnu",
                        "catke",
                        "catke",
                        "catra",
                        "cecla",
                        "cikna",
                        "cikre",
                        "cilre",
                        "cinba",
                        "cinmo",
                        "cirko",
                        "ciska",
                        "cisma",
                        "citka",
                        "ckasu",
                        "cladu",
                        "cliva",
                        "cmila",
                        "cmoni",
                        "cpacu",
                        "danfu",
                        "dansu",
                        "darxi",
                        "dirce",
                        "dunda",
                        "falnu",
                        "farlu",
                        "fliba",
                        "janli",
                        "jersi",
                        "jgari",
                        "jinru",
                        "jivbu",
                        "klama",
                        "lacpu",
                        "lebna",
                        "limna",
                        "parji",
                        "pencu",
                        "pinxe",
                        "ralte",
                        "renro",
                        "rirni",
                        "sakli",
                        "sanga",
                        "sanji",
                        "sanli",
                        "satre",
                        "senci",
                        "stapa",
                        "tadni",
                        "tikpa",
                        "toknu",
                        "tunlo",
                        "vamtu",
                        "vasru",
                        "vasxu",
                        "vofli",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "色に関する同一構造のギスム",
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
                    Title = "物質の性質に関するギスム",
                    Entries = new List<string> {
                        "jdari",
                        "pruni",
                        "ranti",
                        "viknu",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "数学に関するギスム",
                    Entries = new List<string> {
                        "namcu",
                        "tanjo",
                        "mekso",
                        "sinso",
                        "pilji",
                        "radno",
                        "frinu",
                        "dugri",
                        "saclu",
                        "sumji",
                        "xadba",
                        "sumti",
                        "tenfa",
                        "klani",
                        "kancu",
                        "kanji",
                        "fancu",
                        "dilcu",
                        "vimcu",
                        "girzu",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "食事に関する動作のギスム",
                    Entries = new List<string> {
                        "citka",
                        "pinxe",
                    }
                },
                new GismuRelation {
                    Title = "食物に関するギスム",
                    Entries = new List<string> {
                        "birje",
                        "cakla",
                        "cirla",
                        "ckafi",
                        "jduli",
                        "ladru",
                        "lante",
                        "nanba",
                        "narge",
                        "salta",
                        "sanmi",
                        "sanso",
                        "silna",
                        "sodva",
                        "stagi",
                        "stasu",
                        "tcati",
                        "vanju",
                    }
                },
                new GismuRelation {
                    Title = "食器に関するギスム",
                    Entries = new List<string> {
                        "palta",
                        "palne",
                        "smuci",
                        "cinza",
                    }
                },
                new GismuRelation {
                    Title = "味覚に関する同一構造のギスム",
                    Entries = new List<string> {
                        "cpina",
                        "titla",
                        "kurki",
                        "slari",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "衣類に関する状態のギスム",
                    Entries = new List<string> {
                        "dasni",
                        "lunbe",
                    }
                },
                new GismuRelation {
                    Title = "衣類に関する同一構造のギスム",
                    Entries = new List<string> {
                        "mapku",
                        "creka",
                        "kosta",
                        "palku",
                        "skaci",
                        "cutci",
                        "smoka",
                        "dasri",
                        "genxu",
                        "grana",
                        "jesni",
                    }
                },
                new GismuRelation {
                    Title = "衣類に関するその他のギスム",
                    Entries = new List<string> {
                        "daski",
                        "gluta",
                        "taxfu",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "国と地域に関する同一構造のギスム",
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
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "生物に関する同一構造のギスム",
                    Entries = new List<string> {
                        "srasu",
                        "stani",
                        "badna",
                        "balji",
                        "bavmi",
                        "cindu",
                        "cunmi",
                        "dembi",
                        "gurni",
                        "jbari",
                        "kobli",
                        "marna",
                        "mavji",
                        "maxri",
                        "mraji",
                        "pezli",
                        "rismi",
                        "rozgu",
                        "samcu",
                        "sluni",
                        "sobde",
                        "sorgu",
                        "sunga",
                        "tamca",
                        "tujli",
                        "xruba",
                        "xruki",
                        "xrula",
                        "zumri",
                        "curnu",
                        "banfi",
                        "mabru",
                        "datka",
                        "bakni",
                        "cinfo",
                        "gerku",
                        "cipni",
                        "kanba",
                        "kumte",
                        "lanme",
                        "mlatu",
                        "ractu",
                        "ratcu",
                        "smani",
                        "xanto",
                        "xarju",
                        "xasli",
                        "xirma",
                        "finpe",
                        "respa",
                        "since",
                        "cinki",
                        "jalra",
                        "jukni",
                        "manti",
                        "sfani",
                    }
                },
                new GismuRelation {
                    Title = "生体に関する同一構造のギスム",
                    Entries = new List<string> {
                        "ciblu",
                        "kalci",
                        "pimlu",
                        "pinca",
                        "rectu",
                        "sovda",
                    }
                },
            },
            new List<GismuRelation> {
                new GismuRelation {
                    Title = "季節に関する同一構造のギスム",
                    Entries = new List<string> {
                        "vensa",
                        "crisa",
                        "critu",
                        "dunra",
                    }
                },
                new GismuRelation {
                    Title = "時間帯に関する同一構造のギスム",
                    Entries = new List<string> {
                        "murse",
                        "cerni",
                        "donri",
                        "vanci",
                        "nicte",
                    }
                },
                new GismuRelation {
                    Title = "期間に関する同一構造のギスム",
                    Entries = new List<string> {
                        "snidu",
                        "mentu",
                        "cacra",
                        "djedi",
                        "masti",
                        "nanca"
                    }
                },
            },
        };

        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"lojbantan-zei-jbovlaste.json");
            var dictionary = OneToManyJsonSerializer.Deserialize(json);

            foreach (var gismuRelations in gismuRelationsList)
            {
                var relations = new List<Relation>();
                foreach (var gismuRelation in gismuRelations)
                {
                    gismuRelation.Entries.ForEach(
                        gismu => relations.Add(new Relation
                        {
                            Title = gismuRelation.Title,
                            Entry = dictionary.Words.First(word => word.Entry.Form == gismu).Entry
                        }
                    ));
                }
                foreach (var gismuRelation in gismuRelations)
                {
                    foreach (var gismu in gismuRelation.Entries)
                    {
                        var word = dictionary.Words.First(word => word.Entry.Form == gismu);
                        word.Relations = word.Relations.Union(relations).ToList();
                    }
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
