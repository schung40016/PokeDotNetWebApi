using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Pokemon
{
    public int DexNumber { get; set; }

    public string Name { get; set; } = null!;

    public int PokemonTypeId { get; set; }

    public string? Description { get; set; }

    public int AbilityId { get; set; }

    public int Id { get; set; }

    public virtual Ability Ability { get; set; } = null!;

    public virtual ICollection<PokemonMove> PokemonMoves { get; } = new List<PokemonMove>();

    public virtual PokemonType PokemonType { get; set; } = null!;
}
