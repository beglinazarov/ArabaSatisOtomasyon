namespace ArabaSatisOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senkron : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VitesTurleris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VitesTurleris");
        }
    }
}
