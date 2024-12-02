﻿// <auto-generated />
using System;
using JobOffersApi.Modules.Companies.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobOffersApi.Modules.Companies.Infrastructure.DAL.Migartions
{
    [DbContext(typeof(CompaniesDbContext))]
    [Migration("20241202155858_CompaniesDbContext_InitSchema")]
    partial class CompaniesDbContext_InitSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("companies")
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies", "companies");
                });

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.CompanyEmployer", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("CompanyId", "EmployerId");

                    b.HasIndex("EmployerId");

                    b.ToTable("CompaniesEmployers", "companies");
                });

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Employers", "companies");
                });

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.CompanyEmployer", b =>
                {
                    b.HasOne("JobOffersApi.Modules.Companies.Core.Entities.Company", "Company")
                        .WithMany("CompaniesEmployers")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobOffersApi.Modules.Companies.Core.Entities.Employer", "Employer")
                        .WithMany("CompaniesEmployers")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employer");
                });

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.Company", b =>
                {
                    b.Navigation("CompaniesEmployers");
                });

            modelBuilder.Entity("JobOffersApi.Modules.Companies.Core.Entities.Employer", b =>
                {
                    b.Navigation("CompaniesEmployers");
                });
#pragma warning restore 612, 618
        }
    }
}
