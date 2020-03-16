using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SkytomoJbovlaste
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Load(@"..\..\..\skaitomon-zei-jbovlaste.csv");
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

        public static List<Word> Load(string path)
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
