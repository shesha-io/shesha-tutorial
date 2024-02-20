using FluentMigrator;
using Shesha.FluentMigrator;
using System;

namespace Shesha.Tutorial.Domain.Migrations
{
    // <summary>
    /// Adding the Members table
    /// </summary>

    [Migration(20240206200000)]
    public class M20240206200000 : Migration
    {
        /// <summary>
        /// Code to execute when executing the migrations
        /// </summary>
        public override void Up()
        {
            Create.Table("Tutorial_MembershipPayments")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithForeignKeyColumn("MemberId", "Core_Persons").Nullable()
                .WithColumn("Amount").AsDouble().Nullable()
                .WithColumn("PaymentDate").AsDateTime().Nullable();
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
