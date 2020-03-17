using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SkytomoJbovlaste
{
    [DataContract]
    public class OneToManyJson
    {
        [DataContract]
        public class Word
        {
            [DataContract]
            public class WordEntry
            {
                [DataMember(Name = "id")]
                public int Id { get; set; }
                [DataMember(Name = "form")]
                public string Form { get; set; }
            }

            [DataContract]
            public class Translation
            {
                [DataMember(Name = "title")]
                public string Title { get; set; }
                [DataMember(Name = "forms")]
                public List<string> Forms { get; set; } = new List<string>();
            }


            [DataContract]
            public class Content
            {
                [DataMember(Name = "title")]
                public string Title { get; set; }
                [DataMember(Name = "text")]
                public string Text { get; set; }
            }

            [DataContract]
            public class Variation
            {
                [DataMember(Name = "title")]
                public string Title { get; set; }
                [DataMember(Name = "form")]
                public string Form { get; set; }
            }

            [DataContract]
            public class Relation
            {
                [DataMember(Name = "title")]
                public string Title { get; set; }
                [DataMember(Name = "entry")]
                public WordEntry Entry { get; set; } = new WordEntry();
            }

            [DataMember(Name = "entry")]
            public WordEntry Entry { get; set; } = new WordEntry();
            [DataMember(Name = "translations")]
            public List<Translation> Translations { get; set; } = new List<Translation>();
            [DataMember(Name = "tags")]
            public List<string> Tags { get; set; }
            [DataMember(Name = "contents")]
            public List<Content> Contents { get; set; } = new List<Content>();
            [DataMember(Name = "variations")]
            public List<Variation> Variations { get; set; } = new List<Variation>();
            [DataMember(Name = "relations")]
            public List<Relation> Relations { get; set; } = new List<Relation>();
        }

        [DataContract]
        public class ZpdicClass
        {
            [DataMember(Name = "alphabetOrder")]
            public string AlphabetOrder { get; set; }
            [DataMember(Name = "wordOrderType")]
            public string WordOrderType { get; set; }
            [DataMember(Name = "punctuations")]
            public List<string> Punctuations { get; set; }
            [DataMember(Name = "ignoredTranslationRegex")]
            public string IgnoredTranslationRegex { get; set; }
            [DataMember(Name = "pronunciationTitle")]
            public string PronunciationTitle { get; set; }
            [DataMember(Name = "plainInformationTitles")]
            public List<string> PlainInformationTitles { get; set; } = new List<string>();
            [DataMember(Name = "informationTitleOrder")]
            public object InformationTitleOrder { get; set; }
            [DataMember(Name = "formFontFamily")]
            public object FormFontFamily { get; set; }
            [DataMember(Name = "defaultWord")]
            public Word DefaultWord { get; set; }
        }

        [DataMember(Name = "words")]
        public List<Word> Words { get; set; } = new List<Word>();
        [DataMember(Name = "zpdic")]
        public ZpdicClass Zpdic { get; set; }
    }
}
