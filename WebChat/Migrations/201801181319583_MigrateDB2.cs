namespace WebChat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.TablePoster",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Advert = c.String(nullable: false, maxLength: 250),
                        Email = c.String(maxLength: 250),
                        PhoneNumber = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.TablePoster");
        }
    }
}
