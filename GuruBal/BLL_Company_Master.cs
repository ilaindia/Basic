using System;
using GuruDal;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace GuruBal
{
	public class BLL_Company_Master : GuruSqlBridge
    {
        #region Varialble or Object Initial like TableName/AuditTableName/KeyfieldName/Object & Varialbe Declaration
        /// <summary>
        /// <see cref="BLL_Company_Master" /> Belongs to COMPANY_MASTER
        /// </summary>
        public string tablename { get { return "COMPANY_MASTER"; } }
        /// <summary>
        /// Primary_Key For Company_Master is SYS_ID
        /// </summary>
        public string keyfield = "SYS_ID";


        /// <summary>
        /// Initializes a new instance of the <see cref="BLL_Company_Master" /> class with parameter connection string
        /// </summary>
        /// <param name="connectionstring">connection string</param>
        public BLL_Company_Master(SqlConnection Connection, string Actionby, string CompanyId)
            : base(Connection, Actionby, CompanyId)
        {
            this.Data = new TblCompany_Master();
            this.Pager = new sqlPager();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BLL_Company_Master" /> 
        /// </summary>
        public BLL_Company_Master(string Connection, string Actionby, string CompanyId)
            : base(Connection, Actionby, CompanyId)
        {
            this.Data = new TblCompany_Master();
            this.Pager = new sqlPager();
        }


        /// <summary>
        /// Gets or sets the data for Company_Master
        /// </summary>
        public TblCompany_Master Data { get; set; }
        /// <summary>
        /// Gets or Sets the Data Pager Properties
        /// </summary>
        public sqlPager Pager { get; set; }
        /// <summary>
        /// get or set the Master value
        /// </summary>
        public class TblCompany_Master
        {
            public string SYS_ID { get; set; }
			public string NAME { get; set; }
			public string ADDRESS_1 { get; set; }
			public string ADDRESS_2 { get; set; }
			public string CITY { get; set; }
			public string PHONE { get; set; }
			public string MOBILE { get; set; }
			public string IMG { get; set; }
			public string ISDELETED { get; set; }
        }

        /// <summary>
        /// Gets or Sets the Pager Properties
        /// </summary>
        public class sqlPager
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public string OrderBy { get; set; }
            public string OrderType { get; set; }
            public string SearchBy { get; set; }
            public string SearchText { get; set; }
            public int ItemCount { get; set; }
            public string IncludeDeleted { get; set; }
            public string Company_Id { get; set; }
        }
        #endregion

        #region Override Methods
        #region Insert/Update/Delete Metods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyID"></param>
        /// <returns></returns>
        public override int DeleteEntry(string keyID)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete the user from user master
        /// </summary>
        /// <param name="keyID">keyId</param>
        /// <returns>int</returns>
        public override int DeleteFlag(string keyID)
        {
            //Validate the ForeignKey Reference in child tables...
            this.Validate_foreignkey_reference(keyID);

            //Update the deleted flag
            return base.DeleteFlag(this.tablename, this.keyfield, keyID);
        }
        /// <summary>
        /// insert or update the Role record in database
        /// </summary>
        /// <returns>string</returns>
        public override string InsertUpdateEntry()
        {
            try
            {
                ValidateEntry();

                //Don't Add KeyField and isDeleted in Parameter...
                this.AddColumnParameter("NAME", this.Data.NAME);
				this.AddColumnParameter("ADDRESS_1", this.Data.ADDRESS_1);
				this.AddColumnParameter("ADDRESS_2", this.Data.ADDRESS_2);
				this.AddColumnParameter("CITY", this.Data.CITY);
				this.AddColumnParameter("PHONE", this.Data.PHONE);
				this.AddColumnParameter("MOBILE", this.Data.MOBILE);
				this.AddColumnParameter("IMG", this.Data.IMG);
                //Insert/Update Entry...


                // Pass the table namd and key field id for insert and update the table
                return this.InsertUpdate(this.tablename, this.keyfield, this.Data.SYS_ID);
            }
            catch { throw; }
        }
        #endregion

        #region Get Entry/Table
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyID"></param>
        /// <returns></returns>
        public override System.Data.DataTable GetDataEntryTable(string keyID)
        {
            return base.GetDataEntry(this.tablename, this.keyfield, keyID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override System.Data.DataTable GetDataList()
        {
            return base.GetDataList(this.tablename, true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyID"></param>
        public override void GetDataEntry(string keyID)
        {
            DataTable dt = base.GetDataEntry(this.tablename, this.keyfield, keyID);
            if (dt.Rows.Count > 0)
            {
                Data.SYS_ID = GuruConvert.AsString(dt.Rows[0]["SYS_ID"]);
				Data.NAME = GuruConvert.AsString(dt.Rows[0]["NAME"]);
				Data.ADDRESS_1 = GuruConvert.AsString(dt.Rows[0]["ADDRESS_1"]);
				Data.ADDRESS_2 = GuruConvert.AsString(dt.Rows[0]["ADDRESS_2"]);
				Data.CITY = GuruConvert.AsString(dt.Rows[0]["CITY"]);
				Data.PHONE = GuruConvert.AsString(dt.Rows[0]["PHONE"]);
				Data.MOBILE = GuruConvert.AsString(dt.Rows[0]["MOBILE"]);
				Data.IMG = GuruConvert.AsString(dt.Rows[0]["IMG"]);
				Data.ISDELETED = GuruConvert.AsString(dt.Rows[0]["ISDELETED"]);
            }
        }
        #endregion

        #region Validation
        /// <summary>
        /// Check child table values based on parent table value
        /// </summary>
        /// <param name="keyvalue">key value</param>
        public void Validate_foreignkey_reference(string keyvalue)
        {
            try
            {
                // validate foreign-key reference
                this.ValidationMessage = string.Empty;
                
                this.ValidateResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ValidationMessage = string.Empty;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public override void ValidateEntry()
        {
            try
            {
                // Validate the fields
                this.ValidationMessage = string.Empty;
                
                this.ValidateResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ValidationMessage = string.Empty;
            }
        }
        #endregion
        #endregion

        #region functionalites
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetMasterList(string Master_Name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "uspMasterList";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@intPageNo", Pager.PageNumber);
            cmd.Parameters.AddWithValue("@intPageSize", Pager.PageSize);
            cmd.Parameters.AddWithValue("@strOrderBy", Pager.OrderBy);
            cmd.Parameters.AddWithValue("@strOrderType", Pager.OrderType);
            cmd.Parameters.AddWithValue("@strSearchBy", Pager.SearchBy);
            cmd.Parameters.AddWithValue("@strSearchText", Pager.SearchText);
            cmd.Parameters.AddWithValue("@MasterName", Master_Name);
            SqlParameter output = new SqlParameter("@intItemCount", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(output);

            DataSet dsList = GetDataSet(cmd);
            //Pager.ItemCount = GuruConvert.AsInt(output.Value);

            Pager.ItemCount = GuruConvert.AsInt(dsList.Tables[0].Rows[0][0]);
            return dsList.Tables[1];
        }
        #endregion
    }
}