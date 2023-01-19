using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Move
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TypeId { get; set; }

    public string? Description { get; set; }

    public int? Damage { get; set; }

    public int Pp { get; set; }

    public bool? InflictsStatus { get; set; }

    public int? ApiMoveId { get; set; }

    public virtual ICollection<PokemonMove> PokemonMoves { get; } = new List<PokemonMove>();

    public virtual PokemonType Type { get; set; } = null!;
}
