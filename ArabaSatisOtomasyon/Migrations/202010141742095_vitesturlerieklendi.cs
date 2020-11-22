namespace ArabaSatisOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vitesturlerieklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Araba", "VitesTuruId", c => c.Int(nullable: false));
            DropColumn("dbo.Araba", "Vites");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Araba", "Vites", c => c.String());
            DropColumn("dbo.Araba", "VitesTuruId");
        }
    }
}
