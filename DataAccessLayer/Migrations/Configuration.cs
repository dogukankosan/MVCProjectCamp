namespace DataAccessLayer.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Concrete.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(DataAccessLayer.Concrete.Context context)
        {
        }
    }
}
