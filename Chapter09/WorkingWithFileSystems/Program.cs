using Spectre.Console; // To use Table.
#region Handling cross-platform environments and filesystems
SectionTitle("Handling cross-platform environments and filesystems");
// Create a Spectre Console table.
Table table = new();
// Add two columns with markup for colors.
table.AddColumn("[blue]MEMBER[/]");
table.AddColumn("[blue]VALUE[/]");
// Add rows.
table.AddRow("Path.PathSeparator", PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar",
 DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()",
 GetCurrentDirectory());
table.AddRow("Environment.CurrentDirectory", CurrentDirectory);
table.AddRow("Environment.SystemDirectory", SystemDirectory);
table.AddRow("Path.GetTempPath()", GetTempPath());
table.AddRow("");
table.AddRow("GetFolderPath(SpecialFolder", "");
table.AddRow(" .System)", GetFolderPath(SpecialFolder.System));
table.AddRow(" .ApplicationData)",
 GetFolderPath(SpecialFolder.ApplicationData));
table.AddRow(" .MyDocuments)",
 GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow(" .Personal)",
 GetFolderPath(SpecialFolder.Personal));
// Render the table to the console
AnsiConsole.Write(table);
#endregion

#region
SectionTitle("Managing drives");
Table drives = new();
drives.AddColumn("[blue]NAME[/]");
drives.AddColumn("[blue]TYPE[/]");
drives.AddColumn("[blue]FORMAT[/]");
drives.AddColumn(new TableColumn(
 "[blue]SIZE (BYTES)[/]").RightAligned());
drives.AddColumn(new TableColumn(
 "[blue]FREE SPACE[/]").RightAligned());
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    if (drive.IsReady)
    {
        drives.AddRow(drive.Name, drive.DriveType.ToString(),
        drive.DriveFormat, drive.TotalSize.ToString("N0"),
        drive.AvailableFreeSpace.ToString("N0"));
    }
    else
    {
        drives.AddRow(drive.Name, drive.DriveType.ToString(),
        string.Empty, string.Empty, string.Empty);
    }
}
AnsiConsole.Write(drives);
#endregion