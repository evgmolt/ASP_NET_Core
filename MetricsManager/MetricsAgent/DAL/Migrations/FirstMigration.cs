using Core;
using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Up()
        {
            for (int i = 0; i < Strings.TableNames.Count(); i++)
            {
                Create.Table(Strings.TableNames[i])
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Value").AsInt32()
                .WithColumn("Time").AsInt64();
            }
        }

        public override void Down()
        {
            for (int i = 0; i < Strings.TableNames.Count(); i++)
            {
                Delete.Table(Strings.TableNames[i]);
            }
            Delete.Table("cpumetrics");
        }
    }
}
