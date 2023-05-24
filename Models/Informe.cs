using System;
using System.Collections.Generic;

namespace IA_ToSave_Project.Models;

public partial class Informe
{
    public int IdInf { get; set; }

    public string NInf { get; set; } = null!;

    public int IdIcdc { get; set; }

    public string Descr { get; set; } = null!;

    public int IdDoc { get; set; }

    //public virtual Documento IdDocNavigation { get; set; } = null!;

    //public virtual Incidencia IdIcdcNavigation { get; set; } = null!;
}
