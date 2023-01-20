namespace PokeDex.Common.PokeApiModels
{
    public class ApiPokemonType
    {
        // id
        public int id { get; set; }

        // name
        public string name { get; set; } = null!;

        // Weakness, Strengths, No Effect
        public ApiTypesDamageRelations damage_relations { get; set; } = null!;

        // Moves
        public List<ApiMove> moves { get; set; } = null!;

        // Pokemons
        public List<ApiPokemon> pokemon { get; set; } = null!;
    }

    public class ApiTypesDamageRelations
    {
        public List<ApiTypesDamageRelationsDoubleDamageFrom> double_damage_from { get; set; } = null!;

        public List<ApiTypesDamageRelationsDoubleDamageTo> double_damage_to { get; set; } = null!;

        public List<ApiTypesDamageRelationsHalfDamageFrom> half_damage_from { get; set; } = null!;

        public List<ApiTypesDamageRelationsHalfDamageTo> half_damage_to { get; set; } = null!;

        public List<ApiTypesDamageRelationsNoDamageFrom> no_damage_from { get; set; } = null!;

        public List<ApiTypesDamageRelationsNoDamageTo> no_damage_to { get; set; } = null!; 
    }

    public class ApiTypesDamageRelationsDoubleDamageFrom
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiTypesDamageRelationsDoubleDamageTo
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiTypesDamageRelationsHalfDamageFrom
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiTypesDamageRelationsHalfDamageTo
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiTypesDamageRelationsNoDamageFrom
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiTypesDamageRelationsNoDamageTo
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }
}
