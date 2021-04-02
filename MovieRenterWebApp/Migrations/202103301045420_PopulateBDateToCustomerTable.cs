namespace MovieRenterWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBDateToCustomerTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET BirthDate='09/30/1997' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
