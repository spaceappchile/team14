

namespace ALMADataAccess
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;

    public class tSScript
    {
        public long id { get; set; }
        public string tFile { get; set; }
        public string tLine { get; set; }
        public string tRoutine { get; set; }
        public string tProcess { get; set; }
        public string tThead { get; set; }
        public string tContext { get; set; }
        public string tSourceObject { get; set; }
        public string tStackId { get; set; }
        public string tStackLevel { get; set; }
        public string CData { get; set; }
        public string Script { get; set; }
        public DateTime Creation { get; set; }
        public string Problem { get; set; }
        public string tTimeSpan { get; set; }


        public tSScript()
        { 
        
        }

        public bool Save()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = ConfigurationSettings.AppSettings["StringConexion"].ToString();
            try
            {
                

                SqlCommand command = new SqlCommand("SPR_INSERT001", sql);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader Datos;
                command.Parameters.Add("@tFile", this.tFile);
                command.Parameters.Add("@tLine", this.tLine);
                command.Parameters.Add("@tRoutine", this.tRoutine);
                command.Parameters.Add("@tProcess", this.tProcess);
                command.Parameters.Add("@tThead", this.tThead);
                command.Parameters.Add("@tContext", this.tContext);
                command.Parameters.Add("@tSourceObject", this.tSourceObject);
                command.Parameters.Add("@tStackId", this.tStackId);
                command.Parameters.Add("@tStackLevel", this.tStackLevel);
                command.Parameters.Add("@CData", this.CData.Replace("'", string.Empty));
                command.Parameters.Add("@Script", this.Script);
                command.Parameters.Add("@Creation", !this.Creation.ToString().Contains("0001") ? this.Creation : DateTime.Now);
                command.Parameters.Add("@Problem", this.Problem);
                command.Parameters.Add("@tTSTwo", null);
                sql.Open();
                Datos = command.ExecuteReader();
                try
                {

                    if (Datos.Read())
                    {
                        if (Datos["RESPUESTA"].ToString() == "OK")
                            return true;
                    }
                }
                finally
                {
                    Datos.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Failed", ex.Message);
                sql.Close();
            }
            finally
            {
                sql.Close();
            }
            return false;
        }
        public bool BulkSave(DataTable _dttBulk)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = ConfigurationSettings.AppSettings["StringConexion"].ToString();
            sql.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sql))
            {
                bulkCopy.DestinationTableName =
                    "dbo.tSScript2";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(_dttBulk);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    sql.Close();
                    return false;
                }
            }
            return true;
        }
        
    }
}
