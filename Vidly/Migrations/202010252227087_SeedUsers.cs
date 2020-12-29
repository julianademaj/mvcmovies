namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'4590a2d1-83e6-4d1f-8f0a-6c5cc3adcfe5', N'admin@vidly.com', 0, N'ABg09n0eAPMOQTB/1N8nOZWXPo4ySHIUyk3HCy1kzUrXn3s5yStTqJqm72b5r8zr6Q==', N'a2eafabe-56f8-44e7-8dfe-625c6ab0d6d9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'123123', N'010101')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'055dd0ff-abea-46fe-b8ed-504a4bfa3d9c', N'CanManageCustomer')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2300dd4c-bb77-4e6a-93b4-245531ba058b', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ec4b2ccf-991b-47d0-8c02-5bf67e977d3c', N'055dd0ff-abea-46fe-b8ed-504a4bfa3d9c')


");
        }
        
        public override void Down()
        {
        }
    }
}
