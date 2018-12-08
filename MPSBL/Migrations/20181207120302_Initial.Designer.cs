﻿// <auto-generated />
using System;
using MPSBL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MPSBL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181207120302_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MPSBL.Models.DonationCenter", b =>
                {
                    b.Property<int>("DonationCenterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("DonationCenterId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("MPSBL.Models.DonationRequest", b =>
                {
                    b.Property<int>("DonationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CenterName");

                    b.Property<string>("DateIssued");

                    b.Property<string>("Description");

                    b.Property<string>("Doctor");

                    b.Property<int?>("DonationCenterId");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Pacient");

                    b.HasKey("DonationRequestId");

                    b.HasIndex("DonationCenterId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("MPSBL.Models.DonationRequest", b =>
                {
                    b.HasOne("MPSBL.Models.DonationCenter", "DonationCenter")
                        .WithMany()
                        .HasForeignKey("DonationCenterId");
                });
#pragma warning restore 612, 618
        }
    }
}
