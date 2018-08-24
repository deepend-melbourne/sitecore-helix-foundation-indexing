using System.Collections.Generic;
using System.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Foundation.Indexing.Models;

namespace Sitecore.Foundation.Indexing.Extensions
{
    public static class SearchExtensions
    {
        /// <summary>
        /// This will apply a predicate expression to the query to only return items that are composed of ANY one of the template IDs passed.
        /// </summary>
        /// <returns></returns>
        public static IQueryable<T> FilterByTemplates<T>(this IQueryable<T> query, IEnumerable<ID> templateIds)
            where T : IndexedItem
        {
            var expression = PredicateBuilder.False<T>();

            foreach (var template in templateIds)
            {
                expression = expression.Or(i => i.AllTemplates.Contains(IdHelper.NormalizeGuid(template)));
            }

            return query.Where(expression);
        }
    }
}
