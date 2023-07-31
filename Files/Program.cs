DirectoryInfo directoryInfo = new DirectoryInfo(@"D:\Folder");
try
{
    int choice;
    while (true)
    {
        Console.WriteLine("**********************************************");
        Console.WriteLine("*                Главное меню                *");
        Console.WriteLine("**********************************************");
        Console.WriteLine("1 - установить текущий диск/каталог");
        Console.WriteLine("2 - вывод списка всех каталогов в текущем");
        Console.WriteLine("3 - вывод списка всех файлов в текущем каталоге");
        Console.WriteLine("4 - вывод на экран содержимого указанного файла");
        Console.WriteLine("5 - создание каталога в текущем");
        Console.WriteLine("6 - удаление каталога по номеру, если пустой");
        Console.WriteLine("7 - удаление файлов с указанными номерами");
        Console.WriteLine("8 - вывод списка всех файлов с указанной датой создания");
        Console.WriteLine("9 - вывод списка всех текстовых файлов, в которых текст");
        Console.WriteLine("0 - выход");
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Некорректное значение выбора"); continue;
        }
        switch (choice)
        {
            case 1:
                f1(ref directoryInfo);
                break;
            case 2:
                f2(ref directoryInfo);
                break;
            case 3:
                f3(ref directoryInfo);
                break;
            case 4:
                f4(ref directoryInfo);
                break;
            case 5:
                f5(ref directoryInfo);
                break;
            case 6:
                f6(ref directoryInfo);
                break;
            case 7:
                f7(ref directoryInfo);
                break;
            case 8:
                f8(ref directoryInfo);
                break;
            case 9:
                f9(ref directoryInfo);
                break;
            case 0: return;

        }
    }
}
catch (FileNotFoundException e)
{
    Console.WriteLine("Неверное имя файла");
}
catch (DirectoryNotFoundException e)
{
    Console.WriteLine("Неверное имя каталога");
}
catch (Exception e)
{
    Console.WriteLine($"Ошибка - {e.Message}");
}

static void f1(ref DirectoryInfo d)
{//1 - установить текущий диск/каталог.
    Console.WriteLine("Введите имя каталога:");
    string str = Console.ReadLine();
    d = new DirectoryInfo(str);
}
static void f2(ref DirectoryInfo d)
{//2 - вывод списка всех каталогов в текущем.
    DirectoryInfo[] directoryInfos = d.GetDirectories();
    int n = 0;
    foreach (DirectoryInfo directoryInfo in directoryInfos)
    {
        Console.WriteLine($"{++n}) {directoryInfo.Name} {directoryInfo.CreationTime}");

    }
}
static void f3(ref DirectoryInfo d)
{//3 - вывод списка всех файлов в текущем каталоге.
    FileInfo[] fileInfos = d.GetFiles();
    int n = 0;
    foreach (FileInfo fileInfo in fileInfos)
    {
        Console.WriteLine($"{++n}) {fileInfo.Name} {fileInfo.CreationTime}");
    }

}
static void f4(ref DirectoryInfo d)
{//4 - вывод на экран содержимого указанного файла.
    f3(ref d);
    Console.WriteLine("Введите номер файла:");
    int index; int.TryParse(Console.ReadLine(), out index);
    FileInfo[] fileInfos = d.GetFiles();
    if (fileInfos[index - 1].Extension != ".txt")
    {
        Console.WriteLine("Это не текстовый файл!");
        return;
    }
    StreamReader reader = new StreamReader(fileInfos[index - 1].FullName);
    string str = reader.ReadToEnd();
    Console.WriteLine(str);
    reader.Close();
}
static void f5(ref DirectoryInfo d)
{//5 - создание каталога в текущем.
    string path = d.FullName;
    Console.WriteLine("Введите имя создаваемой папки");
    string subpath = @Console.ReadLine();
    DirectoryInfo dirInfo = new DirectoryInfo(path);
    if (!dirInfo.Exists)
    {
        dirInfo.Create();
    }
    dirInfo.CreateSubdirectory(subpath);
}
static void f6(ref DirectoryInfo d)
{//6 - удаление каталога, если он пустой.
    f2(ref d);
    Console.WriteLine("Введите номер удаляемой дирректории");
    int n; int.TryParse(Console.ReadLine(), out n);
    DirectoryInfo[] directoryInfos = d.GetDirectories();
    DirectoryInfo dirInfo = new DirectoryInfo(directoryInfos[n - 1].FullName);
    if (dirInfo.Exists)
    {
        dirInfo.Delete(true);
        Console.WriteLine("Каталог удален");
    }
    else
    {
        Console.WriteLine("Каталог не существует");
    }
}
static void f7(ref DirectoryInfo d)
{//7 - удаление файлов с указанными номерами.
    f3(ref d);
    Console.WriteLine("Введите номера первого и последнего файла для удаления: ");
    int index1; int.TryParse(Console.ReadLine(), out index1);
    int index2; int.TryParse(Console.ReadLine(), out index2);
    FileInfo[] files = d.GetFiles();
    if (index1 < index2)
    {
        for (int n = index1 - 1; n < index2; n++)
        {
            FileInfo fileInf = new FileInfo(files[n].FullName);
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
    else Console.WriteLine("Неверные значения индексов");
}
static void f8(ref DirectoryInfo d)
{//8 - вывод списка всех файлов с указанной датой создания.
    Console.WriteLine("Введите предполагаему дату создания файла");
    DateTime date; DateTime.TryParse(Console.ReadLine(), out date);
    FileInfo[] files = d.GetFiles();
    foreach (var i in files)
    {
        if (Convert.ToString(i.CreationTime).Contains(Convert.ToString(date))) ;
        Console.WriteLine(i);
    }
}
static void f9(ref DirectoryInfo d)
{//9 – выводит все текстовые файлы, в которых содержится указанный текст.
    Console.WriteLine("Введите искомый текст");
    string text = Console.ReadLine();
    FileInfo[] files = d.GetFiles();
    for (int i = 0; i < files.Length; i++)
    {
        using (StreamReader reader = new StreamReader(files[i].FullName))
        {
            string s = reader.ReadToEnd();
            if (s.Contains(text))
                Console.WriteLine($"{files[i].Name} {files[i].CreationTime}");
        }
    }
}
