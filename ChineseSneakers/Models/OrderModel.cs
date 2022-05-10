using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChineseSneakers.Models;

public class OrderModel // заказ
{
    [BindNever]
    public int Id { get; set; }
    [Display(Name = "Введите имя")]
    [StringLength(20)]
    [Required(ErrorMessage ="Данная строка не может быть пустой")]
    public string? Name { get; set; }
    
    [Display(Name = "Введите фамилию")]
    [StringLength(20)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Surname { get; set; }
    
    [Display(Name = "Введите адрес")]
    [StringLength(20)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Address { get; set; }
    
    [Display(Name = "Номер телефона")]
    [StringLength(20)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Phone { get; set; }
    
    [Display(Name = "Email")]
    [StringLength(20)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Email { get; set; }
    
    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderTime { get; set; }
    public List<OrderDetailModel>? Payments { get; set; }

}