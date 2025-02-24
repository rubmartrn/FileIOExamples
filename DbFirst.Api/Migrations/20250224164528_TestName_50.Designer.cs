﻿// <auto-generated />
using System;
using DbFirst.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbFirst.Api.Migrations
{
    [DbContext(typeof(Aca12Context))]
    [Migration("20250224164528_TestName_50")]
    partial class TestName_50
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbFirst.Api.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DbFirst.Api.Models.CourseStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CourseId" }, "IX_CourseStudent_CourseId");

                    b.HasIndex(new[] { "StudentId" }, "IX_CourseStudent_StudentId");

                    b.ToTable("CourseStudent", (string)null);
                });

            modelBuilder.Entity("DbFirst.Api.Models.Cpu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LaptopId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "LaptopId" }, "IX_Cpus_LaptopId")
                        .IsUnique();

                    b.ToTable("Cpus");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Laptop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "StudentId" }, "IX_Laptops_StudentId")
                        .IsUnique();

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_Students_Email")
                        .IsUnique();

                    b.HasIndex(new[] { "LibraryId" }, "IX_Students_LibraryId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Test", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Test", (string)null);
                });

            modelBuilder.Entity("DbFirst.Api.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("StudentUniversity", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("UniversitiesId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "UniversitiesId");

                    b.HasIndex(new[] { "UniversitiesId" }, "IX_StudentUniversity_UniversitiesId");

                    b.ToTable("StudentUniversity", (string)null);
                });

            modelBuilder.Entity("DbFirst.Api.Models.CourseStudent", b =>
                {
                    b.HasOne("DbFirst.Api.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbFirst.Api.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Cpu", b =>
                {
                    b.HasOne("DbFirst.Api.Models.Laptop", "Laptop")
                        .WithOne("Cpu")
                        .HasForeignKey("DbFirst.Api.Models.Cpu", "LaptopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Laptop");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Laptop", b =>
                {
                    b.HasOne("DbFirst.Api.Models.Student", "Student")
                        .WithOne("Laptop")
                        .HasForeignKey("DbFirst.Api.Models.Laptop", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Student", b =>
                {
                    b.HasOne("DbFirst.Api.Models.Library", "Library")
                        .WithMany("Students")
                        .HasForeignKey("LibraryId");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("StudentUniversity", b =>
                {
                    b.HasOne("DbFirst.Api.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbFirst.Api.Models.University", null)
                        .WithMany()
                        .HasForeignKey("UniversitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbFirst.Api.Models.Course", b =>
                {
                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Laptop", b =>
                {
                    b.Navigation("Cpu");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Library", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DbFirst.Api.Models.Student", b =>
                {
                    b.Navigation("CourseStudents");

                    b.Navigation("Laptop");
                });
#pragma warning restore 612, 618
        }
    }
}
