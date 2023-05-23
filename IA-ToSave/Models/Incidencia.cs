using System;
using System.Collections.Generic;

namespace IA_ToSave.Models;

public partial class Incidencia
{
    public int IdIcdc { get; set; }

    public string Anmla { get; set; } = null!;

    public int IdUbi { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string Sjts { get; set; } = null!;

    public byte Apbc { get; set; }

    public virtual Ubicacione IdUbiNavigation { get; set; } = null!;

    public virtual ICollection<Informe> Informes { get; } = new List<Informe>();
}
