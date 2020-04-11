namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'77807af8-d31c-4251-92a3-8182d12449f8', N'admin@vidly.com', 0, N'AH61IeQc/TdVu6unXw1SCHSr5WfeNrV7pDgfFPvmZ2C5Al5Z5VIzCO9x1aNNKfTobw==', N'342e8bd6-61dc-4b18-ac69-51962978a590', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a8c74747-b49f-4308-80c2-c6300131208c', N'guest@vidly.com', 0, N'AGk/SS8pbyo9LrBIBSpJ65RAOSUnC6agQw+2YhfekWfz2b4enP+UMwTw/pKtUVMAZA==', N'40eab2be-dd60-493b-9f5a-7e4ebe7ed1a7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
");

            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e69b4680-0f87-4c4e-97f2-ad2f0073c1ea', N'CanManageMovies')
");

            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'77807af8-d31c-4251-92a3-8182d12449f8', N'e69b4680-0f87-4c4e-97f2-ad2f0073c1ea')
");
        }
        
        public override void Down()
        {
        }
    }
}
