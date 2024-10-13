namespace Examen.Core.Application.Dto
{
    public class TaxiDTO
    {
        public string? Modelo { get; set; }

        public int Kilometraje { get; set; }

        public ICollection<AccesorioDTO> Accesorios { get; set; } = new List<AccesorioDTO>();
    }
}
