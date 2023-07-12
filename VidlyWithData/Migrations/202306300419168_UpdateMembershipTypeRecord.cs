namespace VidlyWithData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeRecord : DbMigration
    {

        /* Update Membership records*/
        public override void Up()
        {

            Sql("UPDATE MembershipTypes SET SignUpFee = 0, DurationInMonth = 0, DiscountRate = 0, Name ='Pay as you go' WHERE id = 1");
            Sql("UPDATE MembershipTypes SET SignUpFee = 30, DurationInMonth = 1, DiscountRate = 10, Name ='Monthly' WHERE id = 2");
            Sql("UPDATE MembershipTypes SET SignUpFee = 90, DurationInMonth = 3, DiscountRate = 15, Name ='Quarterly' WHERE id = 3");
            Sql("UPDATE MembershipTypes SET SignUpFee = 300, DurationInMonth = 12, DiscountRate = 20, Name ='Annual' WHERE id = 4");

        }
        
        public override void Down()
        {

        }
    }
}
                                  