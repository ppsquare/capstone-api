using CapstoneApi.Models;

namespace CapstoneApi.Services
{
    public class FileService
    {
        static List<MyFile> MyFiles { get; }

        static FileService()
        {
            MyFiles = new List<MyFile>
            {
                new MyFile {Name = "Sample.txt", Path = "\\demofileshare\\demo\\" },
                new MyFile {Name = "Address.txt", Path = "\\demofileshare\\demo\\" }
            };
        }

        public static List<MyFile> GetAll() => MyFiles;

        public static void Add(MyFile myFile)
        {
            MyFiles.Add(myFile);
        }

        public static MyFile? Get(string name, string path) => MyFiles.FirstOrDefault(m => m.Name == name);

        /*        public static void Update(MyFile myFile)
                {
                    var index = MyFiles.FindIndex(m => m.Name == myFile.Name);
                    if (index == -1)
                        return;

                    MyFiles[index] = myFile;
                }*/
        public static void Delete(string name, string path)
        {
            var MyFile = Get(name, path);
            if (MyFile is null)
                return;

            MyFiles.Remove(MyFile);
        }

    }
}