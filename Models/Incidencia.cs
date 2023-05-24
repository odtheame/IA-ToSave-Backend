using System;
using System.Collections.Generic;

namespace IA_ToSave_Project.Models;

public partial class Incidencia
{

    public string? Cdad { get; set; }
    public string? Lcld { get; set; }
    public string? Anmla { get; set; }

    public int IdIcdc { get; set; }
    public TimeSpan Hora { get; internal set; }


    public int IdUbi { get; set; }

    public DateTime Fecha { get; set; }


    public string Sjts { get; set; } = null!;

    public byte Apbc { get; set; }

    //public virtual Ubicacione IdUbiNavigation { get; set; } = null!;

    //public virtual ICollection<Informe> Informes { get; } = new List<Informe>();
}
