using System;
using System.Collections.Generic;

namespace IA_ToSave_Project.Models;

public partial class Usuario
{
    public int IdUsr { get; set; }

    public string Usr { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public int IdPrsn { get; set; }

    public virtual Persona IdPrsnNavigation { get; set; } = null!;

    public virtual ICollection<Ubicacione> Ubicaciones { get; } = new List<Ubicacione>();
}
