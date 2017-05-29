namespace PetShop.Helpers
{
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;
    using System.Reflection;
    public class NHibernateHelper
    {
        public static ISession Session { get; private set; }
        private static ISession OpenSession()
        {
            var cfg = new Configuration()
            .DataBaseIntegration(db => {
                db.ConnectionString = @"Server=.\SQLEXPRESS;initial catalog=PetShop;Integrated Security=SSPI;";
                db.Dialect<MsSql2012Dialect>();
            });
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);
            new SchemaUpdate(cfg).Execute(true, true);
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
        static NHibernateHelper()
        {
            //Session.Flush();
            Session = OpenSession();
        }
    }
}