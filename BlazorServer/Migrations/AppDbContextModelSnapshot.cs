﻿// <auto-generated />
using System;
using BlazorServer.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AppUser", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.CaseInvolvement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CaseRecordId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestRecordId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HostRecordId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CaseRecordId");

                    b.HasIndex("GuestRecordId");

                    b.HasIndex("HostRecordId");

                    b.ToTable("CaseInvolvement", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.CaseRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CaseReference")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CaseRecord", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Male"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Female"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Other/not specified"
                        });
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestChild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EsolEnrolmentAtIwCollege")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GenderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeToSchoolTransport")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfSchool")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SchoolPlace")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SchoolYearStartedSchool")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("GuestChild", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestGuestChild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestChildId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GuestRecordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuestChildId");

                    b.HasIndex("GuestRecordId");

                    b.ToTable("GuestGuestChild", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BiometricResidencePermitAppliedFor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BiometricResidencePermitReceived")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BusAppDownloadedToPhone")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("CashAllowance")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfArrivalAtAddress")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfArrivalUk")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FamilyNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GenderId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("GpApplicationSubmitted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameOfSurgery")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NiApplicationMade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NumberOfAdultsArrived")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumberOfChildrenArrived")
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

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.HomeVisitRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CaseRecordId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
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

                    b.HasIndex("CaseRecordId");

                    b.HasIndex("VisitStatusId");

                    b.ToTable("HomeVisitRecord", (string)null);
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.HostRecord", b =>
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
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataFromExport")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HostAge")
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

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.VisitStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VisitStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Scheduled"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Complete"
                        });
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.CaseInvolvement", b =>
                {
                    b.HasOne("BlazorServer.Data.Models.Domain.AppUser", "AppUser")
                        .WithMany("CaseInvolvements")
                        .HasForeignKey("AppUserId");

                    b.HasOne("BlazorServer.Data.Models.Domain.CaseRecord", "CaseRecord")
                        .WithMany("CaseInvolvements")
                        .HasForeignKey("CaseRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorServer.Data.Models.Domain.GuestRecord", "GuestRecord")
                        .WithMany("CaseInvolvements")
                        .HasForeignKey("GuestRecordId");

                    b.HasOne("BlazorServer.Data.Models.Domain.HostRecord", "HostRecord")
                        .WithMany("CaseInvolvements")
                        .HasForeignKey("HostRecordId");

                    b.Navigation("AppUser");

                    b.Navigation("CaseRecord");

                    b.Navigation("GuestRecord");

                    b.Navigation("HostRecord");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestChild", b =>
                {
                    b.HasOne("BlazorServer.Data.Models.Domain.Gender", "Gender")
                        .WithMany("GuestChildren")
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestGuestChild", b =>
                {
                    b.HasOne("BlazorServer.Data.Models.Domain.GuestChild", "GuestChild")
                        .WithMany("GuestGuestChildren")
                        .HasForeignKey("GuestChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorServer.Data.Models.Domain.GuestRecord", "GuestRecord")
                        .WithMany("GuestGuestChildren")
                        .HasForeignKey("GuestRecordId");

                    b.Navigation("GuestChild");

                    b.Navigation("GuestRecord");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestRecord", b =>
                {
                    b.HasOne("BlazorServer.Data.Models.Domain.Gender", "Gender")
                        .WithMany("GuestRecords")
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.HomeVisitRecord", b =>
                {
                    b.HasOne("BlazorServer.Data.Models.Domain.CaseRecord", "CaseRecord")
                        .WithMany("HomeVisitRecords")
                        .HasForeignKey("CaseRecordId");

                    b.HasOne("BlazorServer.Data.Models.Domain.VisitStatus", "VisitStatus")
                        .WithMany("HomeVisitRecords")
                        .HasForeignKey("VisitStatusId");

                    b.Navigation("CaseRecord");

                    b.Navigation("VisitStatus");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.AppUser", b =>
                {
                    b.Navigation("CaseInvolvements");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.CaseRecord", b =>
                {
                    b.Navigation("CaseInvolvements");

                    b.Navigation("HomeVisitRecords");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.Gender", b =>
                {
                    b.Navigation("GuestChildren");

                    b.Navigation("GuestRecords");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestChild", b =>
                {
                    b.Navigation("GuestGuestChildren");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.GuestRecord", b =>
                {
                    b.Navigation("CaseInvolvements");

                    b.Navigation("GuestGuestChildren");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.HostRecord", b =>
                {
                    b.Navigation("CaseInvolvements");
                });

            modelBuilder.Entity("BlazorServer.Data.Models.Domain.VisitStatus", b =>
                {
                    b.Navigation("HomeVisitRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
