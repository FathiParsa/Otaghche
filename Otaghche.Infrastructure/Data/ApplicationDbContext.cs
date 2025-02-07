using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Otaghche.Domain.Entities;

namespace Otaghche.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(

                new Hotel
                {
                    Id = 1,
                    Name = "هتل فانوس",
                    Description = "اگر بازدید آسان و دسترسی راحت به جاذبه‌های گردشگری در سفر به جزیره کیش برایتان اولویت اصلی است، بدون تردید هتل فانوس می‌تواند انتخاب ایده‌آلی برای شما و همراهانتان باشد. هتل فانوس کیش یکی از هتل‌های دو ستاره معتبر و نام‌آشنای جزیره است که اولین خشت فعالیت خود را در سال ۱۳۷۶ بنا نهاد. ساختمان این مجموعه با الهام از معماری منطقه و کمی مدرنیته در میان باغی سرسبز در دو طبقه با چهل اتاق طراحی و ساخته شد. هتل فانوس برای ارتقا سطح کیفی و کمی امکانات و خدمات خود در سال ۱۳۹۵ مجددا مورد بازسازی قرار گرفت.",
                    ImageUrl = "https://placehold.co/600x400",
                    Occupancy = 4,
                    Price = 200,
                    Sqft = 550,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "هتل مارینا پارک",
                    Description = "برای یک سفر تفریحی و لوکس به جزیره کیش یکی از بهترین گزینه‌ها هتل مارینا پارک است. این هتل معماری بی‌نظیر و نمای خارجی منحصر‌به‌فردی دارد که آن را از سایر هتل‌های جزیره متمایز می‌کند. این هتل پنج ستاره در سال ۱۳۹۰ کار خود را آغاز کرد و از همان ابتدا خود را به عنوان هتلی مجلل ثابت کرد. این هتل در مرکز یک پارک ساحلی قرار گرفته است. این پارک حدود ۱۷ هکتار مساحت دارد و انواع گونه‌های بومی گیاهی را می‌توان در آن یافت",
                    ImageUrl = "https://placehold.co/600x401",
                    Occupancy = 4,
                    Price = 300,
                    Sqft = 550,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "هتل ترنج",
                    Description = "تنها، دیدن یک تصویر از هتل ترنج کیش کافی است تا بدانیم با یکی از خاص‌ترین هتل‌های پنج ستاره ایران مواجهیم. هتل ترنج که به عنوان اولین هتل دریایی خاورمیانه شناخته می‌شود، با افتتاح فاز اول خود در سال 1394 شروع به کار کرد. فاز یک این هتل متشکل از یکصد سوییت بوده که با یک اسکله چوبی به طول یک کیلومتر به یکدیگر متصل شده‌اند و چیدمان نهایی آن‌ها از بالا، تصویر یک بته‌جقه (یکی از نمادهای اصیل هنر ایرانی) بر آب‌های نیلگون خلیج فارس را نشان می‌دهد.",
                    ImageUrl = "https://placehold.co/600x402",
                    Occupancy = 4,
                    Price = 400,
                    Sqft = 750,
                }
            );

            modelBuilder.Entity<Room>().HasData(

                new Room
                {
                    HotelId = 1,
                    RoomNumber = 101
                },
                new Room
                {
                    HotelId = 1,
                    RoomNumber = 102
                },
                new Room
                {
                    HotelId = 1,
                    RoomNumber = 103
                },
                new Room
                {
                    HotelId = 2,
                    RoomNumber = 201
                },
                new Room
                {
                    HotelId = 2,
                    RoomNumber = 202
                },
                new Room
                {
                    HotelId = 2,
                    RoomNumber = 203
                },
                new Room
                {
                    HotelId = 3,
                    RoomNumber = 301
                },
                new Room
                {
                    HotelId = 3,
                    RoomNumber = 302
                },
                new Room
                {
                    HotelId = 3,
                    RoomNumber = 303
                });

            modelBuilder.Entity<Room>().HasKey(k => k.RoomNumber);

            modelBuilder.Entity<Room>().Property(k => k.RoomNumber).ValueGeneratedNever();


            modelBuilder.Entity<Amenity>().HasData(

                  new Amenity
                  {
                      Id = 1,
                      HotelId = 1,
                      Name = "وای فای"
                  }, new Amenity
                  {
                      Id = 2,
                      HotelId = 1,
                      Name = "صبحانه"
                  }, new Amenity
                  {
                      Id = 3,
                      HotelId = 1,
                      Name = "تلویزیون"
                  }, new Amenity
                  {
                      Id = 4,
                      HotelId = 1,
                      Name = "یخچال"
                  },

                  new Amenity
                  {
                      Id = 5,
                      HotelId = 2,
                      Name = "رستوران"
                  }, new Amenity
                  {
                      Id = 6,
                      HotelId = 2,
                      Name = "تاکسی سرویس"
                  }, new Amenity
                  {
                      Id = 7,
                      HotelId = 2,
                      Name = "صندوق امانات"
                  }, new Amenity
                  {
                      Id = 8,
                      HotelId = 2,
                      Name = "سرویس فرنگی"
                  },

                  new Amenity
                  {
                      Id = 9,
                      HotelId = 3,
                      Name = "کافی شاپ"
                  }, new Amenity
                  {
                      Id = 10,
                      HotelId = 3,
                      Name = "سالن اجتماعات"
                  }, new Amenity
                  {
                      Id = 11,
                      HotelId = 3,
                      Name = "فروشگاه و خرید"
                  }
            );
        }
    }
}
