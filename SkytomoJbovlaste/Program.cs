using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace SkytomoJbovlaste
{
    public class Word
    {
        public string Name { get; set; }
        public bool IsOfficial { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Meanings { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> Argument1 { get; set; }
        public List<string> Argument2 { get; set; }
        public List<string> Argument3 { get; set; }
        public List<string> Argument4 { get; set; }
        public List<string> Argument5 { get; set; }
        public List<string> Cmevla { get; set; }
        public string Rafsi1 { get; set; }
        public string Rafsi2 { get; set; }
        public string Usage { get; set; }
        public string References { get; set; }
        public string Tips { get; set; }
        public string Lojbantan { get; set; }
        public string HowToMemorise { get; set; }
        public List<string> SuperordinateConcept { get; set; }
        public string PlaceStructureType { get; set; }
        public string TypeOfArgument1 { get; set; }
        public string TypeOfArgument2 { get; set; }
        public string TypeOfArgument3 { get; set; }
        public string TypeOfArgument4 { get; set; }
        public string TypeOfArgument5 { get; set; }
    }

    public class WordMap : ClassMap<Word>
    {
        public WordMap()
        {
            Map(m => m.Name).Name("gismu");
            Map(m => m.IsOfficial).Name("標準");
            Map(m => m.Tags).Name("タグ").TypeConverter<CommaConverter>();
            Map(m => m.Meanings).Name("内容語").TypeConverter<SemicolonConverter>();
            Map(m => m.Keywords).Name("キーワード").TypeConverter<CommaConverter>();
            Map(m => m.Argument1).Name("lo go'i").TypeConverter<CommaConverter>();
            Map(m => m.Argument2).Name("lo se go'i").TypeConverter<CommaConverter>();
            Map(m => m.Argument3).Name("lo te go'i").TypeConverter<CommaConverter>();
            Map(m => m.Argument4).Name("lo ve go'i").TypeConverter<CommaConverter>();
            Map(m => m.Argument5).Name("lo xe go'i").TypeConverter<CommaConverter>();
            Map(m => m.Cmevla).Name("la go'i").TypeConverter<CommaConverter>();
            Map(m => m.Rafsi1).Name("rafsi");
            Map(m => m.Rafsi2).Name("rafsi2");
            Map(m => m.Usage).Name("語法");
            Map(m => m.References).Name("参照");
            Map(m => m.Tips).Name("Tips");
            Map(m => m.Lojbantan).Name("ロジバンたんのメモ");
            Map(m => m.HowToMemorise).Name("覚え方");
            Map(m => m.SuperordinateConcept).Name("上位概念").TypeConverter<CommaConverter>();
            Map(m => m.PlaceStructureType).Name("PS分類");
            Map(m => m.TypeOfArgument1).Name("@1型");
            Map(m => m.TypeOfArgument2).Name("@2型");
            Map(m => m.TypeOfArgument3).Name("@3型");
            Map(m => m.TypeOfArgument4).Name("@4型");
            Map(m => m.TypeOfArgument5).Name("@5型");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var data = GoLoad(@"..\..\..\skaitomon-zei-jbovlaste.csv");
            var item = data.Find(x => x.Name == "badna");
            Console.WriteLine("【名前】" + item.Name);
            Console.WriteLine("【タグ】");
            foreach (var tag in item.Tags)
            {
                Console.WriteLine(tag);
            }
            Console.WriteLine("【意味】");
            foreach (var meaning in item.Meanings)
            {
                Console.WriteLine(meaning);
            }
            Console.WriteLine("【キーワード】");
            foreach (var keyword in item.Keywords)
            {
                Console.WriteLine(keyword);
            }
        }

        public static List<Word> GoLoad(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<WordMap>();
                return csv.GetRecords<Word>().ToList();
            }
        }
    }
}
