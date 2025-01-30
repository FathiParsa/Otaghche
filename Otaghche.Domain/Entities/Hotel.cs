using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otaghche.Domain.Entities
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="فیلد نام نمیتواند خالی باشد")]
        [Display(Name = "نام")] 
        public required string Name { get; set; }
        [Display(Name = "مشخصات")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "فیلد قیمت نمیتواند خالی باشد")]
        [Display(Name = "قیمت به ازای هر شب (تومان)")]
        public double Price { get; set; }
        [Required(ErrorMessage = "فیلد مساحت نمیتواند خالی باشد")]
        [Display(Name = "مساحت (متر مکعب)")]
        public int Sqft { get; set; }
        [Required(ErrorMessage = "فیلد ظرفیت نمیتواند خالی باشد")]
        [Display(Name = "ظرفیت نفرات")]
        public int Occupancy { get; set; }
        [Display(Name = "لینک تصویر")]
        public string? ImageUrl { get; set; }
        public DateTime?  CreatedAt { get; set; }
        public DateTime? UpdatedAt { get;set; }
    }
}
