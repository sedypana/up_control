using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class Juri
{
    public int IdJuri { get; set; }

    public string NameFirst { get; set; } = null!;

    public string NameLast { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public int? IdGender { get; set; }

    public string Email { get; set; } = null!;

    public DateTime Dr { get; set; }

    public int? IdCountry { get; set; }

    public string NumberPhone { get; set; } = null!;

    public int? IdNapravleniya { get; set; }

    public string Password { get; set; } = null!;

    public string Foto { get; set; } = null!;
    public Bitmap Image => ConvertToBItmap.LoadImage(Foto, "D:\\desktop\\Desktop\\Desktop\\Assets\\juri_media\\");

    public int? IdRole { get; set; }

    public virtual ICollection<Activity> ActivityJuri1Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityJuri2Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityJuri3Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityJuri4Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityJuri5Navigations { get; set; } = new List<Activity>();

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Napravlenie? IdNapravleniyaNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
