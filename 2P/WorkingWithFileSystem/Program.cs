using static System.IO.Directory; // CRUD Directories Folders
using static System.IO.Path; // Create URL's C://PiteroUser/Documents/
using static System.Environment; // Get the location , SpecialFolder, CurrentFolder...
// File , write or read from files, StreamWriter, StreamReader

#region Getting Directories Info
WriteLine("Handling cross platform environments");
WriteLine($"{"Path.PathSeparator",-33} {PathSeparator}");
WriteLine($"{"Path.DirectorySeparatorChar",-33} {DirectorySeparatorChar}");
WriteLine($"{"Directory.GetCurrentDirectory()",-33} {GetCurrentDirectory()}");
WriteLine($"{"Environment.SystemDirectory",-33} {SystemDirectory}");
WriteLine($"{"Path.GetTempPath()",-33} {GetTempPath()}");
WriteLine($"{"GetFolderPath(SpecialFolder)",-33} {GetFolderPath(SpecialFolder.System)}");
WriteLine($"{"GetFolderPath(SpecialFolder.ApplicationData)",-33} {GetFolderPath(SpecialFolder.ApplicationData)}");
WriteLine($"{"GetFolderPath(SpecialFolder.Mydocuments)",-33} {GetFolderPath(SpecialFolder.MyDocuments)}");    
#endregion

#region Manage Drives
    SectionTitle("Managing Drives");
    WriteLine($"{"NAME",-30} {"TYPE",-10} {"FORMAT",-7} {"SIZE (BYTES)",18} {"FREE SPACE",18}");
    foreach(DriveInfo drive in DriveInfo.GetDrives())
    {
        WriteLine($"{drive.Name,-30} {drive.GetType(),-10} {drive.DriveFormat,-7} {drive.TotalSize,18} {drive.TotalFreeSpace,18}");
    }
#endregion

#region Manage Directories
    SectionTitle("Managing Directories");
    string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "NewFolder");
    WriteLine($"Working with {newFolder}");
    // check if exists
    WriteLine($"Does it exists? : {Path.Exists(newFolder)}");
    WriteLine("Creating it ...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exists? : {Path.Exists(newFolder)}");
    ReadLine();
    WriteLine("assasinate the directory");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exists? : {Path.Exists(newFolder)}");
#endregion

#region Manage Files
    SectionTitle("Managing Files");
    // define a directory
    string dir = Combine(GetFolderPath(SpecialFolder.MyDocuments), "OutputFiles");
    CreateDirectory(dir);
    // define file paths
    string textFile = Combine(dir, "Dummy.txt");
    string backUpFile = Combine(dir, "dummy.bak");
    WriteLine($"Wroking with {textFile}");
    // check if exist
    WriteLine($"Does it exists? : {Path.Exists(textFile)}");
    // Create the File
    StreamWriter textWriter = File.CreateText(textFile);
    // Write onto the file
    textWriter.WriteLine("Hello my brudaaaaaaa");
    textWriter.Close();
    File.Copy(sourceFileName: textFile, destFileName: backUpFile);
    File.Delete(textFile);
    WriteLine($"Does it exists? : {Path.Exists(textFile)}");
    // READ form file
    WriteLine("Reading from file");
    StreamReader textReader = File.OpenText(backUpFile);
    WriteLine(textReader.ReadToEnd());
    textReader.Close();
#endregion