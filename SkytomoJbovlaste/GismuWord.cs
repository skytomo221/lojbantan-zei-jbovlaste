using System.Collections.Generic;

namespace SkytomoJbovlaste
{
    public class GismuWord
    {
        public string Name { get; set; }
        public bool IsOfficial { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Meanings { get; set; }
        public List<string> Keywords { get; set; }
        public List<string> Original { get; set; }
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
}
