// See https://aka.ms/new-console-template for more information
class Tree {

    static void Main()
    {
        int level = 1;
        string path = @"C:/"; // Beware of your path
        DirectoryInfo directoryInfo = new DirectoryInfo(path);
        listerDossier(directoryInfo, level);
    }

    static void listerDossier(DirectoryInfo directoryInfo, int level)
    {
        foreach (var file in directoryInfo.GetFiles()) {
            if(file.Attributes.HasFlag(FileAttributes.Hidden)) {
                continue;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(string.Concat(Enumerable.Repeat('.',level+1)) + file.Name);
        }

        foreach(var directory in directoryInfo.GetDirectories()) {
            if(directory.Attributes.HasFlag(FileAttributes.Hidden)) {
                continue;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Concat(Enumerable.Repeat('.',level))+directory.Name);
            listerDossier(directory, level+1);
        }
    }
}