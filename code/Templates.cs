using Sitecore.Data;

namespace Sitecore.Foundation.Indexing
{
    public struct Templates
    {
        public struct IndexedItem
        {
            public static ID ID = new ID("{8FD6C8B6-A9A4-4322-947E-90CE3D94916D}");

            public struct Fields
            {
                public const string IncludeInSearchResults_FieldName = "IncludeInSearchResults";
                public const string ResultTitle_FieldName = "ResultTitle";
                public const string ResultSummary_FieldName = "ResultSummary";

                public static readonly ID IncludeInSearchResults = new ID("{8D5C486E-A0E3-4DBE-9A4A-CDFF93594BDA}");

                public static readonly ID ResultTitle = new ID("{EBA169D6-A3F6-4573-A5A7-88A311602D32}");

                public static readonly ID ResultSummary = new ID("{782C517A-51D5-47EC-9DB5-F23B7AF2D861}");
            }
        }
    }
}
