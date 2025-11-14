using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorMilk.Models;

public partial class client
{
    public int idClient { get; set; }

    [Required(ErrorMessage = "Login Required")]
    public string login { get; set; } = null!;

    [Required(ErrorMessage = "Password Required")]
    public string password { get; set; } = null!;
}