
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Otaghche.Domain.Entities
{
    public class Amenity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "فیلد نام نمیتواند خالی باشد")]
        [Display(Name = "نام")]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [ForeignKey("Hotel")]
        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [Display(Name = "هتل")]
        public int HotelId { get; set; }

        [ValidateNever]
        public Hotel Hotel { get; set; }
    }
}
