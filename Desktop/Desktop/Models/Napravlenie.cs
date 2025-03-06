using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class Napravlenie
{
    public int IdNapravleniya { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Juri> Juris { get; set; } = new List<Juri>();

    public virtual ICollection<Moder> Moders { get; set; } = new List<Moder>();
}
