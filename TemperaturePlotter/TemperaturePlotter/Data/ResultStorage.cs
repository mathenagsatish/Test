using System;
using System.IO;

/// <summary>
/// Class responsible for sotring all data/
/// </summary>
namespace TemperaturePlotter.Data
{
    class ResultStorage:IDisposable
    {
        public string resultStorageFile = @"Result.xml";
        StreamWriter writer;

        public ResultStorage()
        {
            writer = new StreamWriter(resultStorageFile,false);
            writer.WriteLine( "<Result>");
            writer.Flush();
        }
          
        public void StoreToXml(Result obj)
        {
            if (writer == null || writer.BaseStream==null)
            {
                writer = new StreamWriter(resultStorageFile, false);
                writer.WriteLine("<Result>");
                writer.Flush();
            }
            writer.WriteLine(obj.ToString());
            writer.Flush();
        }

        public void EndResultStorage()
        {
            writer.WriteLine( "</Result>");
            writer.Flush();
            if (writer != null)
                writer.Close();
        }

        public void Dispose()
        {
            if (writer != null)
                writer.Close();//internally calls dispose
        }
    }
}
