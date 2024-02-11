using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NorthwindModel;

[Keyless]
public partial class Territory
{
    [Column(TypeName = "nvarchar] (20")]
    public required string TerritoryId { get; set; }

    [Column(TypeName = "nchar] (50")]
    public required string TerritoryDescription { get; set; }

    [Column(TypeName = "INT")]
    public int RegionId { get; set; }
}
