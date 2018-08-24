using System.Collections.Generic;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Foundation.Indexing.Models
{
    public class SearchSettingsBase : ISearchSettings
    {
        public Item Root { get; set; }

        public IEnumerable<ID> Templates { get; set; }

        public bool MustHaveFormatter { get; set; } = false;
    }
}
