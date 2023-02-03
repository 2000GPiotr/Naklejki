﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(LabelDbContext))]
    partial class LabelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Database.Entities.DocumentHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DocumentTypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("DocumentHeaders");
                });

            modelBuilder.Entity("Database.Entities.DocumentType", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Symbol");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("Database.Entities.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DocumentHeaderId")
                        .HasColumnType("integer");

                    b.Property<string>("LabelNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LabelTypeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Lp")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DocumentHeaderId");

                    b.HasIndex("LabelTypeId", "LabelNumber");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Database.Entities.LabelStatus", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Symbol");

                    b.ToTable("LabelStatus");
                });

            modelBuilder.Entity("Database.Entities.LabelType", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Symbol");

                    b.ToTable("LabelTypes");
                });

            modelBuilder.Entity("Database.Entities.Password", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Round")
                        .HasColumnType("integer");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passwords");
                });

            modelBuilder.Entity("Database.Entities.Registry", b =>
                {
                    b.Property<string>("LabelTypeId")
                        .HasColumnType("text");

                    b.Property<string>("LabelNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("LabelEndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LabelStatusId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LabelTypeId", "LabelNumber");

                    b.HasIndex("LabelStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Registry");
                });

            modelBuilder.Entity("Database.Entities.Roles", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Key"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Key");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PasswordId")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PasswordId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RolesUser", b =>
                {
                    b.Property<int>("RolesKey")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("RolesKey", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RolesUser");
                });

            modelBuilder.Entity("Database.Entities.DocumentHeader", b =>
                {
                    b.HasOne("Database.Entities.DocumentType", "DocumentType")
                        .WithMany("DocumentHeaders")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.User", "User")
                        .WithMany("DocumentHeaders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Entities.Items", b =>
                {
                    b.HasOne("Database.Entities.DocumentHeader", "DocumentHeader")
                        .WithMany("Items")
                        .HasForeignKey("DocumentHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.LabelType", "LabelType")
                        .WithMany("Items")
                        .HasForeignKey("LabelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.Registry", "Registry")
                        .WithMany("Items")
                        .HasForeignKey("LabelTypeId", "LabelNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentHeader");

                    b.Navigation("LabelType");

                    b.Navigation("Registry");
                });

            modelBuilder.Entity("Database.Entities.Registry", b =>
                {
                    b.HasOne("Database.Entities.LabelStatus", "LabelStatus")
                        .WithMany("Registries")
                        .HasForeignKey("LabelStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.LabelType", "LabelType")
                        .WithMany("Registries")
                        .HasForeignKey("LabelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.User", "User")
                        .WithMany("Registries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LabelStatus");

                    b.Navigation("LabelType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Database.Entities.User", b =>
                {
                    b.HasOne("Database.Entities.Password", "Password")
                        .WithOne("User")
                        .HasForeignKey("Database.Entities.User", "PasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Password");
                });

            modelBuilder.Entity("RolesUser", b =>
                {
                    b.HasOne("Database.Entities.Roles", null)
                        .WithMany()
                        .HasForeignKey("RolesKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Entities.DocumentHeader", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Database.Entities.DocumentType", b =>
                {
                    b.Navigation("DocumentHeaders");
                });

            modelBuilder.Entity("Database.Entities.LabelStatus", b =>
                {
                    b.Navigation("Registries");
                });

            modelBuilder.Entity("Database.Entities.LabelType", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Registries");
                });

            modelBuilder.Entity("Database.Entities.Password", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Entities.Registry", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Database.Entities.User", b =>
                {
                    b.Navigation("DocumentHeaders");

                    b.Navigation("Registries");
                });
#pragma warning restore 612, 618
        }
    }
}
