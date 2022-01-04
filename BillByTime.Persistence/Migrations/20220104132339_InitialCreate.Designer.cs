﻿// <auto-generated />
using System;
using BillByTime.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BillByTime.Persistence.Migrations
{
    [DbContext(typeof(BillByTimeContext))]
    [Migration("20220104132339_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BillByTime.Domain.ClientOrg", b =>
                {
                    b.Property<int>("ClientOrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientOrgId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TenantManager2ClientOrgId")
                        .HasColumnType("int");

                    b.HasKey("ClientOrgId");

                    b.HasIndex("TenantManager2ClientOrgId");

                    b.ToTable("ClientOrg");
                });

            modelBuilder.Entity("BillByTime.Domain.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"), 1L, 1);

                    b.Property<int>("ClientOrgId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientOrgId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("BillByTime.Domain.PurchaseOrder", b =>
                {
                    b.Property<int>("PurchaseOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseOrderId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientOrgId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("datetime2");

                    b.HasKey("PurchaseOrderId");

                    b.HasIndex("ClientOrgId");

                    b.ToTable("PurchaseOrder");
                });

            modelBuilder.Entity("BillByTime.Domain.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TenantId");

                    b.ToTable("Tenant");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager", b =>
                {
                    b.Property<int>("TenantManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantManagerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("TenantManagerId");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantManager");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager2ClientOrg", b =>
                {
                    b.Property<int>("TenantManager2ClientOrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenantManager2ClientOrgId"), 1L, 1);

                    b.Property<int>("TenantManagerId")
                        .HasColumnType("int");

                    b.HasKey("TenantManager2ClientOrgId");

                    b.HasIndex("TenantManagerId");

                    b.ToTable("TenantManager2ClientOrg");
                });

            modelBuilder.Entity("BillByTime.Domain.Timesheet", b =>
                {
                    b.Property<int>("TimesheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimesheetId"), 1L, 1);

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<decimal>("Friday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Monday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Saturday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sunday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Thursday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tuesday")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Wednesday")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TimesheetId");

                    b.HasIndex("ContractId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("Timesheet");
                });

            modelBuilder.Entity("BillByTime.Domain.TimesheetHistory", b =>
                {
                    b.Property<int>("TimesheetHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimesheetHistoryId"), 1L, 1);

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TenantManagerId")
                        .HasColumnType("int");

                    b.Property<int>("TimesheetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("TimesheetHistoryId");

                    b.HasIndex("TenantManagerId");

                    b.HasIndex("TimesheetId");

                    b.HasIndex("WorkerId");

                    b.ToTable("TimesheetHistory");
                });

            modelBuilder.Entity("BillByTime.Domain.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("WorkerId");

                    b.HasIndex("TenantId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("BillByTime.Domain.ClientOrg", b =>
                {
                    b.HasOne("BillByTime.Domain.TenantManager2ClientOrg", "TenantManager2ClientOrg")
                        .WithMany("ClientOrgs")
                        .HasForeignKey("TenantManager2ClientOrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantManager2ClientOrg");
                });

            modelBuilder.Entity("BillByTime.Domain.Contract", b =>
                {
                    b.HasOne("BillByTime.Domain.ClientOrg", "ClientOrg")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientOrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillByTime.Domain.Worker", "Worker")
                        .WithMany("Contracts")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ClientOrg");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("BillByTime.Domain.PurchaseOrder", b =>
                {
                    b.HasOne("BillByTime.Domain.ClientOrg", "ClientOrg")
                        .WithMany("PurchaseOrders")
                        .HasForeignKey("ClientOrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientOrg");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager", b =>
                {
                    b.HasOne("BillByTime.Domain.Tenant", "Tenant")
                        .WithMany("TenantManagers")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager2ClientOrg", b =>
                {
                    b.HasOne("BillByTime.Domain.TenantManager", "TenantManager")
                        .WithMany("TenantManager2ClientOrgs")
                        .HasForeignKey("TenantManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TenantManager");
                });

            modelBuilder.Entity("BillByTime.Domain.Timesheet", b =>
                {
                    b.HasOne("BillByTime.Domain.Contract", "Contract")
                        .WithMany("Timesheets")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillByTime.Domain.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Timesheets")
                        .HasForeignKey("PurchaseOrderId");

                    b.Navigation("Contract");

                    b.Navigation("PurchaseOrder");
                });

            modelBuilder.Entity("BillByTime.Domain.TimesheetHistory", b =>
                {
                    b.HasOne("BillByTime.Domain.TenantManager", "TenantManager")
                        .WithMany("TimesheetHistories")
                        .HasForeignKey("TenantManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BillByTime.Domain.Timesheet", "Timesheet")
                        .WithMany("TimesheetHistories")
                        .HasForeignKey("TimesheetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BillByTime.Domain.Worker", "Worker")
                        .WithMany("TimesheetHistories")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("TenantManager");

                    b.Navigation("Timesheet");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("BillByTime.Domain.Worker", b =>
                {
                    b.HasOne("BillByTime.Domain.Tenant", "Tenant")
                        .WithMany("Workers")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("BillByTime.Domain.ClientOrg", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("PurchaseOrders");
                });

            modelBuilder.Entity("BillByTime.Domain.Contract", b =>
                {
                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("BillByTime.Domain.PurchaseOrder", b =>
                {
                    b.Navigation("Timesheets");
                });

            modelBuilder.Entity("BillByTime.Domain.Tenant", b =>
                {
                    b.Navigation("TenantManagers");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager", b =>
                {
                    b.Navigation("TenantManager2ClientOrgs");

                    b.Navigation("TimesheetHistories");
                });

            modelBuilder.Entity("BillByTime.Domain.TenantManager2ClientOrg", b =>
                {
                    b.Navigation("ClientOrgs");
                });

            modelBuilder.Entity("BillByTime.Domain.Timesheet", b =>
                {
                    b.Navigation("TimesheetHistories");
                });

            modelBuilder.Entity("BillByTime.Domain.Worker", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("TimesheetHistories");
                });
#pragma warning restore 612, 618
        }
    }
}