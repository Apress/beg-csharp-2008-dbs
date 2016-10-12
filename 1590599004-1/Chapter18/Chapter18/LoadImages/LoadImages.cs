using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LoadImages
{
    class LoadImages
    {
        string imageFileLocation =
        @"C:\Documents and Settings\Administrator\My Documents\";
        string imageFilePrefix = "painting-almirah";
        int numberImageFiles = 1;
        string imageFileType = ".jpg";
        int maxImageSize = 10000;
        SqlConnection conn = null;
        SqlCommand cmd = null;

        static void Main()
        {
            LoadImages loader = new LoadImages();

            try
            {
                // Open connection
                loader.OpenConnection();
                // Create command
                loader.CreateCommand();
                // Create table
                loader.CreateImageTable();
                // Prepare insert
                loader.PrepareInsertImages();
                // Insert images
                int i;
                for (i = 1; i <= loader.numberImageFiles; i++)
                {
                    loader.ExecuteInsertImages(i);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                loader.CloseConnection();
            }
        }

        void OpenConnection()
        {
            // Create connection
            conn = new SqlConnection(@"
            server = .\sqlexpress;
            integrated security = true;
            database = tempdb
         ");
            // Open connection
            conn.Open();
        }

        void CloseConnection()
        {
            // close connection
            conn.Close();
            Console.WriteLine("Connection Closed.");
        }

        void CreateCommand()
        {
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        void ExecuteCommand(string cmdText)
        {
            int cmdResult;
            cmd.CommandText = cmdText;
            Console.WriteLine("Executing command:");
            Console.WriteLine(cmd.CommandText);
            cmdResult = cmd.ExecuteNonQuery();
        }

        void CreateImageTable()
        {
            ExecuteCommand(@"
            create table imagetable
            (
               imagefile nvarchar(20),
               imagedata varbinary(max)
            )
         ");
        }

        void PrepareInsertImages()
        {
            cmd.CommandText = @"
            insert into imagetable
            values (@imagefile, @imagedata)
         ";
            cmd.Parameters.Add("@imagefile", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@imagedata", SqlDbType.Image, 1000000);

            cmd.Prepare();
        }

        void ExecuteInsertImages(int imageFileNumber)
        {
            string imageFileName = null;
            byte[] imageImageData = null;

            imageFileName =
               imageFilePrefix + imageFileNumber.ToString() + imageFileType;
            imageImageData =
                LoadImageFile(imageFileName, imageFileLocation, maxImageSize);

            cmd.Parameters["@imagefile"].Value = imageFileName;
            cmd.Parameters["@imagedata"].Value = imageImageData;

            ExecuteCommand(cmd.CommandText);
        }

        byte[] LoadImageFile(
           string fileName,
           string fileLocation,
           int maxImageSize
        )
        {
            byte[] imagebytes = null;
            string fullpath = fileLocation + fileName;
            Console.WriteLine("Loading File:");
            Console.WriteLine(fullpath);
            FileStream fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagebytes = br.ReadBytes(maxImageSize);

            Console.WriteLine(
               "Imagebytes has length {0} bytes.",
               imagebytes.GetLength(0)
            );

            return imagebytes;
        }
    }
}

