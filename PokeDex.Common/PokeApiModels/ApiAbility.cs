namespace PokeDex.Common.PokeApiModels
{
    public class ApiAbility
    {
        public int id { get; set; }

        public string name { get; set; }

        public List<ApiAbilityEffectEntry> effect_entries { get; set; }

        public List<ApiAbilityPokemon> pokemon { get; set; }
    }

    public class ApiAbilityEffectEntry
    {
        public string effect { get; set; }

        public ApiAbilityEffectEntryLanguage language { get; set; }

        public string short_effect { get; set; }
    }

    public class ApiAbilityEffectEntryLanguage
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiAbilityPokemon
    {
        public bool is_hidden { get; set; }

        public ApiAbilityPokemonPokemon pokemon { get; set; }

        public int slot { get; set; }
    }

    public class ApiAbilityPokemonPokemon
    {
        public string name { get; set; }

        public string url { get; set; }
    }
}