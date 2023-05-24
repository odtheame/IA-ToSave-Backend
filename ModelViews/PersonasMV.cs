namespace IA_ToSave_Project.ModelViews
{
    public class PersonasMV
    {
        public int ID_Persona { get; set; }

        public string Primer_Nombre { get; set; } = null!;

        public string? Segundo_Nombre { get; set; }

        public string? Primer_Apellido { get; set; }

        public string? Segundo_Apellido { get; set; }

        public string? Num_Documento { get; set; }

        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public DateTime Fecha_Ingreso { get; set; }
    }
}
