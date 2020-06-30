using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using CsvHelper;
using Newtonsoft.Json;

namespace SkytomoJbovlaste
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Load(@"gismu.csv");
            Console.WriteLine("CSVファイルの読み込みが完了しました");
            var json = Convert(data);

            // データをJSON形式にシリアル化して、メモリーストリームに出力する。
            MemoryStream st = new MemoryStream(); // メモリーストリームを作成
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(OneToManyJson)); // シリアライザーを作成
            serializer.WriteObject(st, json); // シリアライザーで出力

            // メモリーストリームの内容をコンソールに出力する。
            st.Position = 0;
            StreamReader reader = new StreamReader(st);
            //Console.WriteLine(reader.ReadToEnd());
            using (StreamWriter sw = new StreamWriter(@"skaitomon-zei-jbovlaste.json"))
            {
                // ファイルへの書き込み
                dynamic parsedJson = JsonConvert.DeserializeObject(reader.ReadToEnd());
                sw.WriteLine(JsonConvert.SerializeObject(parsedJson, Formatting.Indented));
            }

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

        public static OneToManyJson Convert(List<GismuWord> collection)
        {
            int id = 1;
            var json = new OneToManyJson();
            foreach (var item in collection)
            {
                var word = new OneToManyJson.Word();
                word.Entry.Form = item.Name;
                word.Entry.Id = id++;
                foreach (var meaning in item.Meanings)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "内容語",
                        Forms = new List<string>() { meaning },
                    });
                }
                if (item.Argument1.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "lo go'i",
                        Forms = item.Argument1,
                    });
                }
                if (item.Argument2.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "lo se go'i",
                        Forms = item.Argument2,
                    });
                }
                if (item.Argument3.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "lo te go'i",
                        Forms = item.Argument3,
                    });
                }
                if (item.Argument4.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "lo ve go'i",
                        Forms = item.Argument4,
                    });
                }
                if (item.Argument5.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "lo xe go'i",
                        Forms = item.Argument5,
                    });
                }
                if (item.Cmevla.Count != 0)
                {
                    word.Translations.Add(new OneToManyJson.Word.Translation()
                    {
                        Title = "la go'i",
                        Forms = item.Cmevla,
                    });
                }
                word.Translations.Add(new OneToManyJson.Word.Translation()
                {
                    Title = "キーワード",
                    Forms = item.Keywords,
                });
                word.Tags = item.Tags;
                if (item.Usage != string.Empty)
                {
                    word.Contents.Add(new OneToManyJson.Word.Content()
                    {
                        Title = "語法",
                        Text = item.Usage,
                    });
                }
                if (item.References != string.Empty)
                {
                    word.Contents.Add(new OneToManyJson.Word.Content()
                    {
                        Title = "参照",
                        Text = item.References,
                    });
                }
                if (item.Tips != string.Empty)
                {
                    word.Contents.Add(new OneToManyJson.Word.Content()
                    {
                        Title = "Tips",
                        Text = item.Tips,
                    });
                }
                if (item.Lojbantan != string.Empty)
                {
                    word.Contents.Add(new OneToManyJson.Word.Content()
                    {
                        Title = "ロジバンたんのメモ",
                        Text = item.Lojbantan,
                    });
                }
                if (item.HowToMemorise != string.Empty)
                {
                    word.Contents.Add(new OneToManyJson.Word.Content()
                    {
                        Title = "覚え方",
                        Text = item.HowToMemorise,
                    });
                }
                if (item.Rafsi1 != string.Empty)
                {
                    word.Variations.Add(new OneToManyJson.Word.Variation()
                    {
                        Title = "rafsi",
                        Form = item.Rafsi1,
                    });
                    json.Words.Add(new OneToManyJson.Word()
                    {
                        Tags = new List<string>() { "語根《ラフシ》" },
                        Entry = new OneToManyJson.Word.WordEntry()
                        {
                            Id = id + 10000,
                            Form = item.Rafsi1.Replace("-", "").Trim(),
                        },
                        Translations = new List<OneToManyJson.Word.Translation>()
                        {
                            new OneToManyJson.Word.Translation ()
                            {
                                Title = "形態素",
                                Forms = new List<string>() {item.Name + "のrafsi" },
                            },
                        },
                    });
                }
                if (item.Rafsi2 != string.Empty)
                {
                    word.Variations.Add(new OneToManyJson.Word.Variation()
                    {
                        Title = "rafsi",
                        Form = item.Rafsi2,
                    });
                    json.Words.Add(new OneToManyJson.Word()
                    {
                        Tags = new List<string>() { "語根《ラフシ》" },
                        Entry = new OneToManyJson.Word.WordEntry()
                        {
                            Id = id + 20000,
                            Form = item.Rafsi2.Replace("-", "").Trim(),
                        },
                        Translations = new List<OneToManyJson.Word.Translation>()
                        {
                            new OneToManyJson.Word.Translation ()
                            {
                                Title = "形態素",
                                Forms = new List<string>() {item.Name + "のrafsi" },
                            },
                        },
                    });
                }
                foreach (var superordinateConcept in item.SuperordinateConcept)
                {
                    if (collection.FindIndex(x => x.Name == superordinateConcept) != -1)
                    {
                        word.Relations.Add(new OneToManyJson.Word.Relation()
                        {
                            Title = "上位概念",
                            Entry = new OneToManyJson.Word.WordEntry()
                            {
                                Id = collection.FindIndex(x => x.Name == superordinateConcept) + 1,
                                Form = superordinateConcept,
                            }
                        });
                    }
                }
                json.Words.Add(word);
                json.Zpdic = new OneToManyJson.ZpdicClass()
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
            }
            return json;
        }
    }
}
