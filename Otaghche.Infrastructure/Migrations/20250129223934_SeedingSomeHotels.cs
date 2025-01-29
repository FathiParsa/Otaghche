using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otaghche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSomeHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, "اگر بازدید آسان و دسترسی راحت به جاذبه‌های گردشگری در سفر به جزیره کیش برایتان اولویت اصلی است، بدون تردید هتل فانوس می‌تواند انتخاب ایده‌آلی برای شما و همراهانتان باشد. هتل فانوس کیش یکی از هتل‌های دو ستاره معتبر و نام‌آشنای جزیره است که اولین خشت فعالیت خود را در سال ۱۳۷۶ بنا نهاد. ساختمان این مجموعه با الهام از معماری منطقه و کمی مدرنیته در میان باغی سرسبز در دو طبقه با چهل اتاق طراحی و ساخته شد. هتل فانوس برای ارتقا سطح کیفی و کمی امکانات و خدمات خود در سال ۱۳۹۵ مجددا مورد بازسازی قرار گرفت.", "https://placehold.co/600x400", "هتل فانوس", 4, 200.0, 550, null },
                    { 2, null, "برای یک سفر تفریحی و لوکس به جزیره کیش یکی از بهترین گزینه‌ها هتل مارینا پارک است. این هتل معماری بی‌نظیر و نمای خارجی منحصر‌به‌فردی دارد که آن را از سایر هتل‌های جزیره متمایز می‌کند. این هتل پنج ستاره در سال ۱۳۹۰ کار خود را آغاز کرد و از همان ابتدا خود را به عنوان هتلی مجلل ثابت کرد. این هتل در مرکز یک پارک ساحلی قرار گرفته است. این پارک حدود ۱۷ هکتار مساحت دارد و انواع گونه‌های بومی گیاهی را می‌توان در آن یافت", "https://placehold.co/600x401", "هتل مارینا پارک", 4, 300.0, 550, null },
                    { 3, null, "تنها، دیدن یک تصویر از هتل ترنج کیش کافی است تا بدانیم با یکی از خاص‌ترین هتل‌های پنج ستاره ایران مواجهیم. هتل ترنج که به عنوان اولین هتل دریایی خاورمیانه شناخته می‌شود، با افتتاح فاز اول خود در سال 1394 شروع به کار کرد. فاز یک این هتل متشکل از یکصد سوییت بوده که با یک اسکله چوبی به طول یک کیلومتر به یکدیگر متصل شده‌اند و چیدمان نهایی آن‌ها از بالا، تصویر یک بته‌جقه (یکی از نمادهای اصیل هنر ایرانی) بر آب‌های نیلگون خلیج فارس را نشان می‌دهد.", "https://placehold.co/600x402", "هتل ترنج", 4, 400.0, 750, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
