using System;
/// <summary>
/// Class represents all the input data and calculated data. 
/// </summary>
namespace TemperaturePlotter.Data
{
    [Serializable]
    public class Result
    {
        public double Time;
        public double ActualTemperature;
        public double FilteredTemperature;
        public double AverageTemperature;
        public double RSD;

        public Result()
        {

        }

        public Result(double time,double actTemp,double filteredTemp,double avgTemp,double rsd)
        {
            Time = time;
            ActualTemperature = actTemp;
            FilteredTemperature = filteredTemp;
            AverageTemperature = avgTemp;
            RSD = rsd;
        }

       public override string ToString()
        {
            string str ="<Result Time = \" "+Time+"\" ";
            str += "OrigTemp = \" " + ActualTemperature + "\" ";
            str += "FiltTemp = \" " + FilteredTemperature + "\" ";
            str += "AvgTemp = \" " + AverageTemperature + "\" ";
            str += "RSD = \" " + RSD + "\" />";

            return str;
        }

    }
}
