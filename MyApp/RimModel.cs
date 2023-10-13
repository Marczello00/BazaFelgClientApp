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
        public static List<string> boltPatternList = new List<string> { "Rozstaw", "5x112", "5x100", "5x120", "5x108", "5x110", "4x114.3", "5x115", "4x100", "4x108" };
        public static List<string> DiameterList = new List<string> { "Średnica", "13", "14", "15", "16", "17", "18", "19", "20" };
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Make { get; private set; }
        public int ScrewsQuantity { get; private set; }
        public int ScrewsSpacing { get; private set; }//TODO tu ma byc float jednak
        public float Diameter { get; private set; }
        public float Width { get; private set; }
        public float Offset { get; private set; }
        public int Price { get; private set; }
        public int PriceAsWheel { get; private set; }
        public string TireSize { get; private set; }
        public int TireDOT { get; private set; }
        public RimModel() {
            Type = "";
            Make = "";
            TireSize = "";
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
        }
        public void ShowSmth()
        {
            MessageBox.Show("Udało się coś!");
        }

    }
}
