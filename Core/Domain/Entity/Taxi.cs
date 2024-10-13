namespace Examen.Core.Domain.Entity
{
    public class Taxi
    {
        public int Id { get; set; }

        public string? Modelo { get; set; }

        public int Kilometraje { get; set; }

        public int ChoferId { get; set; }

        public virtual ICollection<Accesorio> Accesorios { get; set; } = new List<Accesorio>();

    }
}
