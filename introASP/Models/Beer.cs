using System;
using System.Collections.Generic;

namespace introASP.Models;

public partial class Beer
{
    public int Beerld { get; set; }

    public string? Name { get; set; }

    public virtual Brandld BeerldNavigation { get; set; } = null!;
}
