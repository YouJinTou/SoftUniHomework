using System.Runtime.Serialization;
using System.ServiceModel;

namespace DistanceCalculator
{
    [ServiceContract]
    public interface IServiceDistanceCalculator
    {
        [OperationContract]
        double CalculateDistance(Point start, Point end);
    }
    
    [DataContract]
    public class Point
    {       
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        [DataMember]
        public int X { get; set; }

        [DataMember]
        public int Y { get; set; }
    }
}
