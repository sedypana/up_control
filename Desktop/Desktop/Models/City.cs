using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class City
{
    public int IdCity { get; set; }

    public string NameCity { get; set; } = null!;

    public string? PhotoCity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
