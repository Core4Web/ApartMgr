using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ApartMgr.Data;

namespace ApartMgr.Migrations
{
    [DbContext(typeof(ApartMgrContext))]
    [Migration("20170325210455_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApartMgr.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account");

                    b.Property<string>("Number");

                    b.Property<int>("PeriodId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("PeriodId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ApartMgr.Models.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PeriodName");

                    b.HasKey("Id");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("ApartMgr.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProviderName");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("ApartMgr.Models.Invoice", b =>
                {
                    b.HasOne("ApartMgr.Models.Period", "Period")
                        .WithMany()
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
