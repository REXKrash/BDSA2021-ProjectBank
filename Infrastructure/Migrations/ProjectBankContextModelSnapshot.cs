﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectBank.Infrastructure;

#nullable disable

namespace ProjectBank.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectBankContext))]
    partial class ProjectBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectBank.Infrastructure.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromUseroid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("FromUseroid");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.ChatUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ChatId")
                        .HasColumnType("int");

                    b.Property<bool>("SeenLatestMessage")
                        .HasColumnType("bit");

                    b.Property<string>("Useroid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("Useroid");

                    b.ToTable("ChatUsers");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Useroid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("Useroid");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Useroid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Useroid");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Useroid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Useroid");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.User", b =>
                {
                    b.Property<string>("oid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSupervisor")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("oid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Chat", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.ChatMessage", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.Chat", "Chat")
                        .WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectBank.Infrastructure.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUseroid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("FromUser");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.ChatUser", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.Chat", null)
                        .WithMany("ChatUsers")
                        .HasForeignKey("ChatId");

                    b.HasOne("ProjectBank.Infrastructure.User", "User")
                        .WithMany()
                        .HasForeignKey("Useroid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Comment", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("ProjectBank.Infrastructure.User", "User")
                        .WithMany()
                        .HasForeignKey("Useroid");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Notification", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.User", "User")
                        .WithMany()
                        .HasForeignKey("Useroid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Post", b =>
                {
                    b.HasOne("ProjectBank.Infrastructure.User", "User")
                        .WithMany()
                        .HasForeignKey("Useroid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Chat", b =>
                {
                    b.Navigation("ChatUsers");
                });

            modelBuilder.Entity("ProjectBank.Infrastructure.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
