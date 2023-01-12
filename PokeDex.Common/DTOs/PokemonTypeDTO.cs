namespace PokeDex.Common.DTOs
{
    public class PokemonTypeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Strengths { get; set; }

        public string? Weaknesses { get; set; }

        public string? NoEffects { get; set; }
    }
}
