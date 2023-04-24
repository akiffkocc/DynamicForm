namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class form_formfield_foreign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormFields", "FormId", c => c.Int(nullable: false));
            CreateIndex("dbo.FormFields", "FormId");
            AddForeignKey("dbo.FormFields", "FormId", "dbo.Forms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FormFields", "FormId", "dbo.Forms");
            DropIndex("dbo.FormFields", new[] { "FormId" });
            DropColumn("dbo.FormFields", "FormId");
        }
    }
}
