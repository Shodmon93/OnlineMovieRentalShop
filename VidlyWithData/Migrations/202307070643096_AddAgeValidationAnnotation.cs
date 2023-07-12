namespace VidlyWithData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgeValidationAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
