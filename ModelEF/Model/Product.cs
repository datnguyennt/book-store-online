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

	public partial class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống tên sách")]
        [Display(Name = "Tên sách")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống Metatitle")]
        [Display(Name = "Metatitle")]
        public string Metatitle { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống giá")]
        [Display(Name = "Đơn giá")]
        public Nullable<decimal> UniqueCost { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống số lượng")]
        [Display(Name = "Số lượng")]
        public Nullable<int> Quantity { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống ảnh")]
        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống trạng thái")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Không được bỏ trống tên loại hàng")]
        [Display(Name = "Tên loại sách")]
        public int CategoryID { get; set; }

        [Display(Name = "Tác giả")]
        public string Author { get; set; }
    
        public virtual Category Category { get; set; }
    }
}