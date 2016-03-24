//-----------------------------------------------------------------------
// <copyright file="GuruSqlBridge.cs" company="Guru Tech">
// TODO: This Dll Has Belongs To Guru Tech
// </copyright>
// -----------------------------------------------------------------------

namespace GuruDal
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    /// <summary>
    /// Abstract class for Database Bridge
    /// </summary>
    public abstract class GuruSqlBridge : GuruSqlServer
    {
        /// <summary>
        /// Adding the parameters value for insert and update operation
        /// </summary>
        private DataTable dtlParams = null;

        #region Init
        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlBridge" /> class.
        /// </summary>
        /// <param name="connectionString">Set connection string to communicatie MSSQL server</param>
        /// <param name="ActionBy">Assgin the current login user id to track the database changes</param>
        public GuruSqlBridge(string connectionString, string ActionBy, string CompanyId)
            : base(connectionString)
        {
            _ActionBy = ActionBy;
            _CompanyId = CompanyId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuruSqlBridge" /> class.
        /// </summary>
        /// <param name="mycon">Set Sql Connection to communicatie MSSQL server.</param>
        /// <param name="ActionBy">Assgin the current login user id to track the database changes</param>
        public GuruSqlBridge(SqlConnection mycon, string ActionBy, string CompanyId)
            : base(mycon)
        {
            _ActionBy = ActionBy;
            _CompanyId = CompanyId;
        }
        #endregion

        public string _ActionBy { get; set; }
        public string _CompanyId { get; set; }

        #region Abstract Method & Properties
        /// <summary>
        /// Method for get data list
        /// </summary>
        /// <returns>Data Table</returns>
        public abstract DataTable GetDataList();

        /// <summary>
        /// Get Data Entry list
        /// </summary>
        /// <param name="keyID">Key Value</param>
        public abstract void GetDataEntry(string keyID);

        /// <summary>
        /// Get data entry table list
        /// </summary>
        /// <param name="keyID">Key value</param>
        /// <returns>Data Table</returns>
        public abstract DataTable GetDataEntryTable(string keyID);

        /// <summary>
        /// Method for insert or update the value
        /// </summary>
        /// <returns>string value</returns>
        public abstract string InsertUpdateEntry();

        /// <summary>
        /// TODO : Validate the Input
        /// </summary>
        public abstract void ValidateEntry();

        /// <summary>
        /// Delete the record permanently
        /// </summary>
        /// <param name="keyID">Key value</param>
        /// <returns>Returns the number of rows affected</returns>
        public abstract int DeleteEntry(string keyID);

        /// <summary>
        /// TODO:Update the record status as delete
        /// </summary>
        /// <param name="keyID">Key value</param>
        /// <returns>Returns the number of rows affected</returns>
        public abstract int DeleteFlag(string keyID);
        #endregion

        #region Get Entry
        /// <summary>
        /// List the all records from that Table
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="isDeleted">Check for isDeleted</param>
        /// <returns>All records</returns>
        protected DataTable GetDataList(string tableName, bool isDeleted)
        {
            string condition = string.Empty;
            if (isDeleted)
                condition = "WHERE isDeleted <> 1";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from " + tableName + " " + condition;
            return this.GetDataTable(cmd);
        }

        /// <summary>
        /// Returns the particular record from that table
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="keyField">Key field</param>
        /// <param name="keyValue">Key value</param>
        /// <returns>Returns particular record</returns>
        protected DataTable GetDataEntry(string tableName, string keyField, string keyValue)
        {
            SqlCommand cmd = new SqlCommand("Select * From " + tableName + " Where ISDELETED <> 1 And " + keyField + "=@" + keyField);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@" + keyField, keyValue);
            return this.GetDataTable(cmd);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete the particular record
        /// </summary>
        /// <param name="table_name">Table Name</param>
        /// <param name="keyfield">Key field</param>
        /// <param name="keyvalue">Key value</param>
        /// <param name="isLogHistory">Set true if log this change</param>
        /// <returns>Returns the number of rows affected</returns>
        protected int DeleteEntry(string tableName, string keyfield, string keyvalue, bool isLogHistory = false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete From  " + tableName + " Where " + keyfield + "=@" + keyfield;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@" + keyfield, keyvalue);
            int rowsAffected = this.ExecuteNonQuery(cmd);

            ////Insert to Logs...
            if (isLogHistory)
            {
                this.InsertToLogs(tableName, keyfield, keyvalue, "DELETED");
            }

            return rowsAffected;
        }

        /// <summary>
        /// Update the record status as Deleted.
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="keyField">Key field</param>
        /// <param name="keyValue">Key value</param>
        /// <param name="isLogHistory">Set true if log this change</param>
        /// <returns>Returns the number of rows affected</returns>
        protected int DeleteFlag(string tableName, string keyField, string keyValue, bool isLogHistory = false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Update " + tableName + " Set ISDELETED = 1 Where 1 =1 and " + keyField + "=@" + keyField;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@" + keyField, keyValue);
            cmd.Parameters.AddWithValue("@isdeleted", 1);
            int rowsAffected = this.ExecuteNonQuery(cmd);

            ////Insert to Logs...
            if (isLogHistory)
            {
                this.InsertToLogs(tableName, keyField, keyValue, "DELETE");
            }

            return rowsAffected;
        }
        #endregion

        #region Validation
        /// <summary>
        /// Validate the decimal value is not equal to zero
        /// </summary>
        /// <param name="columnValue">Decimal value</param>
        /// <param name="displayName">Display name</param>
        protected void ValidateRequiredField(decimal columnValue, string displayName)
        {
            if (!(columnValue > 0))
            {
                this.ValidationMessage += "        " + displayName + " is Required!<br/>";
                return;
            }
        }

        /// <summary>
        /// Validate the required field for decimal
        /// </summary>
        /// <param name="columnValue">Decimal value</param>
        /// <param name="displayName">Display Name</param>
        /// <param name="minValue">Minimum Value</param>
        /// <param name="maxValue">Maximum Value</param>
        protected void ValidateRequiredField(decimal columnValue, string displayName, decimal minValue, decimal maxValue)
        {
            if (columnValue < minValue || columnValue > maxValue)
            {
                this.ValidationMessage += "        " + displayName + " should be in " + minValue.ToString() + " and " + maxValue.ToString() + "<br/>";
                return;
            }
        }

        /// <summary>
        /// Validate the integer value is not equal to zero
        /// </summary>
        /// <param name="columnValue">Integer value</param>
        /// <param name="displayName">Display name</param>
        protected void ValidateRequiredField(int columnValue, string displayName)
        {
            if (!(columnValue > 0))
            {
                this.ValidationMessage += "        " + displayName + " is Required!<br/>";
                return;
            }
        }

        /// <summary>
        /// Validate the integer value is not equal to zero and minimum and maximum range.
        /// </summary>
        /// <param name="columnValue">Integer value</param>
        /// <param name="displayName">Display name</param>
        /// <param name="minValue">Minimum value</param>
        /// <param name="maxValue">Maximum value</param>
        protected void ValidateRequiredField(int columnValue, string displayName, int minValue, int maxValue)
        {
            if (columnValue < minValue || columnValue > maxValue)
            {
                this.ValidationMessage += "        " + displayName + " should be in " + minValue.ToString() + " and " + maxValue.ToString() + "<br/>";
                return;
            }
        }

        /// <summary>
        /// Validate string is not empty and check the length.
        /// </summary>
        /// <param name="columnValue">String text</param>
        /// <param name="displayName">Display name</param>
        /// <param name="maxLength">Maximum length</param>
        protected void ValidateRequiredField(string columnValue, string displayName, int maxLength)
        {
            if ((columnValue == null) || (columnValue == string.Empty))
            {
                this.ValidationMessage += "        " + displayName + " is required!<br/>";
                return;
            }

            if (columnValue.Trim().Length > maxLength)
            {
                this.ValidationMessage += "        " + displayName + " should be less than " + maxLength + " char(s) length!<br/>";
                return;
            }
        }

        /// <summary>
        /// Validates the duplicate value
        /// </summary>
        /// <param name="columnValue">Column value</param>
        /// <param name="columnName">Column name</param>
        /// <param name="displayName">Display name</param>
        /// <param name="tableName">Table name</param>
        /// <param name="keyFieldName">Key field</param>
        /// <param name="keyFieldValue">Key value</param>
        /// <param name="isDeleted">Check record is deleted</param>
        /// <param name="whereCodition">Where condition</param>
        /// <returns>returns true if its a duplicate</returns>
        protected bool IsValidateDuplicateField(string columnValue, string columnName, string displayName, string tableName, string keyFieldName, string keyFieldValue, bool isDeleted, string whereCodition = "")
        {
            this.ValidateDuplicateField(columnValue, columnName, displayName, tableName, keyFieldName, keyFieldValue, isDeleted, whereCodition);
            if (this.ValidationMessage == string.Empty)
            {
                this.ValidationMessage = string.Empty;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Check for duplicate value from the table name
        /// </summary>
        /// <param name="columnValue">Column Value</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="displayName">Display Name</param>
        /// <param name="tableName">Table Name</param>
        /// <param name="keyFieldName">Key field</param>
        /// <param name="keyFieldValue">Key Value</param>
        /// <param name="isDeleted">Check is deleted</param>
        /// <param name="whereCodition">Where condition</param>
        protected void ValidateDuplicateField(string columnValue, string columnName, string displayName, string tableName, string keyFieldName, string keyFieldValue, bool isDeleted, string whereCodition = "")
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select " + columnName + " From " + tableName + " Where 1 =1 and " + columnName + "=@" + columnName + " ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@" + columnName, columnValue);

                //// Check the keycolumn
                if (GuruConvert.AsString(keyFieldValue) != string.Empty)
                {
                    cmd.CommandText += " And " + keyFieldName + " <> @" + keyFieldName;
                    cmd.Parameters.AddWithValue("@" + keyFieldName, keyFieldValue);
                }

                //// Check that record is deleted
                if (isDeleted)
                {
                    cmd.CommandText += " And IsNull(isDeleted,0)=0 ";
                }

                //// Add the custom where condition
                if (GuruConvert.AsString(whereCodition) != string.Empty)
                {
                    cmd.CommandText += " And " + whereCodition + " ";
                }

                DataTable dt = GetDataTable(cmd);
                if (dt.Rows.Count > 0)
                {
                    this.ValidationMessage += displayName + " " + columnValue + " is already exists!<br/>";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// TODO: Validates the database parameters
        /// </summary>
        protected void ValidateResult()
        {
            try
            {
                if (this.ValidationMessage != null && this.ValidationMessage != string.Empty)
                {
                    this.ValidationMessage = "The following errors were found in your data.<br/>" +
                                     this.ValidationMessage + "Please correct it and try again !";
                    throw new Exception(this.ValidationMessage);
                }
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

        #region Insert or Update
        /// <summary>
        /// Add the parameters for Insert or Update
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <param name="columnValue">Column Value</param>
        protected void AddColumnParameter(string columnName, string columnValue)
        {
            if (this.dtlParams == null)
            {
                this.dtlParams = new DataTable();
            }

            if (this.dtlParams.Columns.Count == 0)
            {
                this.dtlParams.Columns.Add("ColumnName", typeof(string));
                this.dtlParams.Columns.Add("ColumnValue", typeof(string));
            }

            this.dtlParams.Rows.Add(columnName, columnValue);
        }

        /// <summary>
        /// Choose the operation for insert or update based on key value.
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="keyField">Key field</param>
        /// <param name="keyValue">Key value</param>
        /// <param name="isLogHistory">Set true if log this change</param>
        /// <returns>return the key value</returns>
        protected string InsertUpdate(string tableName, string keyField, string keyValue, bool isLogHistory = false)
        {
            try
            {
                if (keyValue == string.Empty)
                {
                    keyValue = this.InsertEntry(tableName, keyField, isLogHistory);
                }
                else
                {
                    keyValue = this.UpdateEntry(tableName, keyField, keyValue, isLogHistory);
                }

                return keyValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Entry
        /// </summary>
        /// <param name="table_name">Table Name</param>
        /// <param name="keyfield">Key field</param>
        /// <param name="isLogHistory">Set true for log this change</param>
        /// <returns>Returns the key value based on number of rows affected</returns>
        protected string InsertEntry(string tableName, string keyfield, bool isLogHistory = false)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandType = CommandType.Text;

                string sql1 = string.Empty;
                string sql2 = string.Empty;
                foreach (DataRow dr in this.dtlParams.Rows)
                {
                    string colname = GuruConvert.AsString(dr["ColumnName"]);
                    if (colname.ToUpper() == keyfield.ToUpper())
                        continue;

                    sql1 += ((sql1 != string.Empty) ? "," : string.Empty) + colname;
                    sql2 += ((sql2 != string.Empty) ? "," : string.Empty) + "@" + colname;

                    if (!String.IsNullOrEmpty(GuruConvert.AsString(dr["ColumnValue"])))
                        cmd.Parameters.AddWithValue("@" + colname, GuruConvert.AsString(dr["ColumnValue"]));
                    else
                        cmd.Parameters.AddWithValue("@" + colname, DBNull.Value);
                }


                string keyvalue = "";
                cmd.CommandText = "Insert into " + tableName + "\r\n (" + sql1 + ", ISDELETED) Values \r\n (" + sql2 + ", 0)";
                int rowsAffected = this.ExecuteNonQuery(cmd, tableName, ref keyvalue);

                ////Insert to Logs...
                if (isLogHistory)
                {
                    this.InsertToLogs(tableName, keyfield, keyvalue, "INSERT");
                }

                //// Clear the parameters...
                this.dtlParams = null;

                //// Returns the 
                if (rowsAffected > 0)
                {
                    return keyvalue;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (SqlException Sqlex)
            {
                throw Sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Entry
        /// </summary>
        /// <param name="table_name">Table Name</param>
        /// <param name="keyfield">Key field</param>
        /// <param name="keyvalue">Record ID</param>
        /// <param name="isLogHistory">Set true if log this change</param>
        /// <returns>Returns the key value based on number of rows affected</returns>
        protected string UpdateEntry(string tableName, string keyfield, string keyvalue, bool isLogHistory = false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;

            string sql = string.Empty;
            foreach (DataRow dr in this.dtlParams.Rows)
            {
                string colname = GuruConvert.AsString(dr["ColumnName"]);
                if (colname.ToUpper() == keyfield.ToUpper())
                {
                    continue;
                }

                sql += ((sql != string.Empty) ? "," : string.Empty) + colname + "=@" + colname;

                if (!String.IsNullOrEmpty(GuruConvert.AsString(dr["ColumnValue"])))
                    cmd.Parameters.AddWithValue("@" + colname, GuruConvert.AsString(dr["ColumnValue"]));
                else
                    cmd.Parameters.AddWithValue("@" + colname, DBNull.Value);
            }

            cmd.CommandText = "Update " + tableName + " Set ISDELETED = 0, " + sql + " Where " + keyfield + " = @" + keyfield;
            cmd.Parameters.AddWithValue("@" + keyfield, keyvalue);
            int rowsAffected = this.ExecuteNonQuery(cmd);

            ////Insert to Logs...
            if (isLogHistory)
            {
                this.InsertToLogs(tableName, keyfield, keyvalue, "UPDATE");
            }

            //// Clear the parameters...
            this.dtlParams = null;

            //// Returns the keyvalue based on number of rows affected
            if (rowsAffected > 0)
            {
                return keyvalue;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Log Insert
        /// <summary>
        /// Insert the log changes into database.
        /// </summary>
        /// <param name="tableName">Table Name</param>
        /// <param name="keyField">Key field</param>
        /// <param name="keyValue">Record ID</param>
        /// <param name="actionFor">Insert, Update, Delete</param>
        protected void InsertToLogs(string tableName, string keyField, string keyValue, string actionFor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql1 = string.Empty;
                string sql2 = string.Empty;
                if (actionFor.ToUpper() == "INSERT" || actionFor.ToUpper() == "UPDATE")
                {
                    for (int i = 0; i < this.dtlParams.Rows.Count; i++)
                    {
                        string colname = "COLUMN_" + (i + 1);
                        string colvalue = GuruConvert.AsString(this.dtlParams.Rows[i]["ColumnValue"]);
                        sql1 += ((sql1 != string.Empty) ? "," : string.Empty) + colname;
                        sql2 += ((sql2 != string.Empty) ? "," : string.Empty) + "@" + colname;
                        cmd.Parameters.AddWithValue("@" + colname, colvalue);
                    }
                }

                // Insert into Log Table...
                sql1 = "TABLE_NAME, RECORD_ID, ACTION_BY, ACTION_FOR, ACTION_DATE " + ((sql1 != string.Empty) ? "," : string.Empty) + sql1;
                sql2 = "@TABLE_NAME, @RECORD_ID, @ACTION_BY, @ACTION_FOR, GETDATE() " + ((sql2 != string.Empty) ? "," : string.Empty) + sql2;

                cmd.CommandText = "INSERT INTO LOG_ACTIVITY \r\n (" + sql1 + ") VALUES \r\n (" + sql2 + ")";
                cmd.Parameters.AddWithValue("@TABLE_NAME", tableName);
                cmd.Parameters.AddWithValue("@RECORD_ID", keyValue);
                cmd.Parameters.AddWithValue("@ACTION_BY", _ActionBy);
                cmd.Parameters.AddWithValue("@ACTION_FOR", actionFor);
                this.ExecuteNonQuery(cmd);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Foreignkey_Ref
        /// <summary>
        /// Check for foreign key reference
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <param name="keyfield">Key field</param>
        /// <param name="keyvalue">Key value</param>
        /// <param name="description">Description if find any reference in child table</param>
        /// <param name="isDeleted">Check for isDeleted</param>
        /// <param name="whereCodition">Where condition</param>
        /// 
        protected void Check_Foreignkey_Reference(string tableName, string keyfield, string keyvalue, string description, bool isDeleted, string whereCodition = "")
        {
            if (GuruConvert.AsString(whereCodition) != string.Empty)
            {
                whereCodition = " And " + whereCodition + " ";
            }

            if (isDeleted)
            {
                whereCodition = " And IsNull(isDeleted,0) = 0 ";
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Top(1) [" + keyfield + "] From " + tableName + " Where [" + keyfield + "] = @keyvalue  " + whereCodition;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@keyvalue", keyvalue);
            DataTable dt = GetDataTable(cmd);
            if (dt.Rows.Count > 0)
            {
                this.ValidationMessage += "        " + " -> Delete records from " + description + ".<br/>";
            }
            else
            {
                return;
            }
        }

        #endregion

        #region Project Functionalites
        public string Get_Sys_Id(string Tablename, string ColName, string Value, string whereCodition = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT SYS_ID FROM " + Tablename + " WHERE ISDELETED = 'False' AND " + ColName + " = @value";

            if (GuruConvert.AsString(whereCodition) != string.Empty)
            {
                cmd.CommandText += " AND " + whereCodition + " ";
            }
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@value", Value);
            return GuruConvert.AsString(ExecuteScalar(cmd));
        }
        public DataTable Get_Company_List(string SubcriptionId, bool isHeader = false)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = (isHeader ? "SELECT '0' SYS_ID, 'Administrator' COMPANY_NAME UNION ALL \r\n" : "") +
                              "SELECT MC.SYS_ID, COMPANY_NAME FROM MASTER_COMPANY MC \r\n" +
                              "INNER JOIN SUBSCRIPTION SUB ON MC.SUBSCRIB_SYS_ID = SUB.SYS_ID \r\n" +
                              "WHERE SUB.SUBSCRIPTION_ID = @SUBSCRIPTION_ID AND MC.ISDELETED = 'FALSE'";


            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@SUBSCRIPTION_ID", SubcriptionId);
            return GetDataTable(cmd);
        }
        /// <summary>
        /// Get Name List dynamically from any master
        /// </summary>
        /// <param name="MASTER_NAME">Mastername</param>
        /// <param name="isAllowHeader">does List want to contain default header statement [SELECT]?</param>
        /// <returns>Master Name List With Primarykey</returns>
        public DataTable Get_Master_Name_List(string MASTER_NAME, Boolean isAllowHeader = false, string whereCodition = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ((isAllowHeader) ? " SELECT '0' SYS_ID, '[SELECT]' DISPLAY_NAME UNION ALL \r\n" : "") +
                              " SELECT SYS_ID ,NAME DISPLAY_NAME \r\n" +
                              " FROM MASTER_TABLE \r\n" +
                              " WHERE TYPE=@TYPE AND ISDELETED <> 1";
            cmd.Parameters.AddWithValue("@TYPE", MASTER_NAME);


            if (GuruConvert.AsString(whereCodition) != string.Empty)
            {
                cmd.CommandText += " AND " + whereCodition + " ";
            }

            return GetDataTable(cmd);
        }
        public DataTable Get_Customer_Name_List(string SUBSCRIPTION_ID, Boolean isAllowHeader = false, string whereCodition = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ((isAllowHeader) ? " SELECT '0' SYS_ID, '[SELECT]' DISPLAY_NAME UNION ALL \r\n" : "") +
                              " SELECT MU.SYS_ID, MU.ID  DISPLAY_NAME  \r\n" +
                              " FROM MASTER_CUSTOMER MU \r\n" +
                              " INNER JOIN SUBSCRIPTION SUB ON SUB.SYS_ID = MU.SUBSCRB_SYS_ID \r\n" +
                              " INNER JOIN MASTER_COMPANY MC ON MC.SUBSCRIB_SYS_ID = SUB.SYS_ID AND MC.SYS_ID = MU.COMPANY_SYS_ID \r\n" +
                              "     AND MC.ISDELETED = 'FALSE' \r\n" +
                              " INNER JOIN MASTER_TABLE TYP ON TYP.SYS_ID = MU.TYPE_SYS_ID \r\n" +
                              " WHERE 1=1 AND MU.ISDELETED <> 1 AND TYP.ID = 'Customer' AND TYP.TYPE = 'Cust_Type' AND SUB.SUBSCRIPTION_ID = @SUBSCRIPTION_ID";
            cmd.Parameters.AddWithValue("@SUBSCRIPTION_ID", SUBSCRIPTION_ID);
            if (GuruConvert.AsString(whereCodition) != string.Empty)
            {
                cmd.CommandText += " AND " + whereCodition + " ";
            }

            return GetDataTable(cmd);
        }
        public DataTable Get_Supplier_Name_List(string SUBSCRIPTION_ID, Boolean isAllowHeader = false, string whereCodition = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = ((isAllowHeader) ? " SELECT '0' SYS_ID, '[SELECT]' DISPLAY_NAME UNION ALL \r\n" : "") +
                              " SELECT MU.SYS_ID, MU.ID  DISPLAY_NAME  \r\n" +
                              " FROM MASTER_CUSTOMER MU \r\n" +
                              " INNER JOIN SUBSCRIPTION SUB ON SUB.SYS_ID = MU.SUBSCRB_SYS_ID \r\n" +
                              " INNER JOIN MASTER_COMPANY MC ON MC.SUBSCRIB_SYS_ID = SUB.SYS_ID AND MC.SYS_ID = MU.COMPANY_SYS_ID \r\n" +
                              "     AND MC.ISDELETED = 'FALSE' \r\n" +
                              " INNER JOIN MASTER_TABLE TYP ON TYP.SYS_ID = MU.TYPE_SYS_ID \r\n" +
                              " WHERE 1=1 AND MU.ISDELETED <> 1 AND TYP.ID = 'Supplier' AND TYP.TYPE = 'Cust_Type' AND SUB.SUBSCRIPTION_ID = @SUBSCRIPTION_ID";
            cmd.Parameters.AddWithValue("@SUBSCRIPTION_ID", SUBSCRIPTION_ID);
            if (GuruConvert.AsString(whereCodition) != string.Empty)
            {
                cmd.CommandText += " AND " + whereCodition + " ";
            }

            return GetDataTable(cmd);
        }

        public string Get_Transaction_Id(string Transaction_Name)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT [dbo].[" + Transaction_Name + "](@COMPANY_SYS_ID)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@COMPANY_SYS_ID", _CompanyId);
            return GuruConvert.AsString(ExecuteScalar(cmd));
        }
        #endregion


    }
}
