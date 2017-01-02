using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCopierPlus
{
    [Serializable]
    public class GlobalSettings
    {
        [NonSerialized]
        private ICollection<string> _cameraNames;
        private string _cardDrive;
        private string _cardParentDirectory;
        private string _cardSubDirectoryStructure;
        private string _outputDir;
        private string _fastCopyDirectoryPath;
        private string _imageViewerPlusExecutablePath;

        [NonSerialized]
        public static readonly GlobalSettings Instance = GetSettings();

        private GlobalSettings()
        {
        }

        public ICollection<string> CameraNames
        {
            get
            {
                return _cameraNames;
            }
        }

        private void SaveSettings()
        {
            string settingsFilePath = SettingsFilePath;

            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Directory.GetParent(settingsFilePath).FullName);
                System.IO.FileStream file = System.IO.File.OpenWrite(settingsFilePath);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                soapFormatter.Serialize(file, this);
            }
            catch (Exception)
            {
            }
        }

        //public static string AppDataDir
        //{
        //    get
        //    {
        //        return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Silvanus");
        //    }
        //}

        public string CardDrive
        {
            get
            {
                return _cardDrive;
            }
        }

        public string CardParentDirectory
        {
            get
            {
                return System.IO.Path.Combine(CardDrive, _cardParentDirectory);
            }
        }

        public string CardSourceDirectory
        {
            get
            {
                return System.IO.Path.Combine(CardParentDirectory, _cardSubDirectoryStructure);
            }
        }

        public string OutputDirectory
        {
            get
            {
                return _outputDir;
            }
        }

        public string FastCopyDirectoryPath
        {
            get
            {
                return _fastCopyDirectoryPath;
            }
        }

        public string FastCopyExecutablePath
        {
            get
            {
                return System.IO.Path.Combine(FastCopyDirectoryPath, "FastCopy.exe");
            }
        }

        public string FastCopyLogFilePath
        {
            get
            {
                return System.IO.Path.Combine(ExecutingAssemblyDirectoryPath, "copylog.txt");
            }
        }

        public string ImageViewerPlusExecutablePath
        {
            get
            {
                return _imageViewerPlusExecutablePath;
            }
        }

        private static string ExecutingAssemblyDirectoryPath
        {
            get
            {
                return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); 
            }
        }

        private static string SettingsFilePath
        {
            get
            {
                return System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ImageCopierPlus", "globalSettings.xml");
            }
        }
                
        private static GlobalSettings GetSettings()
        {
            string settingsFilePath = SettingsFilePath;

            if (!System.IO.File.Exists(settingsFilePath))
            {
                var defaultSettings = CreateDefaultSettings();
                defaultSettings.SaveSettings();
                return defaultSettings;
            }

            try
            {
                System.IO.FileStream file = System.IO.File.OpenRead(settingsFilePath);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                GlobalSettings settings = soapFormatter.Deserialize(file) as GlobalSettings;
                AssignCameraNames(settings);
                return settings;
            }
            catch (Exception)
            {
            }

            return CreateDefaultSettings();
        }

        private static GlobalSettings CreateDefaultSettings()
        {
            GlobalSettings settings = new GlobalSettings();
            AssignCameraNames(settings);
                        
            settings._cardDrive = @"K:\";
            settings._cardParentDirectory = @"DCIM";
            settings._cardSubDirectoryStructure = @"100EK113";
            settings._outputDir = @"E:\Trail Cams\2015";
            settings._fastCopyDirectoryPath = @"..\FastCopy";
            settings._imageViewerPlusExecutablePath = @"C:\Users\Tyler\Documents\GitHub\ImageViewerPlus\ImageViewerPlus\bin\Release\ImageViewerPlus.exe";

            return settings;
        }

        private static void AssignCameraNames(GlobalSettings settings)
        {
            settings._cameraNames = new System.Collections.ObjectModel.ObservableCollection<string>();
            settings._cameraNames.Add("Field Feeder");
            settings._cameraNames.Add("Crossroads Feeder");
        }
    }
}
