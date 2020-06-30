using CsvHelper.Configuration;

namespace SkytomoJbovlaste
{
    public class CmavoMap : ClassMap<CmavoWord>
    {
        public CmavoMap()
        {
            Map(m => m.Selmaho).Name("セルマホ");
            Map(m => m.Name).Name("cmavo");
            Map(m => m.Type).Name("種類");
            Map(m => m.Tags).Name("タグ").TypeConverter<CommaConverter>();
            Map(m => m.Meanings).Name("機能語").TypeConverter<SemicolonConverter>();
            Map(m => m.Keywords).Name("キーワード").TypeConverter<CommaConverter>();
            Map(m => m.Rafsi1).Name("rafsi");
            Map(m => m.Rafsi2).Name("rafsi2");
            Map(m => m.Usage).Name("語法");
            Map(m => m.Grammar).Name("文法");
            Map(m => m.Etymology).Name("語源");
            Map(m => m.Lojbantan).Name("ロジバンたんのメモ");
            Map(m => m.HowToMemorise).Name("覚え方");
        }
    }
}
