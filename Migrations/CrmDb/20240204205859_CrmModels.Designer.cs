﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wsb_app.Data;

#nullable disable

namespace wsb_app.Migrations.CrmDb
{
    [DbContext(typeof(CrmDbContext))]
    [Migration("20240204205859_CrmModels")]
    partial class CrmModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LeadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ActivityId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("LeadId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Lead", b =>
                {
                    b.Property<int>("LeadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LeadId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Opportunity", b =>
                {
                    b.Property<int>("OpportunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExpectedCloseDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PotentialRevenue")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OpportunityId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Activity", b =>
                {
                    b.HasOne("wsb_app.Persistance.Models.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("wsb_app.Persistance.Models.Customers.Lead", "Lead")
                        .WithMany()
                        .HasForeignKey("LeadId");

                    b.Navigation("Customer");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Contact", b =>
                {
                    b.HasOne("wsb_app.Persistance.Models.Customers.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Opportunity", b =>
                {
                    b.HasOne("wsb_app.Persistance.Models.Customers.Customer", "Customer")
                        .WithMany("Opportunities")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("wsb_app.Persistance.Models.Customers.Customer", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Opportunities");
                });
#pragma warning restore 612, 618
        }
    }
}