﻿// <auto-generated />
using System;
using GenericCalendar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GenericCalendar.Infrastructure.Migrations
{
    [DbContext(typeof(GenericCalendarDbContext))]
    [Migration("20250416230703_ReviewChanges")]
    partial class ReviewChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "10.0.0-preview.3.25171.6");

            modelBuilder.Entity("GenericCalendar.Domain.Entities.BookableItemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BookableItems");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.BookingEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookableItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookedBy")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BookableItemId", "Start", "End");

                    b.ToTable("Bookings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000101"),
                            BookableItemId = new Guid("ed52fdcf-87fa-4f6d-ae09-b15419fecd72"),
                            BookedBy = "alice@example.com",
                            End = new DateTime(2025, 4, 7, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Start = new DateTime(2025, 4, 7, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Project Kickoff",
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000102"),
                            BookableItemId = new Guid("3a91263e-61a2-4b78-927f-01a8f331ec11"),
                            BookedBy = "carol@example.com",
                            End = new DateTime(2025, 4, 8, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            Start = new DateTime(2025, 4, 8, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Seat A1 Reserved",
                            Type = 2
                        });
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.RoomEntity", b =>
                {
                    b.HasBaseType("GenericCalendar.Domain.Entities.BookableItemEntity");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.HasIndex("Floor");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Rooms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed52fdcf-87fa-4f6d-ae09-b15419fecd72"),
                            Description = "Large presentation room",
                            Name = "Main Hall",
                            Capacity = 100,
                            Floor = 1
                        },
                        new
                        {
                            Id = new Guid("c4f7a089-5bc6-43d0-b95d-739c2489ac4d"),
                            Description = "Medium room",
                            Name = "Meeting Room A",
                            Capacity = 12,
                            Floor = 2
                        });
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.SeatEntity", b =>
                {
                    b.HasBaseType("GenericCalendar.Domain.Entities.BookableItemEntity");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Row")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasIndex("Row", "Number")
                        .IsUnique();

                    b.ToTable("Seats", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a91263e-61a2-4b78-927f-01a8f331ec11"),
                            Description = "Front row left",
                            Name = "Seat A1",
                            Number = 1,
                            Row = "A"
                        });
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.TeamMeetingEntity", b =>
                {
                    b.HasBaseType("GenericCalendar.Domain.Entities.BookableItemEntity");

                    b.Property<string>("Organizer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Participants")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("Organizer");

                    b.ToTable("TeamMeetings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6e282e43-8825-42e6-a3a1-1f1eb9f7a0c3"),
                            Description = "Weekly check-in",
                            Name = "Weekly Sync",
                            Organizer = "lead@example.com",
                            Participants = "alice@example.com;bob@example.com"
                        });
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.BookingEntity", b =>
                {
                    b.HasOne("GenericCalendar.Domain.Entities.BookableItemEntity", "Item")
                        .WithMany()
                        .HasForeignKey("BookableItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.RoomEntity", b =>
                {
                    b.HasOne("GenericCalendar.Domain.Entities.BookableItemEntity", null)
                        .WithOne()
                        .HasForeignKey("GenericCalendar.Domain.Entities.RoomEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.SeatEntity", b =>
                {
                    b.HasOne("GenericCalendar.Domain.Entities.BookableItemEntity", null)
                        .WithOne()
                        .HasForeignKey("GenericCalendar.Domain.Entities.SeatEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenericCalendar.Domain.Entities.TeamMeetingEntity", b =>
                {
                    b.HasOne("GenericCalendar.Domain.Entities.BookableItemEntity", null)
                        .WithOne()
                        .HasForeignKey("GenericCalendar.Domain.Entities.TeamMeetingEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
