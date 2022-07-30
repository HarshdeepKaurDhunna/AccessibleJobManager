using Firebase.Storage;
using JobManager.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace JobManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : TabbedPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
        public String downloadlinkVal;
        public String downloadlinkFileVal;
        public ImageSource Source { get; set; }
        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null) return;
           

            var task = new FirebaseStorage("andriod--auth.appspot.com",
                new FirebaseStorageOptions {
                      ThrowOnCancel =  true
                })
                .Child("image")
                .Child(photo.FileName).PutAsync(await photo.OpenReadAsync());
            task.Progress.ProgressChanged += (s, args) =>
            {
                progressBar.Progress = args.Percentage;
            };


           {

            };
            downloadlinkVal = await task;
           
        }

        public void button_download_image_Clicked(object sender, EventArgs e)
        {
            backgroundImage.Source = downloadlinkVal;
            backgroundImage.Source = new UriImageSource
            {
                Uri = new Uri(downloadlinkVal),
                CachingEnabled = true,
                CacheValidity = new TimeSpan(5, 0, 0, 0)
            };
        }

        async public void saveTextFile(object sender, EventArgs e)
        {
            var message = TextMessage.Text;
            var service = DependencyService.Get<IFileService>();
            service.createFile(message);
            var file = await Xamarin.Essentials.FilePicker.PickAsync();

            if (file == null) return;


            var task = new FirebaseStorage("andriod--auth.appspot.com");
            
        }


    }
}