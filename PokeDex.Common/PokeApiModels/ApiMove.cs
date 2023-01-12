namespace PokeDex.Common.PokeApiModels
{
    public class ApiMove
    {
        // id 
        public int id { get; set; }

        // name
        public string name { get; set; }

        // type
        public ApiMoveType type { get; set; }

        // Description
        public List<ApiMoveFlavorTextEntries> flavor_text_entries { get; set; }

        // Damage
        public int power { get; set; }

        // PP
        public int pp { get; set; }
    }

    public class ApiMoveType
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiMoveFlavorTextEntries
    {
        public string flavor_text { get; set; }

        public ApiMoveFlavorTextEntriesLanguage language { get; set; }

        public ApiMoveFlavorTextEntriesVersionGroup version_group { get; set; }
    }

    public class ApiMoveFlavorTextEntriesLanguage
    {
        public string name { get; set; }

        public string url { get; set; }
    }

    public class ApiMoveFlavorTextEntriesVersionGroup
    {
        public string name { get; set; }

        public string url { get; set; }
    }
}
