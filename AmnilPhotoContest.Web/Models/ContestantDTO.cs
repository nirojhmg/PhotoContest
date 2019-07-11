using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AmnilPhotoContest.Web.Models
{
    public class ContestantDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name ="District")]
        public int DistrictId { get; set; }
        public string District { get; set; }
        public IEnumerable<DistrictDTO> Districts { get; set; }
        [Required]
        [Display(Name ="Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name ="Status")]
        public int IsActive { get; set; }
        [Required]
        [Display(Name ="Upload Photo")]
        public string PhotoUrl { get; set; }
        [Required]
        [Display(Name ="Address")]
        public string Address { get; set; }
    }
}