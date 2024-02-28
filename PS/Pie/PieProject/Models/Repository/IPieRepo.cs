namespace PieProject.Models.Repository;

public interface IPieRepo
{
    IEnumerable<Pie> AllPies { get; }
    IEnumerable<Pie> PiesOfTheWeek { get; }
    Pie? GetPieById(int pieId);

}
