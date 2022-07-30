using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using JobManager.Droid.Services;
using JobManager.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileService))]
namespace JobManager.Droid.Services
{
    
    public class FileService : IFileService
    {
        public void createFile(string textMessage)
        {
            var destination = Path.Combine(getRootPath(), "TextFile.txt");
            File.WriteAllText(destination, textMessage);
        }

        public string getRootPath()
        {
            return Android.App.Application.Context.GetExternalFilesDir(null).ToString();
        }
    }
}