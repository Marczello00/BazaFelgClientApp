using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataProcessing
{
    public class DataProcessor
    {
        /// <summary>
        /// Filters all the given rims to those who has given diameter
        /// </summary>
        /// <param name="rimList">List of rims to be filtered</param>
        /// <param name="diameter">Specified diameter of rim in inches</param>
        /// <returns>Filtered rim list</returns>
        public static List<RimModel> FilterRimsByDiameter(List<RimModel> rimList, int diameter)
        {
            List<RimModel> outputRims = new List<RimModel>();
            foreach (var rim in rimList)
                if(rim.Diameter == diameter)
                    outputRims.Add(rim);
            return outputRims;
        }
        /// <summary>
        /// Filters all the given rims to those who has given screws quantity and spacing
        /// </summary>
        /// <param name="rimList">List of rims to be filtered</param>
        /// <param name="screwsQuantity">Number of screws</param>
        /// <param name="screwsSpacing">Spacing between screws</param>
        /// <returns>Filtered rims list</returns>
        public static List<RimModel> FilterRimsByScrews(List<RimModel> rimList, int screwsQuantity, int screwsSpacing)
        {
            List<RimModel> outputRims = new List<RimModel>();
            foreach (var rim in rimList)
                if (rim.ScrewsQuantity == screwsQuantity)
                    if (rim.ScrewsSpacing == screwsSpacing)
                        outputRims.Add(rim);
            return outputRims;
        }
        /// <summary>
        /// Filters all the given rims to those who has given diameter, screws quantity and screws spacing
        /// </summary>
        /// <param name="rimList">List of rims to be filtered</param>
        /// <param name="diameter">Specified diameter of rim in inches</param>
        /// <param name="screwsQuantity">Number of screws</param>
        /// <param name="screwsSpacing">Spacing between screws</param>
        /// <returns>Filtered rims list</returns>
        public static List<RimModel> FilterRimsByBoth(List<RimModel> rimList, int diameter, int screwsQuantity, int screwsSpacing)
        {
            List<RimModel> outputRims = new List<RimModel>();
            outputRims = FilterRimsByDiameter(FilterRimsByScrews(rimList, screwsQuantity, screwsSpacing), diameter);
            return outputRims;
        }
    }
}
