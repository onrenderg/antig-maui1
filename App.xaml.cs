using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseTemp
{
    public partial class App : Application
    {
        public const string DB_Name = "ResilientConstruction.db";
        
        // Static Containers
        public static Models.LanguageMasterDatabase languageMasterDatabase;
        public static List<Models.LanguageMaster> languageMasterslist;
        public static Models.AppConfigDatabase appConfigDatabase;

        public App()
        {
            InitializeComponent();

            // Initialize Databases
            languageMasterDatabase = new Models.LanguageMasterDatabase();
            appConfigDatabase = new Models.AppConfigDatabase();

            // Load Language Data
            languageMasterslist = languageMasterDatabase.GetItems();

            // Seed Language Data (Pattern B)
            insertlanguageleys1();

            // Sync AppConfig from API (Fire and Forget)
            Task.Run(async () => await appConfigDatabase.SyncWithApi());
        }

        public static string LableText(string key)
        {
            if (languageMasterslist == null || !languageMasterslist.Any()) return key;
            var item = languageMasterslist.FirstOrDefault(x => x.Key == key);
            return item != null ? item.English : key;
        }

        public static void insertlanguageleys1()
        {
            // Pattern B: Wipe and Reload
            languageMasterDatabase.DeleteLanguageMaster();
            
            languageMasterDatabase.ExecuteNonQuery("INSERT INTO LanguageMaster (Key, English, Hindi, Gujarati, Marathi) VALUES ('welcome_message', 'Welcome', 'Namaste', 'Aavo', 'Namaskar')");
            languageMasterDatabase.ExecuteNonQuery("INSERT INTO LanguageMaster (Key, English, Hindi, Gujarati, Marathi) VALUES ('submit_button', 'Submit', 'Jama Karo', 'Jama Karo', 'Sadar Kara')");
            
            // Refresh List
            languageMasterslist = languageMasterDatabase.GetItems();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = Colors.White;
            nav.BarTextColor = Colors.Black;
            return new Window(nav);
        }
    }
}