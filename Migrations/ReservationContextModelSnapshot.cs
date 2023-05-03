using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ReservationSystem2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem2022.Migrations
{
    [DbContext(typeof(ReservationContext))]
    partial class ReservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReservationSystem2022.Models.Image", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);
                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.Property<long>("TargetId")
                    .HasColumnType("bigint");
                b.Property<string>("Url")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.HasKey("Id");
                b.HasIndex("TargetId");
                b.ToTable("Images");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Item", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);
                b.Property<string>("Description")
                    .HasColumnType("nvarchar(max)");
                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.Property<long?>("Ownerid")
                    .HasColumnType("bigint");
                b.Property<long>("accessCount")
                    .HasColumnType("bigint");
                b.HasKey("Id");
                b.HasIndex("Ownerid");
                b.ToTable("Items");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Reservation", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);
                b.Property<DateTime>("EndTime")
                    .HasColumnType("datetime2");
                b.Property<long?>("Ownerid")
                    .HasColumnType("bigint");
                b.Property<DateTime>("StartTime")
                    .HasColumnType("datetime2");
                b.Property<long?>("TargetId")
                    .HasColumnType("bigint");
                b.HasKey("Id");
                b.HasIndex("Ownerid");
                b.HasIndex("TargetId");
                b.ToTable("Reservations");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.User", b =>
            {
                b.Property<long>("id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint");
                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("id"), 1L, 1);
                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.Property<DateTime>("JoinDate")
                    .HasColumnType("datetime2");
                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.Property<DateTime>("LoginDate")
                    .HasColumnType("datetime2");
                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.Property<string>("UserName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");
                b.HasKey("id");
                b.ToTable("Users");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Image", b =>
            {
                b.HasOne("ReservationSystem2022.Models.Item", "Target")
                    .WithMany("Images")
                    .HasForeignKey("TargetId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
                b.Navigation("Target");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Item", b =>
            {
                b.HasOne("ReservationSystem2022.Models.User", "Owner")
                    .WithMany()
                    .HasForeignKey("Ownerid");
                b.Navigation("Owner");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Reservation", b =>
            {
                b.HasOne("ReservationSystem2022.Models.User", "Owner")
                    .WithMany()
                    .HasForeignKey("Ownerid");
                b.HasOne("ReservationSystem2022.Models.Item", "Target")
                    .WithMany()
                    .HasForeignKey("TargetId");
                b.Navigation("Owner");
                b.Navigation("Target");
            });

            modelBuilder.Entity("ReservationSystem2022.Models.Item", b =>
            {
                b.Navigation("Images");
            });
#pragma warning restore 612, 618
        }
    }
}
