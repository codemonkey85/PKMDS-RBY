using System;
using System.Diagnostics;
using System.Drawing;

namespace PKMDS_RBY_Lib
{
    public static class Images
    {
        public static Image GetImageFromResource(string identifier)
        {
            try
            {
                return (Image)Properties.Resources.ResourceManager.GetObject(identifier);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("There was an issue in GetImageFromResource: {0}", ex.Message);
                return null;
            }
        }
    }
}