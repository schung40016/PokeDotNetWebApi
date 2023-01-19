namespace PokeDex.Common.DTOs
{
    public class AbilityDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int? MoveCycle { get; set; }

        public int? ApiAbilityId { get; set; }
    }
}
