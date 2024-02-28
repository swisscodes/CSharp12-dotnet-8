using BethanysPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShop.App.Pages
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
