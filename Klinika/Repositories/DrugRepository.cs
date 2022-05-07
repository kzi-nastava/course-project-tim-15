using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klinika.Models;
using System.Data.SqlClient;
using Klinika.Data;

namespace Klinika.Repositories
{
    public class DrugRepository
    {
        #region Singleton
        private static DrugRepository? instance;
        public static DrugRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DrugRepository();
                }
                return instance;
            }
        }
        #endregion

        #region Constructor
        public List<Ingredient> Ingredients { get; }
        public DrugRepository()
        {
            Ingredients = new List<Ingredient>();
            string getIngredientsQuery = "SELECT * FROM [Ingredient]";
            try
            {
                SqlCommand getIngredients = new SqlCommand(getIngredientsQuery, DatabaseConnection.GetInstance().database);
                try { DatabaseConnection.GetInstance().database.Open(); } catch { }
                
                using (SqlDataReader retrieved = getIngredients.ExecuteReader())
                {
                    while (retrieved.Read())
                    {
                        var ingredient = new Ingredient
                        {
                            ID = Convert.ToInt32(retrieved["ID"]),
                            Name = retrieved["Name"].ToString(),
                            Type = retrieved["Type"].ToString()
                        };
                        Ingredients.Add(ingredient);
                    }
                }
                DatabaseConnection.GetInstance().database.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion
    }
}
