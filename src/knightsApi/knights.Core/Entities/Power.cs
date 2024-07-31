namespace Knights.Core.Entities
{
    public class Power
    {
        public Guid Id { get; set; } // Identificador único para a entidade Power
        public string Name { get; set; } // Nome do poder
        public string Description { get; set; } // Descrição do poder
        public double Strength { get; set; } // Força do poder, pode ser um valor decimal
        public string Type { get; set; } // Tipo do poder (por exemplo, "Físico", "Mágico", etc.)
        public DateTime AcquiredDate { get; set; } // Data em que o poder foi adquirido

    }
}