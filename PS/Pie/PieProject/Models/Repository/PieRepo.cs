using Microsoft.EntityFrameworkCore;

namespace PieProject.Models.Repository;

public class PieRepo(PieProjectDbContext context) : IPieRepo
{
    public IEnumerable<Pie> AllPies => context.Pies.Include(c => c.Category);
    public IEnumerable<Pie> PiesOfTheWeek => context.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);

    public Pie? GetPieById(int pieId)
    {
        return context.Pies.FirstOrDefault(p => p.PieId == pieId);
    }
}
