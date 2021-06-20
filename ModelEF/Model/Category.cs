﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống metatitle")]
        [Display(Name = "Metatitle")]
        public string Metatitle { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống tên loại sách")]
        [Display(Name = "Tên loại sách")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống mô tả")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
