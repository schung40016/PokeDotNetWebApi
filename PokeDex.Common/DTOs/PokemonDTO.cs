namespace PokeDex.Common.DTOs
{
    public class PokemonDTO
    {
        public int DexNumber { get; set; }

        public string Name { get; set; } = null!;

        public int PokemonTypeId { get; set; }

        public string? Description { get; set; }

        public int AbilityId { get; set; }
    }
}
