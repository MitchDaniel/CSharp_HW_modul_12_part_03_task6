using System.Data;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach(var i in Show(@"C:\Users\Brill\Desktop\Новая папка 1"))
            {
                Console.WriteLine(i);
            }    
        }
        static string[] Show(string path)
        {
            if (path is null) throw new ArgumentNullException();
            if (!Directory.Exists(path)) throw new DirectoryNotFoundException();
            List<string> contents = new List<string>(Directory.GetFiles(path));
            contents.AddRange(Directory.GetDirectories(path));
            foreach (var item in Directory.GetDirectories(path))
            {
                var tempPath = Path.Combine(item);
                contents.AddRange(Show(tempPath));
            }
            return contents.ToArray();
        }
    }
}

//Создайте приложение для отображения файловой структуры по указанному пути. 
//Пользователь вводит путь для отображения. Приложение показывает содержимое по указанному пути. 
//Например, если пользователь вводит D:\TestFolder должно отобразиться содержимое этой папки. 
//Обратите внимание, что нужно показать всё содержимое папки вплоть до подпапок.