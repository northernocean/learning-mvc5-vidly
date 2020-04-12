namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestData : DbMigration
    {
        public override void Up()
        {
            Sql("delete from dbo.Customers;");
            Sql("delete from dbo.Movies;");

            Sql("insert into dbo.Customers (Name, IsSubscribedToNewsletter, MemberShipTypeId, Birthdate) values ('John Smith', 1, 1, '19730304');");
            Sql("insert into dbo.Customers (Name, IsSubscribedToNewsletter, MemberShipTypeId, Birthdate) values ('Mary Williams', 0, 2, null);");

            Sql("insert into dbo.Movies ([Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values ('Hangover', '20000101', 2, '20200329', 5)");
            Sql("insert into dbo.Movies ([Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values ('Die Hard', '20000102', 1, '20200329', 6)");
            Sql("insert into dbo.Movies ([Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values ('Terminator', '20000103', 1, '20200329', 8)");
            Sql("insert into dbo.Movies ([Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values ('Toy Story', '20000104', 3, '20200329', 12)");
            Sql("insert into dbo.Movies ([Name], ReleaseDate, GenreID, DateAdded, NumberInStock) values ('Titanic', '20000105', 4, '20200329', 2)");

        }

        public override void Down()
        {
            Sql("delete from dbo.Customers;");
            Sql("delete from dbo.Movies;");
        }

    }
}
