using System.Text;

namespace Real_time_weather.Repositories;

public static class FileSystemRepository
{
    public static string GetPath()
    {
        return Path.GetFullPath(@"..\..\..\");
    }

    public static bool CheckIfFileEmpty(string fileName)
    {
        string path = Path.Combine(GetPath(), "storage");
        path = Path.Combine(path, fileName);
        FileInfo fi = new FileInfo(path);

        return fi.Length == 0;
    }

    public static void WriteToFile(string fileName, string data)
    {
        string path = Path.Combine(GetPath(), "storage");
        path = Path.Combine(path, fileName);
        using (StreamWriter sw = File.AppendText(path))
            sw.WriteLine(data);
    }

    public static string ReadFromFile(string fileName)
    {
        StringBuilder data = new();

        string path = GetPath();
        path = Path.Combine(path, fileName);

        using (StreamReader sr = File.OpenText(path))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                data.Append(s);
            }
        }
        return data.ToString();
    }
}
