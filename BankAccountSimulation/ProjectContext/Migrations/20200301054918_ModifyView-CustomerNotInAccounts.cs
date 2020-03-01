using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectContext.Migrations
{
    public partial class ModifyViewCustomerNotInAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW CustomerNotInAccounts
                                    AS
                                    SELECT * FROM Customers
                                    WHERE Id NOT IN (SELECT a.CustomerId FROM Accounts as a)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS dbo.CustomerNotInAccounts");
        }
    }
}
