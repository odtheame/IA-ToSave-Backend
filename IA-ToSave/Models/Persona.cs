using System;
using System.Collections.Generic;

namespace IA_ToSave.Models;

public partial class Persona
{
    public int IdPrsn { get; set; }

    public string PrNom { get; set; } = null!;

    public string? SdNom { get; set; }

    public string PrApe { get; set; } = null!;

    public string? SdApe { get; set; }

    public string NDcmt { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telef { get; set; } = null!;

    public DateTime FeNaci { get; set; }

    public DateTime FeIngr { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
