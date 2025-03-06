using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class Participant
{
    public int IdParticipants { get; set; }

    public string NameFirst { get; set; } = null!;

    public string NameLast { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dr { get; set; }

    public int? IdCountry { get; set; }

    public string NumberPhone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Photo { get; set; } = null!;
    public Bitmap Image => ConvertToBItmap.LoadImage(Photo, "D:\\desktop\\Desktop\\Desktop\\Assets\\participant_media\\");

    public int? IdGender { get; set; }

    public int? IdRole { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Gender? IdGenderNavigation { get; set; }

    public virtual Role? IdRoleNavigation { get; set; }
}
