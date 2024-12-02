﻿// <auto-generated />
using FraudPortal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FraudPortal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221205081858_workgroup-user-foregin")]
    partial class workgroupuserforegin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FraudPortal.Data.UserInGroup", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WorkGroupId")
                        .HasColumnType("int");

                    b.Property<string>("WorkGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.HasIndex("WorkGroupId");

                    b.ToTable("UserInGroups");
                });

            modelBuilder.Entity("FraudPortal.Data.WorkGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkGroups");
                });

            modelBuilder.Entity("FraudPortal.Data.UserInGroup", b =>
                {
                    b.HasOne("FraudPortal.Data.WorkGroup", "WorkGroup")
                        .WithMany("userInGroups")
                        .HasForeignKey("WorkGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkGroup");
                });

            modelBuilder.Entity("FraudPortal.Data.WorkGroup", b =>
                {
                    b.Navigation("userInGroups");
                });
#pragma warning restore 612, 618
        }
    }
}