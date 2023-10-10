using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    public class RimModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Make { get; set; }
        public int ScrewsQuantity { get; set; }
        public int ScrewsSpacing { get; set; }
        public float Diameter { get; set; }
        public float Width { get; set; }
        public float Offset { get; set; }
        public int Price { get; set; }
        public int PriceAsWheel { get; set; }
        public string TireSize { get; set; }
        public int TireDOT { get; set; }
        static int count = 0;
        public static int TotalCount()
        {
            return count;
        }
        public RimModel() {
            Type = "";
            Make = "";
            TireSize = "";
            count++;
        }
        public RimModel(string  id, string type, string make, string screwsQuantity, string screwsSpacing, string diameter, string width, string offset, string price, string priceAsWheel, string tireSize, string tireDOT)
        {
            int idValue = 0;
            int.TryParse(id, out idValue);
            Id = idValue;

            Type= type;

            Make = make;

            int screwsQuantityValue = 0;
            int.TryParse(screwsQuantity, out screwsQuantityValue);
            ScrewsQuantity = screwsQuantityValue;

            int screwsSpacingValue = 0;
            int.TryParse(screwsSpacing,out screwsSpacingValue);
            ScrewsSpacing = screwsSpacingValue;

            float diameterValue = 0;
            float.TryParse(diameter,out diameterValue);
            Diameter= diameterValue;

            float widthValue = 0;
            float.TryParse(width,out widthValue);
            Width = widthValue;

            float offsetValue = 0;
            float.TryParse(offset,out offsetValue);
            Offset = offsetValue;

            int priceValue = 0;
            int.TryParse(price,out priceValue);
            Price = priceValue;

            int priceAsWheelValue = 0;
            int.TryParse(priceAsWheel,out priceAsWheelValue);
            PriceAsWheel = priceAsWheelValue;

            TireSize = tireSize;

            int tireDOTValue = 0;
            int.TryParse(tireDOT,out tireDOTValue);
            TireDOT= tireDOTValue;
            count++;
        }
        public void ShowSmth()
        {
            MessageBox.Show("Udało się coś!");
        }

    }
}
