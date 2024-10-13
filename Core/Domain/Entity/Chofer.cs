namespace Examen.Core.Domain.Entity
{
    public class Chofer
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Identificacion { get; set; }

        public int Edad { get; set; }

        public virtual ICollection<Taxi> Taxis { get; set; } = new List<Taxi>();
    }
}
