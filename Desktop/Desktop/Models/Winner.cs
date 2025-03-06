using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class Winner
{
    public int? IdWinner { get; set; }

    public int? IdEvent { get; set; }

    public virtual Event? IdEventNavigation { get; set; }

    public virtual Participant? IdWinnerNavigation { get; set; }
}
