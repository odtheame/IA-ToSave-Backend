using System;
using System.Collections.Generic;

namespace IA_ToSave_Project.Models;

public partial class Ubicacione
{
    public int IdUbi { get; set; }

    public string? Cdad { get; set; } 

    public string? Dpto { get; set; }

    public string? Lcld { get; set; } 

    public string? NCdt { get; set; }

    public int IdUsr { get; set; }


    //public virtual Usuario IdUsrNavigation { get; set; } = null!;

    public virtual ICollection<Incidencia> Incidencia { get; } = new List<Incidencia>();
}
