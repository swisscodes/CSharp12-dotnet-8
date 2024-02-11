using static System.Environment;


namespace NorthwindModel;
public class NorthwindContextLogger
{
    public static void WriteLine(string message)
    {
        string path = Path.Combine(GetFolderPath(
        SpecialFolder.DesktopDirectory), "northwindlog.txt");
        StreamWriter textFile = File.AppendText(path);
        textFile.WriteLine(message);
        textFile.Close();
    }
}