using System;
using System.Collections.Generic;

namespace Desktop.Models;

public partial class ActivityEvent
{
    public int? Activity { get; set; }

    public int? EventId { get; set; }

    public virtual Activity? ActivityNavigation { get; set; }

    public virtual Event? Event { get; set; }
}
