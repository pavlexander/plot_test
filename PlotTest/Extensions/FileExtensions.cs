using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlotTest.Extensions
{
    public static class FileExtensions
    {
        public static void SerializeJSONAndSaveToFile<T>(this T data, string fileFullPath)
        {
            string serializedString = JsonSerializer.Serialize(data, new
            JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            File.WriteAllText(fileFullPath, serializedString);
        }

        public static T DeserializeJSON<T>(string fileFullPath)
        {
            var fileContents = File.ReadAllText(fileFullPath);
            T result = JsonSerializer.Deserialize<T>(fileContents, new
            JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return result;
        }

        public static void CompressFile(string fileFullPath)
        {
            FileInfo fileToCompress = new FileInfo(fileFullPath);
            using (MemoryStream compressedMemStream = new MemoryStream())
            {
                using (FileStream originalFileStream = fileToCompress.OpenRead())
                {
                    using (GZipStream compressionStream = new GZipStream(
                        compressedMemStream,
                        CompressionMode.Compress,
                        leaveOpen: true))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }

                }

                compressedMemStream.Seek(0, SeekOrigin.Begin);

                FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz");
                compressedMemStream.WriteTo(compressedFileStream);

                compressedFileStream.Close();
            }
        }

        public static void DecompressFile(string compressedFileName, string decompressedFileName)
        {
            using (Stream fd = File.Create(decompressedFileName))
            using (Stream fs = File.OpenRead(compressedFileName))
            using (Stream csStream = new GZipStream(fs, CompressionMode.Decompress))
            {
                byte[] buffer = new byte[1024];
                int nRead;
                while ((nRead = csStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fd.Write(buffer, 0, nRead);
                }
            }

            /*
            FileInfo fileToDecompress = new FileInfo(compressedFileName);
            using (MemoryStream decompressedMemStream = new MemoryStream())
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                using (GZipStream compressionStream = new GZipStream(
                    decompressedMemStream,
                    CompressionMode.Decompress,
                    leaveOpen: true))
                {
                    originalFileStream.CopyTo(compressionStream);
                }

                decompressedMemStream.Seek(0, SeekOrigin.Begin);

                FileStream decompressedFileStream = File.Create(decompressedFileName);
                decompressedMemStream.WriteTo(decompressedFileStream);

                decompressedFileStream.Close();
            }*/
        }
    }
}
