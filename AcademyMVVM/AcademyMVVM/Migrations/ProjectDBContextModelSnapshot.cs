﻿// <auto-generated />
using System;
using AcademyMVVM.Lib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademyMVVM.Migrations
{
    [DbContext(typeof(ProjectDBContext))]
    partial class ProjectDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Common.Lib.Core.Entity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entity");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Courses", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<int>("ChairNumber")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateEnrolment")
                        .HasColumnType("TEXT");

                    b.Property<string>("DniStudent")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameSubject")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SubjectsId")
                        .HasColumnType("TEXT");

                    b.HasIndex("StudentsId");

                    b.HasIndex("SubjectsId");

                    b.HasDiscriminator().HasValue("Courses");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Exams", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<DateTime>("DateExam")
                        .HasColumnType("TEXT");

                    b.Property<string>("DniStudent")
                        .HasColumnName("Exams_DniStudent")
                        .HasColumnType("TEXT");

                    b.Property<double>("Mark")
                        .HasColumnType("REAL");

                    b.Property<string>("NameSubject")
                        .HasColumnName("Exams_NameSubject")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("StudentsId")
                        .HasColumnName("Exams_StudentsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SubjectsId")
                        .HasColumnName("Exams_SubjectsId")
                        .HasColumnType("TEXT");

                    b.HasIndex("StudentsId");

                    b.HasIndex("SubjectsId");

                    b.HasDiscriminator().HasValue("Exams");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Students", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("Dni")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Students");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Subjects", b =>
                {
                    b.HasBaseType("Common.Lib.Core.Entity");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Teacher")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Subjects");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Courses", b =>
                {
                    b.HasOne("AcademyMVVM.Lib.Models.Students", "Students")
                        .WithMany("Courses")
                        .HasForeignKey("StudentsId");

                    b.HasOne("AcademyMVVM.Lib.Models.Subjects", "Subjects")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectsId");
                });

            modelBuilder.Entity("AcademyMVVM.Lib.Models.Exams", b =>
                {
                    b.HasOne("AcademyMVVM.Lib.Models.Students", "Students")
                        .WithMany("Exams")
                        .HasForeignKey("StudentsId");

                    b.HasOne("AcademyMVVM.Lib.Models.Subjects", "Subjects")
                        .WithMany("Exams")
                        .HasForeignKey("SubjectsId");
                });
#pragma warning restore 612, 618
        }
    }
}
