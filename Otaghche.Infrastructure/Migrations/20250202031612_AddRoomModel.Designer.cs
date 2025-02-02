﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Otaghche.Infrastructure.Data;

#nullable disable

namespace Otaghche.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250202031612_AddRoomModel")]
    partial class AddRoomModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Otaghche.Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "اگر بازدید آسان و دسترسی راحت به جاذبه‌های گردشگری در سفر به جزیره کیش برایتان اولویت اصلی است، بدون تردید هتل فانوس می‌تواند انتخاب ایده‌آلی برای شما و همراهانتان باشد. هتل فانوس کیش یکی از هتل‌های دو ستاره معتبر و نام‌آشنای جزیره است که اولین خشت فعالیت خود را در سال ۱۳۷۶ بنا نهاد. ساختمان این مجموعه با الهام از معماری منطقه و کمی مدرنیته در میان باغی سرسبز در دو طبقه با چهل اتاق طراحی و ساخته شد. هتل فانوس برای ارتقا سطح کیفی و کمی امکانات و خدمات خود در سال ۱۳۹۵ مجددا مورد بازسازی قرار گرفت.",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "هتل فانوس",
                            Occupancy = 4,
                            Price = 200.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 2,
                            Description = "برای یک سفر تفریحی و لوکس به جزیره کیش یکی از بهترین گزینه‌ها هتل مارینا پارک است. این هتل معماری بی‌نظیر و نمای خارجی منحصر‌به‌فردی دارد که آن را از سایر هتل‌های جزیره متمایز می‌کند. این هتل پنج ستاره در سال ۱۳۹۰ کار خود را آغاز کرد و از همان ابتدا خود را به عنوان هتلی مجلل ثابت کرد. این هتل در مرکز یک پارک ساحلی قرار گرفته است. این پارک حدود ۱۷ هکتار مساحت دارد و انواع گونه‌های بومی گیاهی را می‌توان در آن یافت",
                            ImageUrl = "https://placehold.co/600x401",
                            Name = "هتل مارینا پارک",
                            Occupancy = 4,
                            Price = 300.0,
                            Sqft = 550
                        },
                        new
                        {
                            Id = 3,
                            Description = "تنها، دیدن یک تصویر از هتل ترنج کیش کافی است تا بدانیم با یکی از خاص‌ترین هتل‌های پنج ستاره ایران مواجهیم. هتل ترنج که به عنوان اولین هتل دریایی خاورمیانه شناخته می‌شود، با افتتاح فاز اول خود در سال 1394 شروع به کار کرد. فاز یک این هتل متشکل از یکصد سوییت بوده که با یک اسکله چوبی به طول یک کیلومتر به یکدیگر متصل شده‌اند و چیدمان نهایی آن‌ها از بالا، تصویر یک بته‌جقه (یکی از نمادهای اصیل هنر ایرانی) بر آب‌های نیلگون خلیج فارس را نشان می‌دهد.",
                            ImageUrl = "https://placehold.co/600x402",
                            Name = "هتل ترنج",
                            Occupancy = 4,
                            Price = 400.0,
                            Sqft = 750
                        });
                });

            modelBuilder.Entity("Otaghche.Domain.Entities.Room", b =>
                {
                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("RoomNumber");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomNumber = 101,
                            HotelId = 1
                        },
                        new
                        {
                            RoomNumber = 102,
                            HotelId = 1
                        },
                        new
                        {
                            RoomNumber = 103,
                            HotelId = 1
                        },
                        new
                        {
                            RoomNumber = 201,
                            HotelId = 2
                        },
                        new
                        {
                            RoomNumber = 202,
                            HotelId = 2
                        },
                        new
                        {
                            RoomNumber = 203,
                            HotelId = 2
                        },
                        new
                        {
                            RoomNumber = 301,
                            HotelId = 3
                        },
                        new
                        {
                            RoomNumber = 302,
                            HotelId = 3
                        },
                        new
                        {
                            RoomNumber = 303,
                            HotelId = 3
                        });
                });

            modelBuilder.Entity("Otaghche.Domain.Entities.Room", b =>
                {
                    b.HasOne("Otaghche.Domain.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });
#pragma warning restore 612, 618
        }
    }
}
