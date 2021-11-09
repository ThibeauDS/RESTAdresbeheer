using Datalaag.Exceptions;
using Domeinlaag.Interfaces;
using Domeinlaag.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Repositories
{
    public class StraatRepositoryADO : IStraatRepository
    {
        #region Properties
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public StraatRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region Methods
        private SqlConnection getConnection()
        {
            SqlConnection connection = new(_connectionString);
            return connection;
        }

        public List<Straat> GeefStratenGemeente(int gemeenteId)
        {
            SqlConnection connection = getConnection();
            string sql = "SELECT * FROM [dbo].[gemeente] g INNER JOIN [dbo].[straat] s ON g.NIScode = s.NIScode WHERE g.NIScode = @NIScode ";
            using SqlCommand command = new(sql, connection);
            try
            {
                List<Straat> stratenLijst = new();
                connection.Open();
                command.Parameters.AddWithValue("@NIScode", gemeenteId);
                IDataReader dataReader = command.ExecuteReader();
                Gemeente gemeente = null;
                while (dataReader.Read())
                {
                    if (gemeente == null)
                    {
                        gemeente = new Gemeente((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                    }
                    Straat straat = new((int)dataReader["Id"], (string)dataReader["straatnaam"], gemeente);
                    stratenLijst.Add(straat);
                }
                dataReader.Close();
                return stratenLijst;
            }
            catch (Exception ex)
            {
                throw new StraatRepositoryADOException("GeefStratenGemeente is niet gelukt: ", ex);
            }
            finally
            {
                connection.Close();
            }
        } 
        #endregion
    }
}
