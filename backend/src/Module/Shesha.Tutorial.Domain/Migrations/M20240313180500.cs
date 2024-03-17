using FluentMigrator;
using Shesha.FluentMigrator;
using System;

namespace Shesha.Tutorial.Domain.Migrations
{
    // <summary>
    /// 
    /// </summary>

    [Migration(20240313180500)]
    public class M20240313180500 : Migration
    {
        /// <summary>
        /// Code to execute when executing the migrations
        /// </summary>
        public override void Up()
        {
            Create.Table("Tutorial_Templates")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("CaptureFormId", "Frwk_FormConfigurations").Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Name").AsString().Nullable();

            Create.Table("Tutorial_Enquiries")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("MemberId", "Core_Persons").Nullable()
                .WithForeignKeyColumn("TemplateId", "Tutorial_Templates").Nullable();
        }
        /// <summary>
        /// Code to execute when rolling back the migration
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
