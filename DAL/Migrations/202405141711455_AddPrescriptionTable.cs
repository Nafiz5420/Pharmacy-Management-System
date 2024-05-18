namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrescriptionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PrescriptionId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Status = c.String(),
                        UploadDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PrescriptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prescriptions");
        }
    }
}
