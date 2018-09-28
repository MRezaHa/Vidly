namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SetValueToNumberAvailablePropertyInMovieDomainModel : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");

        }

        public override void Down()
        {
        }
    }
}
