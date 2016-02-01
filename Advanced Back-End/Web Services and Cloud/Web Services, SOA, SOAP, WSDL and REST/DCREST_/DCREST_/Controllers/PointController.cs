using System;
using System.Web.Http;

namespace DCREST_.Controllers
{
    public class PointController : ApiController
    {
        // Not sure where I'm supposed to create the Point class,
        // so I'm using four parameters instead of two
        public double Get(int startX, int startY, int endX, int endY)
        {
            double differenceX = Math.Pow((endX - startX), 2);
            double differenceY = Math.Pow((endY - startY), 2);
            double distance = Math.Sqrt(differenceX + differenceY);

            return distance;
        }
    }
}
