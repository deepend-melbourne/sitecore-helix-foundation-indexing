using Sitecore.Data;

namespace Sitecore.Foundation.Indexing.Search.Models
{
    public abstract class SearchRequest
    {
        /// <summary>
        /// The page of results to return, based on the give page size. The first page
        /// should be represented by 1, and not be zero based.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of records to return per page.
        /// </summary>
        public int PageSize { get; set; } = 12;

        /// <summary>
        /// Pre calculates how many records to skip, based on the values of Page and PageSize.
        /// </summary>
        public int Skip
        {
            get
            {
                return PageZeroBased * PageSize;
            }
        }

        /// <summary>
        /// Page needs to be zero based in queries, but convention is for the first page
        /// to be represented by 1 in the UI. This will return a zero based version of the page.
        /// </summary>
        public int PageZeroBased
        {
            get
            {
                return Page < 1 ? 0 : Page - 1;
            }
        }

        /// <summary>
        /// The path to an item which all search result items should
        /// be a descendant of in order to be returned. In most cases,
        /// this will be the path to the root node for the website
        /// </summary>
        public string RootPath { get; set; }

        /// <summary>
        /// One or more template IDs that all result items
        /// should be composed of in order to be returned.
        /// </summary>
        public ID[] TemplateIds { get; set; }

        /// <summary>
        /// You can manually set the index to be used in the search. If
        /// this is not set, then the BaseSearchService will default to
        /// use the sitecore_{contextdb}_index, where {contextdb} will be
        /// replaced with the context db (master or web). In most cases,
        /// you will not need to manually set this.
        /// </summary>
        public virtual string Index { get; } = null;
    }
}
