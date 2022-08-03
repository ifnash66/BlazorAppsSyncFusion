﻿// <auto-generated />
using System;
using BlazorApps.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApps.Shared.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220801150008_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("BlazorApps.Shared.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Female"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Other/not specified"
                        });
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.GuestRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BiometricResidencePermitAppliedFor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BiometricResidencePermitReceived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BusAppDownloadedToPhone")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CashAllowance")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfArrivalAtAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfArrivalUk")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsolEnrolmentAtIwCollege")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenderId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GpApplicationSubmitted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeToSchoolTransport")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfSchool")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfSurgery")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NiApplicationMade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfAdultsArrived")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfChildrenArrived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PensionCredit")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PermissionForCaiwToHold")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PermissionToShareContactInformationWithFaithOrganisation")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PermissionToShareDataWithOtherUkrainianArrivals")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PermissionToShareEmailAddressWithSv")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SchoolPlace")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolYearStartedSchool")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UcApplicationMade")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UcRegistration")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VodafoneSimGiven")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("GuestRecord", (string)null);
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.HomeVisitRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("GuestsVisited")
                        .HasColumnType("TEXT");

                    b.Property<string>("HostsVisited")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsTranslatorNeeded")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TranslationLanguage")
                        .HasColumnType("TEXT");

                    b.Property<string>("TranslatorName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("VisitDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("VisitNotes")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VisitStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VisitorName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VisitStatusId");

                    b.ToTable("HomeVisitRecord", (string)null);
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.HostRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BankDetailsConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuildingNameNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("County")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFromExport")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int>("HostAge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InitialHomeVisit")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ProformaInvoiceGivenToHost")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ProformaSignedByCaiw")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("Town")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HostRecord", (string)null);
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.VisitStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VisitStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Scheduled"
                        },
                        new
                        {
                            Id = 2,
                            Title = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Complete"
                        });
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.GuestRecord", b =>
                {
                    b.HasOne("BlazorApps.Shared.Models.Gender", "Gender")
                        .WithMany("GuestRecords")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.HomeVisitRecord", b =>
                {
                    b.HasOne("BlazorApps.Shared.Models.VisitStatus", "VisitStatus")
                        .WithMany("HomeVisitRecords")
                        .HasForeignKey("VisitStatusId");

                    b.Navigation("VisitStatus");
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.Gender", b =>
                {
                    b.Navigation("GuestRecords");
                });

            modelBuilder.Entity("BlazorApps.Shared.Models.VisitStatus", b =>
                {
                    b.Navigation("HomeVisitRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
