namespace PokeDex.Common.DTOs
{
    public class MoveDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int TypeId { get; set; }

        public string? Description { get; set; }

        public int? Damage { get; set; }

        public int Pp { get; set; }

        public bool? InflictsStatus { get; set; }

        public int? ApiMoveId { get; set; }
    }
}
