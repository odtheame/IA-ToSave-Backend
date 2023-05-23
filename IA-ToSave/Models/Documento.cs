using System;
using System.Collections.Generic;

namespace IA_ToSave.Models;

public partial class Documento
{
    public int IdDoc { get; set; }

    public string Bucket { get; set; } = null!;

    public string IdBucket { get; set; } = null!;

    public virtual ICollection<Informe> Informes { get; } = new List<Informe>();
}
