using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamProduct.Models
{
    public class Product
    {
        [Required (ErrorMessage ="Enter Product Id")]
        
        [Display(Name ="Product Id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Enter Product Name")]
        [DataType(DataType.Text,ErrorMessage ="Enter Valid Name")]
        [StringLength(10,ErrorMessage ="The Value of {0} should be {1} of lenghth")]
        [MinLength(3,ErrorMessage ="minimum length of {0} should be {1}")]
        [Display(Name = "Product Name")]

        public String ProductName { get; set; }

        [Range(0,200,ErrorMessage ="value should be beetween 0-200")]
        [Required(ErrorMessage = "Enter Product Rate")]
        [Display(Name = "Rate")]
        public Decimal Rate { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [DataType(DataType.Text, ErrorMessage = "Enter Valid Name")]
        [StringLength(20, ErrorMessage = "The Value of {0} should be {1} of lenghth")]
        [MinLength(3, ErrorMessage = "minimum length of {0} should be {1}")]
        [Display(Name = "Description")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Enter Category")]
        [DataType(DataType.Text, ErrorMessage = "Enter Valid Name")]
        [StringLength(20, ErrorMessage = "The Value of {0} should be {1} of lenghth")]
        [MinLength(3, ErrorMessage = "minimum length of {0} should be {1}")]
        [Display(Name = "Category")]
        public String CategoryName { get; set; }

    }
}


/*ProductId int - Primary Key
ProductName varchar(50)
Rate Decimal(18,2)
Description varchar(200)
CategoryName varchar(50)*/