namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate : DbMigration
    {
        public override void Up()
        {
            Sql("delete from Customers;");
            Sql("delete from Movies;");
            Sql("delete from MembershipTypes;");
            Sql("delete from Genres;");
            
            Sql("insert into dbo.Genres (Id, [Name]) values (1,'Action');");
            Sql("insert into dbo.Genres (Id, [Name]) values (2,'Comedy');");
            Sql("insert into dbo.Genres (Id, [Name]) values (3,'Family');");
            Sql("insert into dbo.Genres (Id, [Name]) values (4,'Romance');");

            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) values (1,0,0,0);");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) values (2,30,1,10);");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) values (3,90,3,15);");
            Sql("insert into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) values (4,300,12,20);");

            Sql("update MemberShipTypes set [Name] = 'Pay as You Go' where Id = 1;");
            Sql("update MemberShipTypes set [Name] = 'Monthly' where Id = 2;");
            Sql("update MemberShipTypes set [Name] = 'Quarterly' where Id = 3;");
            Sql("update MemberShipTypes set [Name] = 'Annual' where Id = 4;");

            Sql("insert into Customers (CustomerId, Name, IsSubscribedToNewsletter, MemberShipTypeId, Birthdate) values (1, 'John Smith', 1, 1, '19730304');");
            Sql("insert into Customers (CustomerId, Name, IsSubscribedToNewsletter, MemberShipTypeId, Birthdate) values (2, 'Mary Williams', 0, 2, null);");

            Sql("insert into Movies (Id, [Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values (1, 'Hangover', '20000101', 2, '20200329', 5)");
            Sql("insert into Movies (Id, [Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values (2, 'Die Hard', '20000102', 1, '20200329', 6)");
            Sql("insert into Movies (Id, [Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values (3, 'Terminator', '20000103', 1, '20200329', 8)");
            Sql("insert into Movies (Id, [Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values (4, 'Toy Story', '20000104', 3, '20200329', 12)");
            Sql("insert into Movies (Id, [Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values (5, 'Titanic', '20000105', 4, '20200329', 2)");

        }

        public override void Down()
        {
            Sql("delete from Customers;");
            Sql("delete from Movies;");
            Sql("delete from MembershipTypes;");
            Sql("delete from Genres;");
        }
    }
}
