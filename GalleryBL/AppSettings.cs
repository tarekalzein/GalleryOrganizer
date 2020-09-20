using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace GalleryBL
{

    public class AppSettings
    {
        private List<string> extensions;
        private Dictionary<string, bool> ApplicationFileExtensions;

        /// <summary>
        /// Constructor that enables all file extensions by default.
        /// </summary>
        public AppSettings()
        {
            ApplicationFileExtensions = new Dictionary<string, bool>
            {
                {ExtensionEnums.JPG , true},
                {ExtensionEnums.PNG , true },
                {ExtensionEnums.WMV , true},
                {ExtensionEnums.MP4 , true}
            };
        }

        public List<string> GetEnabledExtensions() 
        {
            extensions = new List<string>();
            foreach (var item in ApplicationFileExtensions)
            {
                if (item.Value)
                {
                    extensions.Add(item.Key);
                }
            }    
            return extensions;
        }

        public void ChangeFileExtensionStatus(string fileExtension, bool boo)
        {
            if (ApplicationFileExtensions.ContainsKey(fileExtension))
                ApplicationFileExtensions[fileExtension] = boo;
            else
                Console.WriteLine("Someone is messing with my application");
        }

        public bool GetFileExtensionStatus(string fileExtension)
        {
            bool value;
            ApplicationFileExtensions.TryGetValue(fileExtension, out value);
                return value;
        }
    }

    /// <summary>
    /// Enum-like class of static names of file extensions supported in this application.
    /// </summary>
    public static class ExtensionEnums
    {
        public const string JPG = "*.jpg";
        public const string PNG = "*.png";
        public const string WMV = "*.wmv";
        public const string MP4 = "*.mp4";

        public static List<string> AppFileExtensionsList()
        {
            List<string> appFileExtensionsList = new List<string> { JPG, PNG, WMV, MP4 };
            return appFileExtensionsList;
        }

    }
}