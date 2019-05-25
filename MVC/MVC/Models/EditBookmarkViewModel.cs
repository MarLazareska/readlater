using ReadLater.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EditBookmarkViewModel
    {
        public int ID { get; set; }
        [Display(Name = "URL")]
        public string URL { get; set; }
        [Display(Name = "Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Date of creation")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Add new category")]
        public string NewCategory { get; set; }
        [Display(Name = "Select Category")]
        public IEnumerable<Category> Categories { get; set; }
        public int? SelectedCategory { get; set; }
    }
}