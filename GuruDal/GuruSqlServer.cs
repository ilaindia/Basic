//-----------------------------------------------------------------------
// <copyright file="GuruSqlServer.cs" company="Guru Tech">
// TODO: This Dll Has Belongs To Guru Tech
// </copyright>
// -----------------------------------------------------------------------
namespace GuruDal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;

    public class GuruSqlServer
    {
        /// <summary>
        /// Database connection
        /// </summary>
        private SqlConnection con;

        /// <summary>
        /// Check for single connection or open connection
        /// </summary>
        private readonly bool isSingleConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlServer" /> class.
        /// </summary>
        public GuruSqlServer()
        {
            this.con = null;
            this.isSingleConnection = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlServer" /> class and opens the database connection.
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public GuruSqlServer(string connectionString)
        {
            this.con = new SqlConnection(connectionString);
            this.con.Open();
            this.isSingleConnection = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlServer" /> class and opens the database connection.
        /// </summary>
        /// <param name="SqlConnection">Shared SQL connection</param>
        public GuruSqlServer(SqlConnection mycon)
        {
            this.con = mycon;
            this.isSingleConnection = false;
        }

        /// <summary>
        /// Assgin the current login user id to track the database changes
        /// </summary>
        public string ActionBy { get; set; }

        /// <summary>
        /// Gets or sets the validation message
        /// </summary>
        public string ValidationMessage { get; set; }

        /// <summary>
        /// Dispose this class and close the database connection if open
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (this.con.State == ConnectionState.Open)
                {
                    this.con.Close();
                }

                this.con.Dispose();
            }
            catch
            {
                ////
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Marks the starting point of sql operation
        /// </summary>
        public void BeginTransaction()
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.con;
                cmd.CommandText = "BEGIN TRANSACTION";
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Marks the end point of sql operation
        /// </summary>
        public void CommitTransaction()
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("IF(@@TRANCOUNT>0) BEGIN COMMIT TRANSACTION END", this.con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Reverts the sql operation into beginning of the transaction
        /// </summary>
        public void RollbackTransaction()
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("IF(@@TRANCOUNT>0) BEGIN ROLLBACK TRANSACTION END", this.con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Execute the SQLCommand and returns the number of rows affected
        /// </summary>
        /// <param name="cmd">SQL statement</param>
        /// <returns>Returns the number of rows affected</returns>
        public int ExecuteNonQuery(SqlCommand cmd, string tableName, ref string keyvalue)
        {
            this.OpenConnection();
            try
            {
                cmd.Connection = this.con;
                int rowsEffected = cmd.ExecuteNonQuery();

                cmd.CommandText = "Select IDENT_CURRENT('[" + tableName + "]')";
                keyvalue = GuruConvert.AsString(cmd.ExecuteScalar());

                return rowsEffected;
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Execute the SQLCommand and returns the number of rows affected
        /// </summary>
        /// <param name="cmd">SQL statement</param>
        /// <returns>Returns the number of rows affected</returns>
        public int ExecuteNonQuery(SqlCommand cmd)
        {
            this.OpenConnection();
            try
            {
                cmd.Connection = this.con;
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Execute the SQLCommand and returns the number of rows affected by new connection
        /// </summary>
        /// <param name="cmd">SQL statement</param>
        /// <param name="myConnectionString">Database connection string</param>
        /// <returns>Returns the number of rows affected</returns>
        public int ExecuteNonQuery(SqlCommand cmd, string myConnectionString)
        {
            SqlConnection myCon = new SqlConnection(myConnectionString);
            myCon.Open();
            try
            {
                cmd.Connection = myCon;
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                myCon.Close();
                myCon.Dispose();
            }
        }

        /// <summary>
        /// Insert the records from result set into database table
        /// </summary>
        /// <param name="dt">Records set</param>
        /// <param name="destinationTable">Destination table in database</param>
        public void SqlBulkCopy(DataTable dt, string destinationTable)
        {
            this.OpenConnection();
            try
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(this.con);
                bulkCopy.DestinationTableName = destinationTable;

                bulkCopy.WriteToServer(dt);
                bulkCopy.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Insert the records from Data table into database table by new connection
        /// </summary>
        /// <param name="dt">Data table</param>
        /// <param name="destinationTable">Destination table</param>
        /// <param name="myConnectionString">Connection string</param>
        public void SqlBulkCopy1(DataTable dt, string destinationTable, string myConnectionString)
        {
            SqlBulkCopy bulkCopy = new SqlBulkCopy(myConnectionString);
            try
            {
                bulkCopy.DestinationTableName = destinationTable;
                bulkCopy.WriteToServer(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                bulkCopy.Close();
            }
        }

        /// <summary>
        /// Return the first row first column value from records set.
        /// </summary>
        /// <param name="cmd">Database query</param>
        /// <returns>First row first column value of result set</returns>
        public object ExecuteScalar(SqlCommand cmd)
        {
            this.OpenConnection();
            try
            {
                cmd.Connection = this.con;
                return cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Return the first row first column value from records set.
        /// </summary>
        /// <param name="cmd">Database query</param>
        /// <returns>First row first column value of result set</returns>
        public SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            this.OpenConnection();
            try
            {
                cmd.Connection = this.con;
                return cmd.ExecuteReader();
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Return the first row first column value from result set.
        /// </summary>
        /// <param name="cmd">Database query</param>
        /// <param name="myConnectionString">Connection string</param>
        /// <returns>First row first column value of result set</returns>
        public object ExecuteScalar(SqlCommand cmd, string myConnectionString)
        {
            SqlConnection myCon = new SqlConnection(myConnectionString);
            try
            {
                cmd.Connection = myCon;
                return cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                myCon.Close();
                myCon.Dispose();
            }
        }

        /// <summary>
        /// Update the set of records in database
        /// </summary>
        /// <param name="dt">Data table to update</param>
        /// <param name="TableName">Name of the database table name</param>
        /// <returns>Returns the no of rows affected</returns>
        public int UpdateDataTable(DataTable dt, String tableName)
        {
            this.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Select * From " + tableName + " Where 1=0 ", this.con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.InsertCommand = cb.GetInsertCommand();
                da.UpdateCommand = cb.GetUpdateCommand();
                return da.Update(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Update the set of records in database
        /// </summary>
        /// <param name="dt">Data table to update</param>
        /// <param name="TableName">Name of the database table name</param>
        /// <returns>Returns the no of rows affected</returns>
        public int UpdateDataTable(DataTable dt, String tableName, string myConnectionString)
        {
            SqlConnection myCon = new SqlConnection(myConnectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Select * From " + tableName + " Where 1=0 ", myCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.InsertCommand = cb.GetInsertCommand();
                da.UpdateCommand = cb.GetUpdateCommand();
                return da.Update(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                myCon.Close();
                myCon.Dispose();
            }
        }

        /// <summary>
        /// Execute the command and returns the result set
        /// </summary>
        /// <param name="cmd">SQL statement</param>
        /// <returns>Returns the result set</returns>
        public DataSet GetDataSet(SqlCommand cmd)
        {
            this.OpenConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = this.con;
                DataSet ds = new DataSet();
                ds.DataSetName = "DataSet1";
                da.Fill(ds);
                return ds;
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Execute the command and returns the result set
        /// </summary>
        /// <param name="cmd">SQL statement</param>
        /// <returns>Returns the result set</returns>
        public DataTable GetDataTable(SqlCommand cmd)
        {
            this.OpenConnection();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = this.con;
                DataTable dt = new DataTable();
                dt.TableName = "Table1";
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        /// <summary>
        /// Returns the result by new connection
        /// </summary>
        /// <param name="cmd">Database query statement</param>
        /// <param name="myConnectionString">Connection string</param>
        /// <returns>Returns record set</returns>
        public DataTable GetDataTable(SqlCommand cmd, string myConnectionString)
        {
            SqlConnection myCon = new SqlConnection(myConnectionString);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = myCon;
                DataTable dt = new DataTable();
                dt.TableName = "Table1";
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                myCon.Close();
                myCon.Dispose();
            }
        }

        /// <summary>
        /// Default connection string
        /// </summary>
        /// <returns>return default connection string</returns>
        private string DefaultConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["GuruConnectionString"].ConnectionString;
        }

        /// <summary>
        /// Returns the sql connection object for sharing
        /// </summary>
        /// <returns>SQL connection object</returns>
        public SqlConnection GetConnection()
        {
            return this.con;
        }

        /// <summary>
        /// Returns the sql connection status
        /// </summary>
        /// <returns>SQL connection object</returns>
        public ConnectionState GetConnectionState()
        {
            return this.con.State;
        }

        /// <summary>
        /// Open the database connection
        /// </summary>
        private void OpenConnection()
        {
            if (!this.isSingleConnection)
            {
                return;
            }

            this.con = new SqlConnection(this.DefaultConnectionString());
            this.con.Open();
        }

        /// <summary>
        /// Close the database connection
        /// </summary>
        private void CloseConnection()
        {
            if (this.isSingleConnection && this.con.State == ConnectionState.Open)
            {
                this.con.Close();
                this.con.Dispose();
            }
        }
    }
}
