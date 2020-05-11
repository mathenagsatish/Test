using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
/// <summary>
/// Data Sampler class which actually reads the file and returns the data sample class.
/// </summary>
namespace TemperaturePlotter.Data
{
    class DataSampler:IDisposable
    {
        private string FilePath { get; set; }
        private System.IO.StreamReader FileHandle;

        public DataSampler(string filePath)
        {
            FilePath = filePath;
        }
        /// <summary>
        /// opens a file
        /// throws an exception when file not found and need to handle by caller.
        /// </summary>
        public void OpenFile()
        {
            FileHandle =   new System.IO.StreamReader(FilePath);
        }

        public DataSample GetNextSample()
        {
            List<string> data = FileHandle.ReadLine().Split(',').ToList();
            List<double> doubleList= data.ConvertAll(x => double.Parse(x));
            
            DataSample datasample=new DataSample(doubleList[0], doubleList[1]);
            return datasample;
        }
        /// <summary>
        /// Close file
        /// </summary>
        public void CloseFile()
        {
        if(FileHandle!=null)
            FileHandle.Close();
        }

        public void Dispose()
        {
            if (FileHandle != null)
                FileHandle.Close();
        }
    }
}
