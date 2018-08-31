namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ae71c480-abac-48fb-b657-3d8e743881bd', N'Reza@vidly.com', 0, N'AJxURiJ6UNOGAra47+c+JoN+KdKJGTl1NOxA1tWx9xq2aWQGxsD7ifQBnt6LUd3upA==', N'794aacd5-2e7b-4b51-ae6c-af3743558be9', NULL, 0, 0, NULL, 1, 0, N'Reza@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc5aae36-8af8-4aba-9e08-7b6b827feaff', N'admin@vidly.com', 0, N'AFpw+NOWuq1mnAUSWjsm2F3qTlGOEqeB38Be/zme2SYHZ+9YunzSfAOs7fvLf8cWYw==', N'4dc7e1f9-6103-44cc-a0e3-09decbe84335', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea709704-6492-4643-a1b1-0bafc5459a4a', N'guest@vidly.com', 0, N'AHDZcLjsg7cq1dzaOtDmp9fzaElszmsbK8IPYAtIxQg/4hl6sliJb1/hMw5wfqD+8Q==', N'cae75785-5ca1-4f80-a0db-ccfb18168cc4', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6e1280ad-6e23-495d-ada9-8d6e8023ac6a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cc5aae36-8af8-4aba-9e08-7b6b827feaff', N'6e1280ad-6e23-495d-ada9-8d6e8023ac6a')

");
        }

        public override void Down()
        {
        }
    }
}
