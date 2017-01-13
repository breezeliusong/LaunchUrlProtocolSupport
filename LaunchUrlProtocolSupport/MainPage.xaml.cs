using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.MediaProperties;
using Windows.Media.Transcoding;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaunchUrlProtocolSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.FileTypeFilter.Add(".m4a");
            openPicker.FileTypeFilter.Add(".mp3");
            var source = await openPicker.PickSingleFileAsync();

            FileSavePicker savePicker = new FileSavePicker();
            savePicker.FileTypeChoices.Add("AAC File", new string[] { ".m4a" });
            var destination = await savePicker.PickSaveFileAsync();

            var profile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.High);

            var transcoder = new MediaTranscoder();
            var prepareResult = await transcoder.PrepareFileTranscodeAsync(source, destination, profile);
            Debug.WriteLine(prepareResult.CanTranscode);
            //await prepareResult.TranscodeAsync();
        }
    }
}
