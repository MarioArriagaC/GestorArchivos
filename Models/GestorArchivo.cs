namespace GestorArchivo.Models
{
    public class GestorItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Ruta_Archivo {get; set; }
        public bool Status { get; set; }
    }
}