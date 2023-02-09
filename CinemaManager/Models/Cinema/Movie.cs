using System;
using System.Collections.Generic;

namespace CinemaManager.Models.Cinema;

public partial class Movie
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int ProducerId { get; set; }

    public virtual Producer Producer { get; set; } = null!;
}
