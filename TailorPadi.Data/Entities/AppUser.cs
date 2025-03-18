using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailorPadi.Data.Entities;
public class AppUser : IdentityUser<long>
{
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;
    [MaxLength(50)]
    public string? LastName { get; set; }
    public bool IsAdmin { get; set; }
    public bool? IsEnabled { get; set; }
    public DateTimeOffset? LastLogin { get; set; }
    public int CompanyId { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}
public class AppRole : IdentityRole<long>
{ }