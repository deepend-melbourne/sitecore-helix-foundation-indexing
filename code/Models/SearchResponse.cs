using System.Collections.Generic;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Foundation.Indexing.Search.Models
{
    public class SearchResponse<TModel>
        where TModel : IBaseItem
    {
        /// <summary>
        /// Gets or sets which page of results the result set currently represents.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the number of results per page.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets the total number of results that could possibly be returned
        /// based on the search paramaters provided.
        /// </summary>
        public int TotalSearchResults { get; set; }

        /// <summary>
        /// Gets or sets the result records that were returned.
        /// </summary>
        public IEnumerable<TModel> Results { get; set; } = new TModel[0];

        /// <summary>
        /// Gets the total number of pages of results there are available,
        /// base on the page size and total number of results
        /// </summary>
        public int TotalPages
        {
            get
            {
                return (TotalSearchResults + PageSize - 1) / PageSize;
            }
        }
    }
}
