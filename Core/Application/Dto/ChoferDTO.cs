namespace Examen.Core.Application.Dto
{
    public class ChoferDTO
    {
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public ICollection<TaxiDTO> Taxis { get; set; } = new List<TaxiDTO>();

    }
}
