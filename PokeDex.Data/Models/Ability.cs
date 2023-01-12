using System;
using System.Collections.Generic;

namespace PokeDex.Data.Models;

public partial class Ability
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Pokemon> Pokemons { get; } = new List<Pokemon>();
}
