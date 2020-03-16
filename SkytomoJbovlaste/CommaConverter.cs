using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.Generic;
using System.Linq;

namespace SkytomoJbovlaste
{
    internal class CommaConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text != string.Empty)
            {
                return text.Split('、').ToList();
            }
            return new List<string>();
        }
    }
}
