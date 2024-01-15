using System;
using System.Collections.Generic;

namespace introASP.Models;

public partial class Brandld
{
    public int Brandld1 { get; set; }

    public string? Name { get; set; }

    public virtual Beer? Beer { get; set; }
}
