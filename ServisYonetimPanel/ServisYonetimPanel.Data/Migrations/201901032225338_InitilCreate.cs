namespace ServisYonetimPanel.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitilCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceDetailEntity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MasterId = c.Long(nullable: false),
                        DetailKey = c.String(),
                        DetailValue = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Long(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ServiceEntity", t => t.MasterId)
                .Index(t => t.MasterId);
            
            CreateTable(
                "dbo.ServiceEntity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MasterKey = c.String(),
                        Name = c.String(),
                        CreatedBy = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedBy = c.Long(),
                        UpdatedOn = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceDetailEntity", "MasterId", "dbo.ServiceEntity");
            DropIndex("dbo.ServiceDetailEntity", new[] { "MasterId" });
            DropTable("dbo.ServiceEntity");
            DropTable("dbo.ServiceDetailEntity");
        }
    }
}
