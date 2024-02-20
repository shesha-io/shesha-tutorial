using FluentMigrator;
using Shesha.FluentMigrator;
using System;

namespace Shesha.Tutorial.Domain.Migrations
{
    // <summary>
    /// Adding the Members table
    /// </summary>

    [Migration(20240206192800)]
    public class M20240206192800 : Migration
    {
        /// <summary>
        /// Code to execute when executing the migrations
        /// </summary>
        public override void Up()
        {
            Alter.Table("Core_Persons")
                .AddColumn("Tutorial_MembershipNumber").AsString().Nullable()
                .AddForeignKeyColumn("Tutorial_IdDocumentId", "Frwk_StoredFiles").Nullable()
                .AddColumn("Tutorial_MembershipStartDate").AsDateTime().Nullable()
                .AddColumn("Tutorial_MembershipEndDate").AsDateTime().Nullable()
                .AddColumn("Tutorial_MembershipStatusLkp").AsInt64().Nullable();
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
