using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class PokemonType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Strengths { get; set; }

    public string? Weaknesses { get; set; }

    public string? NoEffects { get; set; }

    public virtual ICollection<Move> Moves { get; } = new List<Move>();

    public virtual ICollection<Pokemon> Pokemons { get; } = new List<Pokemon>();
}
