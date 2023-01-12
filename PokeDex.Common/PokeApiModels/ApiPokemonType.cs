namespace PokeDex.Common.PokeApiModels
{
    public class ApiPokemonType
    {
        // id
        public int id { get; set; }

        // name
        public string name { get; set; }

        // Weakness, Strengths, No Effect
        public ApiTypesDamageRelations damage_relations { get; set; }

        // Moves
        public List<ApiMove> moves { get; set; }

        // Pokemons
        public List<ApiPokemon> pokemon { get; set; }
    }

    public class ApiTypesDamageRelations
    {
        public List<ApiTypesDamageRelationsDoubleDamageFrom> double_damage_from { get; set; }

        public List<ApiTypesDamageRelationsDoubleDamageTo> double_damage_to { get; set; }

        public List<ApiTypesDamageRelationsHalfDamageFrom> half_damage_from { get; set; }

        public List<ApiTypesDamageRelationsHalfDamageTo> half_damage_to { get; set; }

        public List<ApiTypesDamageRelationsNoDamageFrom> no_damage_from { get; set; }

        public List<ApiTypesDamageRelationsNoDamageTo> no_damage_to { get; set; }
    }

    public class ApiTypesDamageRelationsDoubleDamageFrom
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiTypesDamageRelationsDoubleDamageTo
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiTypesDamageRelationsHalfDamageFrom
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiTypesDamageRelationsHalfDamageTo
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiTypesDamageRelationsNoDamageFrom
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiTypesDamageRelationsNoDamageTo
    {
        public string name { get; set; }

        public string url { get; set; }
    }
}
