﻿// <auto-generated />
using System;
using API_CITSWebAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_CITSWebAPI.DAL.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20220302175231_thirdattend")]
    partial class thirdattend
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_CITSWebAPI.Entities.AttendanceManagement", b =>
                {
                    b.Property<double>("AttendanceManagementId")
                        .HasColumnName("AttendanceManagementId")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeManagementEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("HalfDayLeaves")
                        .HasColumnName("Half-Day-Leaves")
                        .HasColumnType("int");

                    b.Property<DateTime>("Intime")
                        .HasColumnName("In-time")
                        .HasColumnType("datetime2");

                    b.Property<int>("LateHours")
                        .HasColumnName("Late-Hours")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnName("Notes")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Outtime")
                        .HasColumnName("Out-time")
                        .HasColumnType("datetime2");

                    b.HasKey("AttendanceManagementId");

                    b.HasIndex("EmployeeManagementEmployeeId");

                    b.ToTable("Attendance_Management");
                });

            modelBuilder.Entity("API_CITSWebAPI.Entities.CompanyDetails", b =>
                {
                    b.Property<string>("CompanyName")
                        .HasColumnName("Cname")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("CAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CLogo")
                        .IsRequired()
                        .HasColumnName("CLogo")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("ContactNumber")
                        .HasColumnName("ContactNumber")
                        .HasColumnType("float");

                    b.HasKey("CompanyName");

                    b.ToTable("CompanyDetails");
                });

            modelBuilder.Entity("API_CITSWebAPI.Entities.EmployeeManagement", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmpId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnName("EmpAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("BasicSalary")
                        .HasColumnName("BasicSalary")
                        .HasColumnType("float");

                    b.Property<string>("CompanyDetailsCompanyName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnName("ContactAddress")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnName("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofJoining")
                        .HasColumnName("DOJ")
                        .HasColumnType("datetime2");

                    b.Property<double>("MobileNumber")
                        .HasColumnName("MobileNumber")
                        .HasColumnType("float");

                    b.Property<string>("OfferLetter")
                        .IsRequired()
                        .HasColumnName("OfferLetter")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnName("Profession")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnName("Resume")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("EmployeeId");

                    b.HasIndex("CompanyDetailsCompanyName");

                    b.ToTable("Emp_Management");
                });

            modelBuilder.Entity("API_CITSWebAPI.Entities.AttendanceManagement", b =>
                {
                    b.HasOne("API_CITSWebAPI.Entities.EmployeeManagement", "EmployeeManagement")
                        .WithMany("AttendanceManagement")
                        .HasForeignKey("EmployeeManagementEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_CITSWebAPI.Entities.EmployeeManagement", b =>
                {
                    b.HasOne("API_CITSWebAPI.Entities.CompanyDetails", "CompanyDetails")
                        .WithMany("EmployeeManagements")
                        .HasForeignKey("CompanyDetailsCompanyName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
