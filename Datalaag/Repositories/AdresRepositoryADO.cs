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
    public class AdresRepositoryADO : IAdresRepository
    {
        #region Properties
        private readonly string _connectionString;
        #endregion

        #region Constructors
        public AdresRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        private SqlConnection getConnection()
        {
            SqlConnection connection = new(_connectionString);
            return connection;
        }

        public IEnumerable<Adres> GeefAdressenStraat(int id)
        {
            string sql = "SELECT t1.* t2.straatnaam,t2.NIScode,t3.gemeentenaam FROM dbo.adres t1 INNER JOIN dbo.straat t2 ON t1.straatID = t2.Id INNER JOIN dbo.gemeente t3 on t3.NIScode = t2.NIScode WHERE t1.straatid=@straatid";
            SqlConnection connection = getConnection();
            using SqlCommand command = new(sql, connection);
            try
            {
                List<Adres> adressenLijst = new();
                Gemeente gemeente = null;
                Straat straat = null;
                connection.Open();
                command.Parameters.AddWithValue("@straatid", id);
                IDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    if (gemeente == null)
                    {
                        gemeente = new Gemeente((int)dataReader["NIScode"], (string)dataReader["gemeentenaam"]);
                    }
                    if (straat == null)
                    {
                        straat = new(id, (string)dataReader["straatnaam"], gemeente);
                    }
                    AdresLocatie adresLocatie = new((double)dataReader["x"], (double)dataReader["y"]);
                    string appnr;
                    string busnr;
                    if (dataReader.IsDBNull(dataReader.GetOrdinal("appartementnummer")))
                    {
                        appnr = null;
                    }
                    else
                    {
                        appnr = (string)dataReader["appartementnummer"];
                    }

                    if (dataReader.IsDBNull(dataReader.GetOrdinal("busnummer")))
                    {
                        busnr = null;
                    }
                    else
                    {
                        busnr = (string)dataReader["busnummer"];
                    }
                    Adres adres = new((int)dataReader["Id"], straat, (string)dataReader["huisnummer"], appnr, busnr, (int)dataReader["postcode"], adresLocatie);
                    adressenLijst.Add(adres);
                }
                dataReader.Close();
                return adressenLijst;
            }
            catch (Exception ex)
            {
                throw new AdresRepositoryADOException("GeefAdressenStraat", ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
