using System;
using System.Collections.Generic;

namespace IA_ToSave.Models;

public partial class Cliente
{
    public int IdCli { get; set; }

    public string Nom { get; set; } = null!;

    public string Dir { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public int IdPrsn { get; set; }

    public virtual Persona IdPrsnNavigation { get; set; } = null!;
}
