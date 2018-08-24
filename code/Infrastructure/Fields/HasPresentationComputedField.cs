using System;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Foundation.Indexing.Infrastructure.Fields
{
    public class HasPresentationComputedField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            try
            {
                var i = (Item)(indexable as SitecoreIndexableItem);
                if (i.HasLayout())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{nameof(HasPresentationComputedField)} failed: {ex.Message}", ex, typeof(HasPresentationComputedField));
            }

            return null;
        }
    }
}
