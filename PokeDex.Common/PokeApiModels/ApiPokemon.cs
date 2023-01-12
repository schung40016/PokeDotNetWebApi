namespace PokeDex.Common.PokeApiModels
{
    public class ApiPokemon
    {
        // Dex Number
        public int id { get; set; }

        // Name
        public string name { get; set; }

        // Type
        public List<ApiPokemonTypes> types { get; set; }

        // Description
        // Found under characteristics, might need to create a new APiObject to extract the flavor_entry_text.

        // Ability
        public List<ApiPokemonAbilities> abilities { get; set; }

        // Moves
        public List<ApiPokemonMoves> moves { get; set; }

    }

    public class ApiPokemonTypes
    {
        public int slot { get; set; }

        public ApiPokemonTypesType type { get; set; }
    }

    public class ApiPokemonTypesType
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class ApiPokemonAbilities
    {
        public ApiPokemonAbilitiesAbility ability { get; set; }

        public bool is_hidden { get; set; }

        public int slot { get; set; }
    }

    public class ApiPokemonAbilitiesAbility
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiPokemonMoves
    {
        public ApiPokemonMovesMove move { get; set; }

        public List<ApiPokemonMovesVersionGroupDetails> version_group_details { get; set; }
    }

    public class ApiPokemonMovesMove
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiPokemonMovesVersionGroupDetails
    {
        public int level_learned_at { get; set; }

        public ApiPokemonMovesVersionGroupDetailsMoveLearnMethod move_learn_method { get; set; }

        public ApiPokemonMovesVersionGroupDetailsVersionGroup version_group { get; set; }
    }

    public class ApiPokemonMovesVersionGroupDetailsMoveLearnMethod
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiPokemonMovesVersionGroupDetailsVersionGroup
    {
        public string name { get; set; }

        public string url { get; set; }
    }
}
