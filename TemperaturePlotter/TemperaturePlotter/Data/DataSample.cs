/// <summary>
/// Class which shows data coming from File. 
/// Data Represents Temperature and TIme in milli seconds
/// </summary>
namespace TemperaturePlotter.Data
{
    class DataSample
    {
        public double Temperature { get; set; }
        public double Time { get; set; }
        
        public DataSample(double temperature, double time)
        {
            Temperature = temperature;
            Time = time;
        }        
    }
}
