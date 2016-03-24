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
	public class BLL_User_Master : GuruSqlBridge
    {
        #region Varialble or Object Initial like TableName/AuditTableName/KeyfieldName/Object & Varialbe Declaration
        /// <summary>
        /// <see cref="BLL_User_Master" /> Belongs to USER_MASTER
        /// </summary>
        public string tablename { get { return "USER_MASTER"; } }
        /// <summary>
        /// Primary_Key For User_Master is SYS_ID
        /// </summary>
        public string keyfield = "SYS_ID";


        /// <summary>
        /// Initializes a new instance of the <see cref="BLL_User_Master" /> class with parameter connection string
        /// </summary>
        /// <param name="connectionstring">connection string</param>
        public BLL_User_Master(SqlConnection Connection, string Actionby, string CompanyId)
            : base(Connection, Actionby, CompanyId)
        {
            this.Data = new TblUser_Master();
            this.Pager = new sqlPager();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BLL_User_Master" /> 
        /// </summary>
        public BLL_User_Master(string Connection, string Actionby, string CompanyId)
            : base(Connection, Actionby, CompanyId)
        {
            this.Data = new TblUser_Master();
            this.Pager = new sqlPager();
        }


        /// <summary>
        /// Gets or sets the data for User_Master
        /// </summary>
        public TblUser_Master Data { get; set; }
        /// <summary>
        /// Gets or Sets the Data Pager Properties
        /// </summary>
        public sqlPager Pager { get; set; }
        /// <summary>
        /// get or set the Master value
        /// </summary>
        public class TblUser_Master
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
			public string SYS_ID { get; set; }
			public string ID { get; set; }
			public string FULL_NAME { get; set; }
			public string DIVISION { get; set; }
			public string GRADE { get; set; }
			public string DESIGNATION { get; set; }
			public string DOB { get; set; }
			public string PLACE_BIRTH { get; set; }
			public string DOJ { get; set; }
			public string PANCARD { get; set; }
			public string PASSPORT { get; set; }
			public string BG { get; set; }
			public string RELIGION { get; set; }
			public string PERM_ADDR { get; set; }
			public string PERM_EMAIL { get; set; }
			public string PERM_MOBILE { get; set; }
			public string PRES_ADDR { get; set; }
			public string PRES_EMAIL { get; set; }
			public string PRES_MOBILE { get; set; }
			public string EMG_CON_NAME { get; set; }
			public string EMG_CON_PHONE { get; set; }
			public string EMG_CON_MOBILE { get; set; }
			public string IMG { get; set; }
			public string ISDELETED { get; set; }
			public string SYS_ID { get; set; }
			public string ID { get; set; }
			public string NAME { get; set; }
			public string DESCRIPTION { get; set; }
			public string TYPE { get; set; }
			public string ISDELETED { get; set; }
			public string SYS_ID { get; set; }
			public string NAME { get; set; }
			public string LOGIN_NAME { get; set; }
			public string PASSWORD { get; set; }
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
				this.AddColumnParameter("ID", this.Data.ID);
				this.AddColumnParameter("FULL_NAME", this.Data.FULL_NAME);
				this.AddColumnParameter("DIVISION", this.Data.DIVISION);
				this.AddColumnParameter("GRADE", this.Data.GRADE);
				this.AddColumnParameter("DESIGNATION", this.Data.DESIGNATION);
				this.AddColumnParameter("DOB", this.Data.DOB);
				this.AddColumnParameter("PLACE_BIRTH", this.Data.PLACE_BIRTH);
				this.AddColumnParameter("DOJ", this.Data.DOJ);
				this.AddColumnParameter("PANCARD", this.Data.PANCARD);
				this.AddColumnParameter("PASSPORT", this.Data.PASSPORT);
				this.AddColumnParameter("BG", this.Data.BG);
				this.AddColumnParameter("RELIGION", this.Data.RELIGION);
				this.AddColumnParameter("PERM_ADDR", this.Data.PERM_ADDR);
				this.AddColumnParameter("PERM_EMAIL", this.Data.PERM_EMAIL);
				this.AddColumnParameter("PERM_MOBILE", this.Data.PERM_MOBILE);
				this.AddColumnParameter("PRES_ADDR", this.Data.PRES_ADDR);
				this.AddColumnParameter("PRES_EMAIL", this.Data.PRES_EMAIL);
				this.AddColumnParameter("PRES_MOBILE", this.Data.PRES_MOBILE);
				this.AddColumnParameter("EMG_CON_NAME", this.Data.EMG_CON_NAME);
				this.AddColumnParameter("EMG_CON_PHONE", this.Data.EMG_CON_PHONE);
				this.AddColumnParameter("EMG_CON_MOBILE", this.Data.EMG_CON_MOBILE);
				this.AddColumnParameter("IMG", this.Data.IMG);
				this.AddColumnParameter("ID", this.Data.ID);
				this.AddColumnParameter("NAME", this.Data.NAME);
				this.AddColumnParameter("DESCRIPTION", this.Data.DESCRIPTION);
				this.AddColumnParameter("TYPE", this.Data.TYPE);
				this.AddColumnParameter("NAME", this.Data.NAME);
				this.AddColumnParameter("LOGIN_NAME", this.Data.LOGIN_NAME);
				this.AddColumnParameter("PASSWORD", this.Data.PASSWORD);
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
				Data.SYS_ID = GuruConvert.AsString(dt.Rows[0]["SYS_ID"]);
				Data.ID = GuruConvert.AsString(dt.Rows[0]["ID"]);
				Data.FULL_NAME = GuruConvert.AsString(dt.Rows[0]["FULL_NAME"]);
				Data.DIVISION = GuruConvert.AsString(dt.Rows[0]["DIVISION"]);
				Data.GRADE = GuruConvert.AsString(dt.Rows[0]["GRADE"]);
				Data.DESIGNATION = GuruConvert.AsString(dt.Rows[0]["DESIGNATION"]);
				Data.DOB = GuruConvert.AsString(dt.Rows[0]["DOB"]);
				Data.PLACE_BIRTH = GuruConvert.AsString(dt.Rows[0]["PLACE_BIRTH"]);
				Data.DOJ = GuruConvert.AsString(dt.Rows[0]["DOJ"]);
				Data.PANCARD = GuruConvert.AsString(dt.Rows[0]["PANCARD"]);
				Data.PASSPORT = GuruConvert.AsString(dt.Rows[0]["PASSPORT"]);
				Data.BG = GuruConvert.AsString(dt.Rows[0]["BG"]);
				Data.RELIGION = GuruConvert.AsString(dt.Rows[0]["RELIGION"]);
				Data.PERM_ADDR = GuruConvert.AsString(dt.Rows[0]["PERM_ADDR"]);
				Data.PERM_EMAIL = GuruConvert.AsString(dt.Rows[0]["PERM_EMAIL"]);
				Data.PERM_MOBILE = GuruConvert.AsString(dt.Rows[0]["PERM_MOBILE"]);
				Data.PRES_ADDR = GuruConvert.AsString(dt.Rows[0]["PRES_ADDR"]);
				Data.PRES_EMAIL = GuruConvert.AsString(dt.Rows[0]["PRES_EMAIL"]);
				Data.PRES_MOBILE = GuruConvert.AsString(dt.Rows[0]["PRES_MOBILE"]);
				Data.EMG_CON_NAME = GuruConvert.AsString(dt.Rows[0]["EMG_CON_NAME"]);
				Data.EMG_CON_PHONE = GuruConvert.AsString(dt.Rows[0]["EMG_CON_PHONE"]);
				Data.EMG_CON_MOBILE = GuruConvert.AsString(dt.Rows[0]["EMG_CON_MOBILE"]);
				Data.IMG = GuruConvert.AsString(dt.Rows[0]["IMG"]);
				Data.ISDELETED = GuruConvert.AsString(dt.Rows[0]["ISDELETED"]);
				Data.SYS_ID = GuruConvert.AsString(dt.Rows[0]["SYS_ID"]);
				Data.ID = GuruConvert.AsString(dt.Rows[0]["ID"]);
				Data.NAME = GuruConvert.AsString(dt.Rows[0]["NAME"]);
				Data.DESCRIPTION = GuruConvert.AsString(dt.Rows[0]["DESCRIPTION"]);
				Data.TYPE = GuruConvert.AsString(dt.Rows[0]["TYPE"]);
				Data.ISDELETED = GuruConvert.AsString(dt.Rows[0]["ISDELETED"]);
				Data.SYS_ID = GuruConvert.AsString(dt.Rows[0]["SYS_ID"]);
				Data.NAME = GuruConvert.AsString(dt.Rows[0]["NAME"]);
				Data.LOGIN_NAME = GuruConvert.AsString(dt.Rows[0]["LOGIN_NAME"]);
				Data.PASSWORD = GuruConvert.AsString(dt.Rows[0]["PASSWORD"]);
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