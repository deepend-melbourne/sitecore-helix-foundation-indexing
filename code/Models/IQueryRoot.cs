using Sitecore.Data.Items;

namespace Sitecore.Foundation.Indexing.Models
{
    public interface IQueryRoot
    {
        Item Root { get; set; }
    }
}
