using Glass.Mapper.Sc;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Foundation.DependencyInjection;

namespace Sitecore.Foundation.Indexing.Services
{
    [Service(ServiceType = typeof(ISitecoreService))]
    public class DefaultSitecoreService : SitecoreService
    {
        public DefaultSitecoreService(Database database, string contextName = "Default")
            : base(database, contextName)
        {
        }

        public DefaultSitecoreService(string databaseName, string contextName = "Default")
            : base(databaseName, contextName)
        {
        }

        public DefaultSitecoreService(string databaseName, Glass.Mapper.Context context)
            : base(databaseName, context)
        {
        }

        public DefaultSitecoreService(Database database, Glass.Mapper.Context context)
            : base(database, context)
        {
        }

        public DefaultSitecoreService()
            : this(Settings.GetSetting("DefaultSitecoreService.Database", "master"))
        {
        }
    }
}
