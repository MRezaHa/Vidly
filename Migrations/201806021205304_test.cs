namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class test : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Id=3 WHERE Id=30 ");
        }

        public override void Down()
        {
        }
    }
}
