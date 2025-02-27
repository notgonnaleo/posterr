﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Posting.Infrastructure.Contexts;

#nullable disable

namespace Posting.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250117212901_v1_Posting_Database_Creation_And_Mocks")]
    partial class v1_Posting_Database_Creation_And_Mocks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Posting.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PostId"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasMaxLength(777)
                        .HasColumnType("character varying(777)");

                    b.Property<int>("TotalReposts")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            DateCreated = new DateTime(2025, 1, 15, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5408),
                            PostContent = "Hey! I'm using Posterr, follow me for more pet care & vet posts.",
                            TotalReposts = 0,
                            UserId = 3
                        },
                        new
                        {
                            PostId = 2,
                            DateCreated = new DateTime(2025, 1, 12, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5421),
                            PostContent = "Looking for career tips? follow us and get to know more about our ways.",
                            TotalReposts = 0,
                            UserId = 4
                        },
                        new
                        {
                            PostId = 3,
                            DateCreated = new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5428),
                            PostContent = "Hello World!",
                            TotalReposts = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Posting.Domain.Entities.Repost", b =>
                {
                    b.Property<int>("RepostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RepostId"));

                    b.Property<int>("OriginalPostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RepostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RepostUserId")
                        .HasColumnType("integer");

                    b.HasKey("RepostId");

                    b.HasIndex("OriginalPostId");

                    b.HasIndex("RepostUserId", "OriginalPostId")
                        .IsUnique();

                    b.ToTable("Reposts");

                    b.HasData(
                        new
                        {
                            RepostId = 1,
                            OriginalPostId = 1,
                            RepostDate = new DateTime(2025, 1, 14, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5436),
                            RepostUserId = 2
                        },
                        new
                        {
                            RepostId = 2,
                            OriginalPostId = 2,
                            RepostDate = new DateTime(2025, 1, 16, 21, 29, 0, 916, DateTimeKind.Utc).AddTicks(5444),
                            RepostUserId = 1
                        });
                });

            modelBuilder.Entity("Posting.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Username = "leonardo_bruni"
                        },
                        new
                        {
                            UserId = 2,
                            Username = "sinuhe_huidobro"
                        },
                        new
                        {
                            UserId = 3,
                            Username = "petvisor"
                        },
                        new
                        {
                            UserId = 4,
                            Username = "strider_platform"
                        });
                });

            modelBuilder.Entity("Posting.Domain.Entities.Post", b =>
                {
                    b.HasOne("Posting.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Posting.Domain.Entities.Repost", b =>
                {
                    b.HasOne("Posting.Domain.Entities.Post", null)
                        .WithMany()
                        .HasForeignKey("OriginalPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Posting.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("RepostUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
