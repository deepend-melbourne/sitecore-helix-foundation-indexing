using System;
using System.Linq;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Diagnostics;
using Sitecore.Foundation.Indexing.Repositories;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Foundation.Indexing.Infrastructure.Fields
{
    public class HasSearchResultFormatterComputedField : IComputedIndexField
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

                return IndexingProviderRepository.SearchResultFormatters.Any(p => p.SupportedTemplates.Any(id => item.IsDerived(id)));
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(HasSearchResultFormatterComputedField)} failed: {ex.Message}", ex, typeof(HasSearchResultFormatterComputedField));
            }

            return null;
        }
    }
}
