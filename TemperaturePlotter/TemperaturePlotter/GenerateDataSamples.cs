using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TemperaturePlotter.Data;


namespace TemperaturePlotter
{
    class GenerateDataSamples
    {
    #region Data Members
        static Data.DataSampler Instance = null;
        static Data.ResultStorage ResultInstance = new Data.ResultStorage();
        static List<DataSample> Samples = new List<DataSample>();
        static List<DataSample> RunningSample = new List<DataSample>();
        static double AvegrageTemperature = 0;
        static double RSDValue = 0;
        #endregion

        #region private functions
        /// <summary>
        /// Updates all the running data
        ///Calculates Avergae temperature and RSD for 10 secs 
        /// </summary>
        /// <param name="sample"></param>
        private static void UpdateRunningData(DataSample sample)
        {
            RunningSample.Add(sample);
            if (RunningSample.Count > 1)
                while ((RunningSample[RunningSample.Count - 1].Time - RunningSample[0].Time) > 10)
                {
                    RunningSample.RemoveAt(0);
                }
            AvegrageTemperature = Math.Round(RunningSample.Average(x => x.Temperature),6);

            CalculateRSD();
        }

        /// <summary>
        /// Apply Filter on selected Samples. 
        /// It uses Moving Average Filter. 
        /// </summary>
        /// <param name="samples"></param>
        /// <returns></returns>
        private static DataSample ApplyFilter(List<DataSample> samples)
        {
            double result = samples.Average(x => x.Temperature);
            samples.Last().Temperature = result;

            return samples.Last();
        }

        #endregion

        #region public functions

        /// <summary>
        /// Checks for file and open the file for sampling.
        /// throws exception to its caller when file not found or cannot open.
        /// </summary>
        /// <param name="FilePath"></param>
        public static void CheckAndOpenSampler(string FilePath)
        {
             try
             {
                    Instance = new Data.DataSampler(FilePath);
                    Instance.OpenFile();
             }catch(Exception )
             {
                    throw ;//throw to the view model
             }
        }

        /// <summary>
        /// Clear all data while closing application or test stopped. 
        /// </summary>
        public static void CloseSampler()
        {
            Samples.Clear();
            RunningSample.Clear();
           if(Instance!=null)
            Instance.CloseFile();
            if (ResultInstance != null)
                ResultInstance.EndResultStorage();
        }

        /// <summary>
        /// Reuest the Data sampler to get the next data from file
        /// It may use filter to avoid noice(Based on User selection)
        /// Stores calculated data to xml
        /// </summary>
        /// <param name="useFilter"></param>
        /// <param name="noOfSamples"></param>
        /// <returns></returns>
        public static Data.DataSample GetNextSample(bool useFilter=true,int noOfSamples=6)
        {
            DataSample sample = Instance.GetNextSample();
            double actTemp = sample.Temperature;
            Samples.Add(sample);
            if (useFilter)
            {
                if (Samples.Count > noOfSamples)
                {
                    List<DataSample> tempSamples = Samples.GetRange(Samples.Count - noOfSamples, noOfSamples);
                    sample = ApplyFilter(tempSamples);
                }
                else
                    sample = ApplyFilter(Samples);
            }

            UpdateRunningData(sample);

            ResultInstance.StoreToXml(new Result(sample.Time, actTemp, sample.Temperature, AvegrageTemperature, RSDValue));
            return sample;
        }
        /// <summary>
        /// Gets Average Temperature
        /// </summary>
        /// <returns></returns>
        public static double GetAverageTemperature()
        {
            return AvegrageTemperature;
        }

        /// <summary>
        /// Gets Relative Standard Deviation calculated from samples. 
        /// </summary>
        /// <returns></returns>
        public static double GetRSDData()
        {
            return RSDValue;
        }

        /// <summary>
        /// Calculates Relative Standard Deviation calculated from samples. 
        /// </summary>
        public static void CalculateRSD()
        {
            if (RunningSample.Count < 4)
                return;
            double avg = RunningSample.Average(x=>x.Temperature);
            var standardDeviation= Math.Sqrt(RunningSample.Sum(v => Math.Pow(v.Temperature - avg, 2))/(RunningSample.Count-1));
            RSDValue = Math.Round(((standardDeviation * 100) / avg),6);
        }

        #endregion
            
    }
}
