using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataProcessing
{
    public class DataProcessor
    {
        private static int GetBoltPatternListScrewsQuantity(string boltPattern)
        {
            int screwsQuantityi = 0;

            int indexOfX = boltPattern.IndexOf("x");

            if (indexOfX != -1 && indexOfX > 0)
            {
                string screwsQuantitystr = boltPattern.Substring(0, indexOfX);

                if (int.TryParse(screwsQuantitystr, out screwsQuantityi))
                    return screwsQuantityi;
            }
            return -1;
        }
        //TODO Polacz te dwie metody w jedna z uzyciem out.
        private static float GetBoltPatternListScrewsSpacing(string boltPattern)
        {
            float screwsSpacingf = 0;

            int indexOfX = boltPattern.IndexOf("x");

            if (indexOfX != -1 && indexOfX < boltPattern.Length - 1)
            {
                string screwsSpacingstr = boltPattern.Substring(indexOfX + 1);
                if (float.TryParse(screwsSpacingstr, out screwsSpacingf))
                    return screwsSpacingf;
            }
            return -1;
        }
        //TODO zamiast prostej zamiany str na int zrob zwracanie zawartosci tablicy srednic pod podanym indeksem
        private static int GetDiameterListDiameter(string diameter)
        {
            int diameteri = 0;
            if(int.TryParse(diameter, out diameteri))
                return diameteri;
            return -1;
        }
        /// <summary>
        /// Filters all the given rims to those who has given diameter
        /// </summary>
        /// <param name="rimList">List of rims to be filtered</param>
        /// <param name="diameter">Specified diameter of rim in inches</param>
        /// <returns>Filtered rim list</returns>
        public static List<RimModel> FilterRimsByDiameter(List<RimModel> rimList, int indexOfDiameterList)
        {
            int diameter = 0;
            diameter = GetDiameterListDiameter(RimModel.DiameterList[indexOfDiameterList]);
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
        public static List<RimModel> FilterRimsByScrews(List<RimModel> rimList, int indexOfScrewsSpacingList)
        {
            int screwsQuantity = 0;
            float screwsSpacing = 0;
            string boltPattern = RimModel.boltPatternList[indexOfScrewsSpacingList];
            screwsQuantity = GetBoltPatternListScrewsQuantity(boltPattern);
            screwsSpacing = GetBoltPatternListScrewsSpacing(boltPattern);

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
        //public static List<RimModel> FilterRimsByBoth(List<RimModel> rimList, int diameter, int screwsQuantity, int screwsSpacing)
        //{
        //    List<RimModel> outputRims = new List<RimModel>();
        //    outputRims = FilterRimsByDiameter(FilterRimsByScrews(rimList, screwsQuantity, screwsSpacing), diameter);
        //    return outputRims;
        //}
    }
}
