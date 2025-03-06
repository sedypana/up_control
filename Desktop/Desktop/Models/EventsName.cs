using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class EventsName
{
    public int IdEvent { get; set; }

    public string NameEvent { get; set; } = null!;

    public virtual ICollection<Moder> Moders { get; set; } = new List<Moder>();
}
