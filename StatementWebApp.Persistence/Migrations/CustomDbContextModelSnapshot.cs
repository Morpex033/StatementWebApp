﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StatementWebApp.Persistence.Context;

#nullable disable

namespace StatementWebApp.Persistence.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    partial class CustomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DepartmentTeacher", b =>
                {
                    b.Property<Guid>("DepartmentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeachersId")
                        .HasColumnType("uuid");

                    b.HasKey("DepartmentsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("DepartmentTeacher");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("InstituteId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InstituteId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("StatementId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uuid");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StatementId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Statement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid");

                    b.HasKey("StudentsId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("StudentSubject");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<Guid>("SubjectsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TeachersId")
                        .HasColumnType("uuid");

                    b.HasKey("SubjectsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("DepartmentTeacher", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Department", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Institute", "Institute")
                        .WithMany("Departments")
                        .HasForeignKey("InstituteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institute");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Grade", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Statement", "Statement")
                        .WithMany("Grades")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Subject", "Subject")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statement");

                    b.Navigation("Student");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Group", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Student", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("StudentSubject", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("StatementWebApp.Core.Entity.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StatementWebApp.Core.Entity.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Department", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Institute", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Statement", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Student", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Subject", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("StatementWebApp.Core.Entity.Teacher", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
