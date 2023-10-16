using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
    internal class SqlConnectionApp
    {
        private static string GetRimsQuery= "SELECT id as Id, typ as Type, firma as Make, sruby as ScrewsQuantity, rozstaw as ScrewsSpacing, srednica as Diameter, szerokosc as Width, et as Offset, cena as Price, cenazo as PriceAsWheel, rozmo as TireSize, doto as TireDOT FROM felgi";
        public static List<RimModel> GetDatabaseData()
        {
            List<RimModel> output = new List <RimModel>();
            using (IDbConnection connection = new MySqlConnection(MainApplicationForm.GetConnectionString("warsztat")))
            {
                connection.Open();
                output = connection.Query<RimModel>(GetRimsQuery).ToList();
            }
            return output;
        }
        public static async Task<List<RimModel>> GetDatabaseDataAsync()
        {
            List<RimModel> rims = new List<RimModel>();
            try
            {
                using (var connection = new MySqlConnection(MainApplicationForm.GetConnectionString("warsztat")))
                {
                    await connection.OpenAsync();
                    rims = await Task.Run(() => connection.Query<RimModel>(GetRimsQuery).ToList());
                    return rims;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia bazy danych: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rims;
        }
    }
}
