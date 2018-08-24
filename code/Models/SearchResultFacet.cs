using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Models
{
    internal class SearchResultFacet : ISearchResultFacet
    {
        public IEnumerable<ISearchResultFacetValue> Values { get; set; }

        public IQueryFacet Definition { get; set; }
    }
}
