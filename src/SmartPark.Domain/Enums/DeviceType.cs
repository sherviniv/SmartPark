using System.ComponentModel.DataAnnotations;

namespace SmartPark.Domain.Enums;
public enum DeviceType : byte
{
    NotSet = 0,
    [Display(Name = "wifi module,camera,other sensors")]
    SmartDoor = 1
}