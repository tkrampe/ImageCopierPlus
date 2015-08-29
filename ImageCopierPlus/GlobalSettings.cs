﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCopierPlus
{
    [Serializable]
    public class GlobalSettings
    {
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
                return System.IO.Path.Combine(ExecutingAssemblyDirectoryPath, "globalSettings.xml");
            }
        }
                
        private static GlobalSettings GetSettings()
        {
            string settingsFilePath = SettingsFilePath;

            if (!System.IO.File.Exists(settingsFilePath))
                return CreateDefaultSettings();

            try
            {
                System.IO.FileStream file = System.IO.File.OpenRead(settingsFilePath);
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter soapFormatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                return soapFormatter.Deserialize(file) as GlobalSettings;
            }
            catch (Exception)
            {
            }

            return CreateDefaultSettings();
        }

        private static GlobalSettings CreateDefaultSettings()
        {
            GlobalSettings settings = new GlobalSettings();
            settings._cameraNames = new System.Collections.ObjectModel.ObservableCollection<string>();
            settings._cameraNames.Add("Lower Plot");
            settings._cameraNames.Add("Lower Plot Wick");
            settings._cameraNames.Add("Pinch Point");
            settings._cameraNames.Add("Road Feeder");
            settings._cameraNames.Add("Road Mineral Lick");
            settings._cameraNames.Add("Sanctuary Feeder");
            settings._cameraNames.Add("Sanctuary Mineral Lick");
            settings._cameraNames.Add("Valley Plot Feeder");
            
            settings._cardDrive = @"G:\";
            settings._cardParentDirectory = @"DCIM";
            settings._cardSubDirectoryStructure = @"100EK113";
            settings._outputDir = @"E:\Trail Cams\2014";
            settings._fastCopyDirectoryPath = @"..\FastCopy";
            settings._imageViewerPlusExecutablePath = @"D:\Google Drive\ImageViewerPlus\ImageViewerPlus\bin\Release\ImageViewerPlus.exe";

            return settings;
        }
    }
}