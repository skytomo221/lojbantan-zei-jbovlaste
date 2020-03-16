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
                [DataMember]
                public int Id { get; set; }
                [DataMember]
                public string Form { get; set; }
            }

            [DataContract]
            public class Translation
            {
                [DataMember]
                public string Title { get; set; }
                [DataMember]
                public List<string> Forms { get; set; }
            }


            [DataContract]
            public class Content
            {
                [DataMember]
                public string Title { get; set; }
                [DataMember]
                public string Text { get; set; }
            }

            [DataContract]
            public class Variation
            {
                [DataMember]
                public string Title { get; set; }
                [DataMember]
                public string Form { get; set; }
            }

            [DataContract]
            public class Relation
            {
                [DataMember]
                public string Title { get; set; }
                [DataMember]
                public WordEntry Entry { get; set; }
            }

            [DataMember]
            public WordEntry Entry { get; set; }
            [DataMember]
            public List<Translation> Translations { get; set; }
            [DataMember]
            public List<string> Tags { get; set; }
            [DataMember]
            public List<Content> Contents { get; set; }
            [DataMember]
            public List<Variation> Variations { get; set; }
            [DataMember]
            public List<Relation> Relations { get; set; }
        }

        [DataContract]
        public class ZpdicClass
        {
            [DataMember]
            public string AlphabetOrder { get; set; }
            [DataMember]
            public string WordOrderType { get; set; }
            [DataMember]
            public List<string> Punctuations { get; set; }
            [DataMember]
            public string IgnoredTranslationRegex { get; set; }
            [DataMember]
            public string PronunciationTitle { get; set; }
            [DataMember]
            public List<string> PlainInformationTitles { get; set; }
            [DataMember]
            public object InformationTitleOrder { get; set; }
            [DataMember]
            public object FormFontFamily { get; set; }
            [DataMember]
            public Word DefaultWord { get; set; }
        }

        [DataMember]
        public List<Word> Words { get; set; }
        [DataMember]
        public ZpdicClass Zpdic { get; set; }
    }
}
