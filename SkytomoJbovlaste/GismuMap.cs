using CsvHelper.Configuration;

namespace SkytomoJbovlaste
{
    public class GismuMap : ClassMap<GismuWord>
    {
        public GismuMap()
        {
            Map(m => m.Name).Name("gismu");
            Map(m => m.IsOfficial).Name("標準");
            Map(m => m.Tags).Name("タグ").TypeConverter<CommaConverter>();
            Map(m => m.Meanings).Name("内容語").TypeConverter<SemicolonConverter>();
            Map(m => m.Keywords).Name("キーワード").TypeConverter<CommaConverter>();
            Map(m => m.Original).Name("原文").TypeConverter<CommaConverter>();
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
}
