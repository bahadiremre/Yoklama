﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restopos.Yoklama.DataAccess.Concrete.EntityFrameworkCore.Contexts;

namespace Restopos.Yoklama.DataAccess.Migrations
{
    [DbContext(typeof(YoklamaDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.AbsenceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AbsenceTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AbsenceTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("AbsenceStatuses");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.AbsenceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsHourly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("AbsenceTypes");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Privilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .ValueGeneratedOnUpdate()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasAnnotation("Relational:IsStored", true);

                    b.HasKey("Id");

                    b.ToTable("Privileges");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.RolePrivilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PrivilegeId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrivilegeId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePrivileges");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.AbsenceStatus", b =>
                {
                    b.HasOne("Restopos.Yoklama.Entities.Concrete.AbsenceType", "AbsenceType")
                        .WithMany("AbsenceStatuses")
                        .HasForeignKey("AbsenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restopos.Yoklama.Entities.Concrete.User", "User")
                        .WithMany("AbsenceStatuses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbsenceType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.RolePrivilege", b =>
                {
                    b.HasOne("Restopos.Yoklama.Entities.Concrete.Privilege", "Privilege")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restopos.Yoklama.Entities.Concrete.Role", "Role")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.User", b =>
                {
                    b.HasOne("Restopos.Yoklama.Entities.Concrete.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.UserRole", b =>
                {
                    b.HasOne("Restopos.Yoklama.Entities.Concrete.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Restopos.Yoklama.Entities.Concrete.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.AbsenceType", b =>
                {
                    b.Navigation("AbsenceStatuses");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Privilege", b =>
                {
                    b.Navigation("RolePrivileges");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.Role", b =>
                {
                    b.Navigation("RolePrivileges");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Restopos.Yoklama.Entities.Concrete.User", b =>
                {
                    b.Navigation("AbsenceStatuses");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
