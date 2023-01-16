namespace ProductManagementApi.Model;
using System;
using System.ComponentModel.DataAnnotations;


public class Product{
    public int productid{get;set;}

    [Required]
    public String productname{get;set;}="";

    [Required]
     public String productqty{get;set;}="";

      [Required]
     public String price{get;set;}="";



}