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
    public class GemeenteRepositoryADO : IGemeenteRepository
    {
        #region Properties
        private string _connectionString;
        #endregion

        #region Constructors
        public GemeenteRepositoryADO(string connectionString)
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
        #endregion

        #region Implementation
        public Gemeente GeefGemeente(int id) //Id == NIScode
        {
            SqlConnection connection = getConnection();
            string sql = "SELECT * FROM dbo.gemeente WHERE NIScode=@NIScode";
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@NIScode", id);
                IDataReader dataReader = command.ExecuteReader();
                dataReader.Read();
                Gemeente gemeente = new((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                dataReader.Close();
                return gemeente;
            }
            catch (Exception ex)
            {
                throw new GemeenteRepositoryADOException("Geef gemeente niet gelukt", ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public bool HeeftGemeente(int nIScode)
        {
            string sql = "SELECT count(*) FROM [dbo].[gemeente] WHERE NIScode = @NIScode";
            SqlConnection connection = getConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.AddWithValue("@NIScode", nIScode);
                int n = (int)command.ExecuteScalar();
                if (n > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                GemeenteRepositoryADOException dbex = new("BestaatGemeente niet gelukt", ex);
                dbex.Data.Add("Gemeente", nIScode);
                throw dbex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void VoegGemeenteToe(Gemeente gemeente)
        {
            string sql = "INSERT INTO [dbo].[gemeente] (NIScode, gemeentenaam) VALUES (@NIScode, @gemeentenaam)";
            SqlConnection connection = getConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.Parameters.Add(new SqlParameter("@NIScode", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@gemeentenaam", SqlDbType.NVarChar));
                command.Parameters["@NIScode"].Value = gemeente.NIScode;
                command.Parameters["@gemeentenaam"].Value = gemeente.Gemeentenaam;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                GemeenteRepositoryADOException dbex = new("VoegGemeenteToe niet gelukt", ex);
                dbex.Data.Add("Gemeente", gemeente);
                throw dbex;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion
    }
}
