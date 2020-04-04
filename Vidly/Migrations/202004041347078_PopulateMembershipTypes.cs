namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("insert into dbo.Genres ([Name]) values ('Action');");
            Sql("insert into dbo.Genres ([Name]) values ('Comedy');");
            Sql("insert into dbo.Genres ([Name]) values ('Family');");
            Sql("insert into dbo.Genres ([Name]) values ('Romance');");

            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, [Name]) values (1,0,0,0,'Pay as You Go');");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, [Name]) values (2,30,1,10,'Monthly');");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, [Name]) values (3,90,3,15,'Quarterly');");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, [Name]) values (4,300,12,20,'Annual');");

        }

        public override void Down()
        {
            Sql("delete from MembershipTypes;");
            Sql("delete from Genres;");
        }

    }
}
