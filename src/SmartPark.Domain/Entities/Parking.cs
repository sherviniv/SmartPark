using System.ComponentModel.DataAnnotations;

namespace SmartPark.Domain.Entities;
public class Parking
{
    public int Id { get; set; }

    [StringLength(255)]
    public required string Name { get; set; }

    public Guid UserId { get; set; }
    public ApplicationUser? ApplicationUser { get; set; }
}