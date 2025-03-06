using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class User
{
    public int IdUsera { get; set; }

    public string NameFirst { get; set; } = null!;

    public string NameLast { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdCountry { get; set; }

    public string NumberPhone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public int? IdGender { get; set; }

    public int? IdRole { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
