namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Movies ON");

            Sql("INSERT INTO Movies (Id, Name , ReleaseDate, Genres_Id) VALUES (1, 'Taken' , '1/1/2020', 1)");

            Sql("SET IDENTITY_INSERT Movies OFF");

        }

        public override void Down()
        {
        }
    }
}
