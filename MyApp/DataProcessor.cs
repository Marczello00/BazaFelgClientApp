using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataProcessing
{
    public class DataProcessor
    {
        public static List<RimModel> FilterRimsByDiameter(List<RimModel> rimList, int diameter)
        {
            List<RimModel> outputRims = new List<RimModel>();
            foreach (var rim in rimList)
                if(rim.Diameter == diameter)
                    outputRims.Add(rim);
            return outputRims;
        }
    }
}
