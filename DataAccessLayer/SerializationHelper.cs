using GalleryBL;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccessLayer
{
    public static class SerializationHelper
    {
        private static string targetFile = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)+ "/data.bin";
        public static bool Serialize(AlbumManager albumManager)
        {
            FileStream fileStream=null;
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                fileStream = new FileStream(targetFile, FileMode.Create);
                binaryFormatter.Serialize(fileStream, albumManager);
                ;
            }
            catch
            {
                return false;
            }
            finally
            {
                fileStream.Close();

            }
            return true;
        }

        public static AlbumManager Deserialize(out string errorMessage)
        {
            FileStream fileStream = null;
            errorMessage = null;
            AlbumManager albumManager = new AlbumManager();
            try
            {
                if(File.Exists(targetFile))
                {
                    fileStream = new FileStream(targetFile, FileMode.Open);
                    BinaryFormatter b = new BinaryFormatter();
                    if(new FileInfo(targetFile).Length>0)
                    {                        
                        albumManager = (AlbumManager)b.Deserialize(fileStream);
                    }                    
                }
            }
            catch(SerializationException e)
            {
                errorMessage="Deserialization failed " + e.Message;
                
            }
            finally
            {
                if(fileStream!=null)
                {
                    fileStream.Close();
                }
            }
            return albumManager;
        }
    }
}
