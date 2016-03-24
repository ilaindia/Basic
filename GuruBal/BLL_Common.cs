using System;
using System.Data;
using GuruDal;
using System.Data.SqlClient;

namespace GuruBal
{
    public class BLL_Common : GuruSqlBridge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BLL_Common" /> class.
        /// </summary>
        /// <param name="connectionString">Set connection string to communicatie MSSQL server</param>
        /// <param name="ActionBy">Assgin the current login user id to track the database changes</param>
        public BLL_Common(string connectionString, string ActionBy, string CompanyId)
            : base(connectionString, ActionBy, CompanyId)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlBridge" /> class.
        /// </summary>
        /// <param name="mycon">Set Sql Connection to communicatie MSSQL server.</param>
        /// <param name="ActionBy">Assgin the current login user id to track the database changes</param>
        public BLL_Common(SqlConnection mycon, string ActionBy, string CompanyId)
            : base(mycon, ActionBy, CompanyId)
        {

        }

        #region overridemethods
        public override int DeleteEntry(string keyID)
        {
            throw new NotImplementedException();
        }

        public override int DeleteFlag(string keyID)
        {
            throw new NotImplementedException();
        }

        public override void GetDataEntry(string keyID)
        {
            throw new NotImplementedException();
        }

        public override DataTable GetDataEntryTable(string keyID)
        {
            throw new NotImplementedException();
        }

        public override DataTable GetDataList()
        {
            throw new NotImplementedException();
        }

        public override string InsertUpdateEntry()
        {
            throw new NotImplementedException();
        }

        public override void ValidateEntry()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
