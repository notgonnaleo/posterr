﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Posting.Infrastructure.Contexts;

#nullable disable

namespace Posting.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            DateCreated = new DateTime(2025, 1, 16, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5150),
                            PostContent = "Hey! I'm using Posterr, follow me for more pet care & vet posts.",
                            TotalReposts = 0,
                            UserId = 3
                        },
                        new
                        {
                            PostId = 2,
                            DateCreated = new DateTime(2025, 1, 13, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5167),
                            PostContent = "Looking for career tips? follow us and get to know more about our ways.",
                            TotalReposts = 0,
                            UserId = 4
                        },
                        new
                        {
                            PostId = 3,
                            DateCreated = new DateTime(2025, 1, 17, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5174),
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

                    b.Property<int>("ParentPostId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentRepostId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RepostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RepostUserId")
                        .HasColumnType("integer");

                    b.HasKey("RepostId");

                    b.HasIndex("ParentPostId");

                    b.HasIndex("RepostUserId", "ParentPostId")
                        .IsUnique();

                    b.ToTable("Reposts");

                    b.HasData(
                        new
                        {
                            RepostId = 1,
                            ParentPostId = 1,
                            RepostDate = new DateTime(2025, 1, 15, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5184),
                            RepostUserId = 2
                        },
                        new
                        {
                            RepostId = 2,
                            ParentPostId = 2,
                            RepostDate = new DateTime(2025, 1, 17, 3, 9, 16, 880, DateTimeKind.Utc).AddTicks(5192),
                            RepostUserId = 1
                        },
                        new
                        {
                            RepostId = 3,
                            ParentPostId = 1,
                            ParentRepostId = 1,
                            RepostDate = new DateTime(2025, 1, 17, 4, 9, 16, 880, DateTimeKind.Utc).AddTicks(5199),
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
                        .HasForeignKey("ParentPostId")
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
