using System;

using Foundation;
using Newtonsoft.Json;
using UIKit;

namespace XamarinExperiment.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            var local1 = DateTime.Now.ToLocalTime();

            var data = new Data();
            data.Kind = local1.Kind.ToString();
            data.DateTime = local1;

            string json = JsonConvert.SerializeObject(data);
            System.Diagnostics.Debug.WriteLine(json);

            var data2 = JsonConvert.DeserializeObject<Data>(json);
            var local2 = data2.DateTime.ToLocalTime();

            System.Diagnostics.Debug.WriteLine($"Original {local1.Kind} {local1}");
            System.Diagnostics.Debug.WriteLine($"Deserialized {local2.Kind} {local2}");

            return base.FinishedLaunching(app, options);
        }
    }

    public class Data
    {
        public string Kind;
        public DateTime DateTime;

        public Data()
        {
        }
    }
}
