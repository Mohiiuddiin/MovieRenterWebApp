namespace MovieRenterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name,GenreId,DateAdded,ReleaseDate,NumberInStock) Values('Movie1',5,'3/30/2021','1/1/2016',1)");
            Sql("INSERT INTO Movies(Name,GenreId,DateAdded,ReleaseDate,NumberInStock) Values('Movie2',6,'3/30/2021','1/1/2017',5)");
            Sql("INSERT INTO Movies(Name,GenreId,DateAdded,ReleaseDate,NumberInStock) Values('Movie3',7,'3/30/2021','1/1/2017',0)");
        }
        
        public override void Down()
        {
        }
    }
}
