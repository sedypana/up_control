using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class Activity
{
    public int IdActivity { get; set; }

    public string NameActivity { get; set; } = null!;

    public int? Juri1 { get; set; }

    public int? Juri2 { get; set; }

    public int? Juri3 { get; set; }

    public int? Juri4 { get; set; }

    public int? Juri5 { get; set; }

    public int? IdModer { get; set; }

    public int? Days { get; set; }

    public TimeOnly? TimeStart { get; set; }

    public virtual Moder? IdModerNavigation { get; set; }

    public virtual Juri? Juri1Navigation { get; set; }

    public virtual Juri? Juri2Navigation { get; set; }

    public virtual Juri? Juri3Navigation { get; set; }

    public virtual Juri? Juri4Navigation { get; set; }

    public virtual Juri? Juri5Navigation { get; set; }
}
