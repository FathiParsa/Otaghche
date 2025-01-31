using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Otaghche.Domain.Entities
{
    public class Room
    {
        [Display(Name = "شماره اتاق")]
        [Required(ErrorMessage = "فیلد شماره اتاق نمیتواند خالی باشد")]
        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomNumber { get; set; }

        [Display(Name = "هتل")]
        [Required(ErrorMessage = "این فیلد نمیتواند خالی باشد")]
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        [ValidateNever]
        public Hotel Hotel { get; set; }    

        [Display(Name ="مشخصات")]
        public string? Details { get; set; }
    }
}
