namespace SeaCargo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        a_date = c.DateTime(),
                        a_title = c.String(),
                        a_source = c.String(),
                        a_desc = c.String(),
                        a_link = c.String(),
                        a_img = c.String(),
                        a_type = c.String(),
                        a_mediatype = c.String(),
                        a_meidatype_link = c.String(),
                        a_order = c.Int(),
                        a_loc = c.String(),
                        a_status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_contact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        GDate = c.DateTime(),
                        GName = c.String(nullable: false),
                        GAddress = c.String(),
                        GEmail = c.String(nullable: false),
                        GSubject = c.String(),
                        GData = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_image",
                c => new
                    {
                        imgid = c.Int(nullable: false, identity: true),
                        imgfolder = c.String(),
                        imgurl_lg = c.String(),
                        imgurl_sm = c.String(),
                        imgurl_th = c.String(),
                        imgfullurl = c.String(),
                        imgtitle = c.String(),
                        imgdesc = c.String(),
                        imgpid = c.Int(),
                        imglink = c.String(),
                        imgrole = c.String(),
                        imgyear = c.String(),
                        imgdate = c.DateTime(),
                        imgshow = c.Int(),
                        imgw = c.String(),
                        imgh = c.String(),
                    })
                .PrimaryKey(t => t.imgid);
            
            CreateTable(
                "dbo.tbl_navmenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        MenuName = c.String(),
                        URL = c.String(),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        post_auid = c.Int(),
                        post_title = c.String(nullable: false),
                        post_date = c.DateTime(),
                        year = c.String(),
                        month = c.String(),
                        post_content = c.String(),
                        post_excerpt = c.String(),
                        post_catid = c.String(),
                        post_modified = c.DateTime(),
                        post_status = c.Int(),
                        post_parent = c.Int(),
                        post_menu_order = c.Int(),
                        post_img = c.String(),
                        post_img_title = c.String(),
                        post_img_desc = c.String(),
                        post_price = c.String(),
                        post_attachment = c.String(),
                        post_lang = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_section",
                c => new
                    {
                        secId = c.Int(nullable: false, identity: true),
                        sec_title = c.String(),
                        sec_loc = c.String(),
                        sec_desc = c.String(),
                        sec_status = c.Int(),
                    })
                .PrimaryKey(t => t.secId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_section");
            DropTable("dbo.tbl_post");
            DropTable("dbo.tbl_navmenu");
            DropTable("dbo.tbl_image");
            DropTable("dbo.tbl_contact");
            DropTable("dbo.tbl_article");
        }
    }
}
