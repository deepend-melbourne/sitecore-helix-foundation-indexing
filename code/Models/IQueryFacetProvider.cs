using System.Collections.Generic;

namespace Sitecore.Foundation.Indexing.Models
{
    public interface IQueryFacetProvider
    {
        IEnumerable<IQueryFacet> GetFacets();
    }
}
