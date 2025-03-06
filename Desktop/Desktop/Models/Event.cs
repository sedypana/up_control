using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;

namespace Desktop.Models;

public partial class Event
{
    
    public int IdEvent { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateStart { get; set; }

    public int? Days { get; set; }

    public int? City { get; set; }
    public string Photo { get; set; }
    public Bitmap Photo_Image => ConvertToBItmap.LoadImage(Photo, "D:\\desktop\\Desktop\\Desktop\\Assets\\events_media");

    public virtual City? CityNavigation { get; set; }

    
}
