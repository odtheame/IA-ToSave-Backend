using System;
using System.Collections.Generic;

namespace IA_ToSave.Models;

public partial class Ubicacione
{
    public int IdUbi { get; set; }

    public string Cdad { get; set; } = null!;

    public string Dpto { get; set; } = null!;

    public string Lcld { get; set; } = null!;

    public string NCdt { get; set; } = null!;

    public int IdUsr { get; set; }

    public virtual Usuario IdUsrNavigation { get; set; } = null!;

    public virtual ICollection<Incidencia> Incidencia { get; } = new List<Incidencia>();
}
