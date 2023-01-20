namespace PokeDex.Common.PokeApiModels
{
    public class ApiMove
    {
        // id 
        public int id { get; set; }

        // name
        public string name { get; set; } = null!;

        // type
        public ApiMoveType type { get; set; } = null!;

        // Description
        public List<ApiMoveFlavorTextEntries> flavor_text_entries { get; set; } = null!;

        // Damage
        public int? power { get; set; }

        // PP
        public int pp { get; set; }
    }

    public class ApiMoveType
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiMoveFlavorTextEntries
    {
        public string flavor_text { get; set; } = null!;

        public ApiMoveFlavorTextEntriesLanguage language { get; set; } = null!;

        public ApiMoveFlavorTextEntriesVersionGroup version_group { get; set; } = null!;
    }

    public class ApiMoveFlavorTextEntriesLanguage
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }

    public class ApiMoveFlavorTextEntriesVersionGroup
    {
        public string name { get; set; } = null!;

        public string url { get; set; } = null!;
    }
}
