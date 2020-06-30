using CsvHelper;
using Otamajakushi;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SkytomoJbovlaste
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Load(@"gismu.csv");
            Console.WriteLine("CSVファイルの読み込みが完了しました");

            var dictionary = Convert(data);
            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var json = OneToManyJsonSerializer.Serialize(dictionary, options);
            File.WriteAllText(@"output.json", json);
            Console.WriteLine("JSONファイルの書き込みが完了しました");
        }

        public static List<GismuWord> Load(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<GismuMap>();
                return csv.GetRecords<GismuWord>().ToList();
            }
        }

        public static OneToManyJson Convert(List<GismuWord> gismus)
        {
            var dictionary = new OneToManyJson();
            foreach (var gismu in gismus)
            {
                var word = new Word
                {
                    Entry = new Entry
                    {
                        Form = gismu.Name,
                    },
                    Translations = new List<Translation>(),
                    Tags = gismu.Tags,
                };
                foreach (var meaning in gismu.Meanings)
                {
                    word.Translations.Add(new Translation()
                    {
                        Title = "内容語",
                        Forms = new List<string>() { meaning },
                    });
                }
                var translationsTuples = new List<Tuple<string, List<string>>>
                {
                    new Tuple<string, List<string>> ("lo go'i", gismu.Argument1),
                    new Tuple<string, List<string>> ("lo se go'i", gismu.Argument2),
                    new Tuple<string, List<string>> ("lo te go'i", gismu.Argument3),
                    new Tuple<string, List<string>> ("lo ve go'i", gismu.Argument4),
                    new Tuple<string, List<string>> ("lo xe go'i", gismu.Argument5),
                    new Tuple<string, List<string>> ("la go'i", gismu.Cmevla),
                    new Tuple<string, List<string>> ("キーワード", gismu.Keywords),
                };
                foreach (var (title, forms) in translationsTuples)
                {
                    var newforms = forms.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    if (newforms.Count > 0)
                    {
                        word.Translations.Add(new Translation()
                        {
                            Title = title,
                            Forms = newforms,
                        });
                    }
                }
                var contentsTuples = new List<Tuple<string, string>>
                {
                    new Tuple<string, string> ("語法", gismu.Usage),
                    new Tuple<string, string> ("参照", gismu.References),
                    new Tuple<string, string> ("Tips", gismu.Tips),
                    new Tuple<string, string> ("ロジバンたんのメモ", gismu.Lojbantan),
                    new Tuple<string, string> ("覚え方", gismu.HowToMemorise),
                };
                foreach (var (title, text) in contentsTuples)
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        word.Contents.Add(new Content()
                        {
                            Title = title,
                            Text = text,
                        });
                    }
                }
                var variations = new List<string>
                {
                    gismu.Rafsi1,
                    gismu.Rafsi2,
                };
                foreach (var variation in variations)
                {
                    if (!string.IsNullOrEmpty(variation))
                    {
                        word.Variations.Add(new Variation()
                        {
                            Title = "rafsi",
                            Form = variation,
                        });
                        dictionary.AddWord(new Word()
                        {
                            Entry = new Entry
                            {
                                Form = variation.Replace("-", string.Empty).Trim(),
                            },
                            Tags = new List<string>() { "語根《ラフシ》" },
                            Translations = new List<Translation>()
                            {
                                new Translation ()
                                {
                                    Title = "形態素",
                                    Forms = new List<string>() {gismu.Name + "のrafsi" },
                                },
                            },
                            Relations = new List<Relation>
                            {
                                new Relation
                                {
                                    Title = "gismu",
                                    Entry = word.Entry,
                                }
                            }
                        });
                    }
                }
                dictionary.AddWord(word);
            }
            foreach (var gismu in gismus)
            {
                foreach (var superordinateConcept in gismu.SuperordinateConcept)
                {
                    foreach (var word in dictionary.Words.FindAll(x => x.Entry.Form == superordinateConcept))
                    {
                        dictionary.Words.Find(x => x.Entry.Form == gismu.Name).Relations.Add(new Relation()
                        {
                            Title = "上位概念",
                            Entry = word.Entry,
                        });
                    }
                }
            }
            dictionary.Zpdic = new Zpdic()
            {
                AlphabetOrder = string.Empty,
                WordOrderType = "UNICODE",
                Punctuations = new List<string>() { ",", "、" },
                IgnoredTranslationRegex = "\\s*\\(.+?\\)\\s*|\\s*（.+?）\\s*|～",
                PronunciationTitle = "発音",
                PlainInformationTitles = new List<string>()
                {
                    "The Complete Lojban Language",
                    "はじめてのロジバン 第2版",
                    "ko lojbo .iu ロジバン入門",
                    "Lojban Wave Lessons",
                    "はじめてのロジバン"
                },
                InformationTitleOrder = null,
                FormFontFamily = null,
            };
            dictionary.RelationIdCompletion();
            return dictionary;
        }
    }
}
