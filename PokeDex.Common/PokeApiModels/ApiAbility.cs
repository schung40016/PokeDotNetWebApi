namespace PokeDex.Common.PokeApiModels
{
    public class ApiAbility
    {
        public int id { get; set; }     

        public string name { get; set; } = null!;

        public List<ApiAbilityEffectEntry> effect_entries { get; set; } = null!;

        public List<ApiAbilityPokemon> pokemon { get; set; } = null!;
    }

    public class ApiAbilityEffectEntry
    {
        public string effect { get; set; } = null!;

        public ApiAbilityEffectEntryLanguage language { get; set; } = null!;

        public string short_effect { get; set; } = null!;
    }

    public class ApiAbilityEffectEntryLanguage
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiAbilityPokemon
    {
        public bool is_hidden { get; set; } 

        public ApiAbilityPokemonPokemon pokemon { get; set; } = null!;

        public int slot { get; set; }
    }

    public class ApiAbilityPokemonPokemon
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }
}