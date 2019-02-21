using System.Linq;
using Glass.Mapper.Sc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Items;
using Sitecore.Foundation.Indexing.Extensions;
using Sitecore.Foundation.Indexing.Models;
using Sitecore.Foundation.Indexing.Search.Models;
using Sitecore.Foundation.Models.Models.Interfaces;

namespace Sitecore.Foundation.Indexing.Services
{
    public abstract class SearchService<TSearchResultItem, TSearchRequest, TModel>
            where TSearchResultItem : IndexedItem
            where TSearchRequest : SearchRequest
            where TModel : class, IBaseItem
    {
        public SearchService(DefaultSitecoreService sitecoreService)
        {
            SitecoreService = sitecoreService;
        }

        /// <summary>
        /// Gets the default index to fallback to if the request doesn't specify an index.
        /// </summary>
        protected string DefaultIndex
        {
            get
            {
                return $"sitecore_{Context.Database.Name}_index";
            }
        }

        /// <summary>
        /// Gets glass Mapper sitecore service
        /// </summary>
        protected ISitecoreService SitecoreService { get; }

        public SearchResponse<TModel> Search(TSearchRequest request)
        {
            using (var context = ContentSearchManager.GetIndex(string.IsNullOrEmpty(request.Index) ? DefaultIndex : request.Index).CreateSearchContext())
            {
                var query = context.GetQueryable<TSearchResultItem>();

                if (!string.IsNullOrEmpty(request.RootPath))
                {
                    query = query.Where(u => u.Path.StartsWith(request.RootPath));
                }

                if (request.TemplateIds != null && request.TemplateIds.Any())
                {
                    query = query.FilterByTemplates(request.TemplateIds);
                }

                query = ApplyPredicates(query, request);
                query = ApplyFacets(query, request);

                var results = query.GetResults();
                var facets = query.GetFacets();

                var items = results.Hits.Skip(request.Skip)
                            .Take(request.PageSize)
                            .Select(u => u.Document.GetItem())
                            .Select(Cast)
                            .Where(u => u != null) // Protects against items in the index that are no longer in Sitecore.
                            .ToList();

                return new SearchResponse<TModel>
                {
                    Page = request.Page,
                    PageSize = request.PageSize,
                    TotalSearchResults = results.TotalSearchResults,
                    Results = items,
                    FacetResults = facets
                };
            }
        }

        /// <summary>
        /// This is the extension point that is called by the Search method, which allows your deriving class
        /// to apply custom predicate logic in order to filter the search results.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract IQueryable<TSearchResultItem> ApplyPredicates(IQueryable<TSearchResultItem> query, TSearchRequest request);

        /// <summary>
        /// This is the extension point that is called by the Search method, which allows your deriving class
        /// to apply custom facets logic in order to facet the search results.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        protected abstract IQueryable<TSearchResultItem> ApplyFacets(IQueryable<TSearchResultItem> query, TSearchRequest request);

        protected virtual TModel Cast(Item item) => SitecoreService.Cast<TModel>(item);
    }
}
