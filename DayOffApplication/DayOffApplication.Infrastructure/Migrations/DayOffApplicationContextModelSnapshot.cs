﻿// <auto-generated />
using System;
using DayOffApplication.Infrastructure.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DayOffApplication.Infrastructure.Migrations
{
    [DbContext(typeof(DayOffApplicationContext))]
    partial class DayOffApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayOffApplication.Core.Entities.LeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedByEmail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("LeaveType")
                        .HasColumnType("tinyint");

                    b.Property<string>("ModificationByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TotalHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Years")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CumulativeLeaveRequest");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.LeaveRequests.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<Guid?>("AssignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByEmail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormNumber")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<byte>("LeaveType")
                        .HasColumnType("tinyint");

                    b.Property<string>("ModificationByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestNumber")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("WorkflowStatus")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.ToTable("LeaveRequest");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.Notifications.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedByEmail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CumulativeLeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeletedByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ModificationByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CumulativeLeaveRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.User.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedByEmail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModificationByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("UserType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ecad7d11-a405-4956-942b-eafcf2cb379a"),
                            Active = true,
                            CreatedByEmail = "system@gmail.com",
                            CreationTime = new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478),
                            Email = "minetopcuoglu6@gmail.com",
                            FirstName = "Mine",
                            LastName = "Topcuoglu",
                            ManagerId = new Guid("01aba89d-9996-442e-9bbf-f6353ca0392e"),
                            UserType = (byte)30
                        },
                        new
                        {
                            Id = new Guid("4c26c912-1364-4d48-b028-fff51c32da28"),
                            Active = true,
                            CreatedByEmail = "system@gmail.com",
                            CreationTime = new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478),
                            Email = "gönültopcuoglu@gmail.com",
                            FirstName = "Emre",
                            LastName = "Topcuoglu",
                            UserType = (byte)20
                        },
                        new
                        {
                            Id = new Guid("52985816-c3d5-4b21-bbbe-d6e5c7434c4c"),
                            Active = true,
                            CreatedByEmail = "system@gmail.com",
                            CreationTime = new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478),
                            Email = "osmantopcuoglu@gmail.com",
                            FirstName = "Elif",
                            LastName = "Topcuoglu",
                            UserType = (byte)10
                        });
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.User.Managers.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedByEmail")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ModificationByEmail")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Manager");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9f176152-1b24-4fd5-be02-389b5d5929c9"),
                            Active = true,
                            CreatedByEmail = "system@gmail.com",
                            CreationTime = new DateTime(2024, 3, 14, 14, 28, 58, 920, DateTimeKind.Unspecified).AddTicks(9478),
                            Description = "IT",
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.LeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.HasOne("DayOffApplication.Core.Entities.User.Employees.Employee", "Employee")
                        .WithMany("CumulativeLeaveRequest")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.LeaveRequests.LeaveRequest", b =>
                {
                    b.HasOne("DayOffApplication.Core.Entities.User.Employees.Employee", "Employee")
                        .WithMany("LeaveRequest")
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.Notifications.Notification", b =>
                {
                    b.HasOne("DayOffApplication.Core.Entities.LeaveRequests.CumulativeLeaveRequest", "CumulativeLeaveRequest")
                        .WithMany("Notification")
                        .HasForeignKey("CumulativeLeaveRequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DayOffApplication.Core.Entities.User.Employees.Employee", "Employee")
                        .WithMany("Notification")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CumulativeLeaveRequest");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.User.Employees.Employee", b =>
                {
                    b.HasOne("DayOffApplication.Core.Entities.User.Managers.Manager", "Manager")
                        .WithMany("Employee")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.LeaveRequests.CumulativeLeaveRequest", b =>
                {
                    b.Navigation("Notification");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.User.Employees.Employee", b =>
                {
                    b.Navigation("CumulativeLeaveRequest");

                    b.Navigation("LeaveRequest");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("DayOffApplication.Core.Entities.User.Managers.Manager", b =>
                {
                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
