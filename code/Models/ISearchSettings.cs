using System.Collections.Generic;
using Sitecore.Data;

namespace Sitecore.Foundation.Indexing.Models
{
    public interface ISearchSettings : IQueryRoot
    {
        IEnumerable<ID> Templates { get; }

        bool MustHaveFormatter { get; }
    }
}
