namespace PokeDex.Common.PokeApiModels
{
    public class ApiPokemon
    {
        // Dex Number
        public int id { get; set; }

        // Name
        public string name { get; set; } = null!;

        // Type
        public List<ApiPokemonTypes> types { get; set; } = null!;

        // Description
        // Found under characteristics, might need to create a new APiObject to extract the flavor_entry_text.

        // Ability
        public List<ApiPokemonAbilities> abilities { get; set; } = null!;

        // Moves
        public List<ApiPokemonMoves> moves { get; set; } = null!;

    }

    public class ApiPokemonTypes
    {
        public int slot { get; set; }

        public ApiPokemonTypesType type { get; set; } = null!;
    }

    public class ApiPokemonTypesType
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiPokemonAbilities
    {
        public ApiPokemonAbilitiesAbility ability { get; set; } = null!;

        public bool is_hidden { get; set; }

        public int slot { get; set; }
    }

    public class ApiPokemonAbilitiesAbility
    {
        public string name { get; set; } = null!;
        
        public string url { get; set; } = null!;
    }

    public class ApiPokemonMoves
    {
        public ApiPokemonMovesMove move { get; set; } = null!;

        public List<ApiPokemonMovesVersionGroupDetails> version_group_details { get; set; } = null!;
    }

    public class ApiPokemonMovesMove
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiPokemonMovesVersionGroupDetails
    {
        public int level_learned_at { get; set; }

        public ApiPokemonMovesVersionGroupDetailsMoveLearnMethod move_learn_method { get; set; } = null!;

        public ApiPokemonMovesVersionGroupDetailsVersionGroup version_group { get; set; } = null!;
    }

    public class ApiPokemonMovesVersionGroupDetailsMoveLearnMethod
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiPokemonMovesVersionGroupDetailsVersionGroup
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }
}
