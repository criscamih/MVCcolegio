namespace MVCPrueba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevacolumnadocentes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Docentes", "DNI", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Docentes", "DNI");
        }
    }
}
