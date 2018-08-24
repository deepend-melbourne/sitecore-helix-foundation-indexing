using System;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Links;

namespace Sitecore.Foundation.Indexing.Infrastructure.Fields
{
    public class UrlComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            try
            {
                var indexItem = indexable as SitecoreIndexableItem;
                if (indexItem == null)
                {
                    return null;
                }

                var item = indexItem.Item;
                var urlOptions = (UrlOptions)UrlOptions.DefaultOptions.Clone();
                urlOptions.LowercaseUrls = true;
                urlOptions.AlwaysIncludeServerUrl = true;

                return LinkManager.GetItemUrl(item, urlOptions);
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(UrlComputedField)} failed: {ex.Message}", ex, typeof(UrlComputedField));
            }

            return null;
        }
    }
}
