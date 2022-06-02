using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChineseSneakers.Models;

public class OrderModel // заказ
{
    [BindNever] // не показывать
    public int Id { get; set; }
    
    [Display(Name = "Имя")]
    [StringLength(50)]
    [Required(ErrorMessage ="Данная строка не может быть пустой")]
    public string? Name { get; set; }
    
    [Display(Name = "Фамилия")]
    [StringLength(50)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Surname { get; set; }
    
    [Display(Name = "Адрес")]
    [StringLength(500)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Address { get; set; }
    
    [Display(Name = "Номер телефона")]
    [StringLength(100)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Phone { get; set; }
    
    [Display(Name = "E-mail")]
    [StringLength(100)]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Данная строка не может быть пустой")]
    public string? Email { get; set; }
    
    [BindNever]
    [ScaffoldColumn(false)] // поле не должно отображаться в исходном коде
    public DateTime OrderTime { get; set; }
    public List<OrderDetailModel>? OrderDetails { get; set; }

}