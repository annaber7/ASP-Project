using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data; 

namespace ProjectOneASP
{
    public class clsDatabase
    {
        private static SqlConnection AcquireConnection()
        {
            SqlConnection cnSQL = null;
            Boolean blnErrorOccurred = false;
            if(ConfigurationManager.ConnectionStrings["ServiceCenter"] != null)
            {
                cnSQL = new SqlConnection();
                cnSQL.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceCenter"].ToString();
                try
                {
                    cnSQL.Open();
                }
                catch(Exception ex)
                {
                    blnErrorOccurred = true;
                    cnSQL.Dispose();
                }

            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return cnSQL; 
            }
        }

        ///Get TechnicianList()
        ///
        public static DataSet GetTechnicianList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode;
            cnSQL = AcquireConnection();

            if(cnSQL == null)
            {
                return null;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetTechnicianList";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue; 
                
                try
                {
                    dsSQL = new DataSet();
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch(Exception ex)
                {
                    blnErrorOccurred = true;
                    dsSQL.Dispose();

                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL; 
            }
        }

        //GetTechnicianByID

        public static DataSet GetTechnicianByID(int intTechID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL; 
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;
            
            if(intTechID > 0)
            {
                cnSQL = AcquireConnection();
                if(cnSQL == null)
                {
                    blnErrorOccurred = true; 
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetTechnicianByID";

                    cmdSQL.Parameters.Clear();
                    cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.NVarChar, 10));
                    cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@TechnicianID"].Value = intTechID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet(); 
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch
                    {
                        blnErrorOccurred = true;
                        daSQL = null; 
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                }
            }
            if (blnErrorOccurred)
            {
                return null; 
            }
            else
            {
                return dsSQL; 
            }
        }

        ///InsertTechnician()
        ///
        public static Int32 InsertTechnician(String strFName, string strLName, string strMName, string strEMail, string strDepartment, string strTelephone, string strRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection(); 
            if (cnSQL == null)
            {
                blnErrorOccurred = true; 
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if(string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMName;
                }
                

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEMail;
                }
                

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDepartment;
                }
                

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strTelephone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strRate;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTechnicianID"].Direction = ParameterDirection.Output;
                

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery(); 
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;

                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        ///DeleteTechnician()
        ///
        public static int DeleteTechnician(int intTechID)
        {
            SqlConnection cnSQL = null;
            SqlCommand cmdSQL = null; 
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();


            if (cnSQL == null)
            {
                blnErrorOccurred = true;  ;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspDeleteTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue; 
                
                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();

                }
                catch(Exception ex)
                {
                    blnErrorOccurred = true; 
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose(); 
                }



            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0; 
            }
            
        }
        ///UpdateTechnician()
        ///
        public static Int32 UpdateTechnician(int intTechID, String strFName, string strLName, string strMName, string strEMail, string strDepartment, string strTelephone, string strRate)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspUpdateTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@FName", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@FName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@FName"].Value = strFName;

                cmdSQL.Parameters.Add(new SqlParameter("@LName", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@LName"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@LName"].Value = strLName;

                cmdSQL.Parameters.Add(new SqlParameter("@MInit", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@MInit"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@MInit"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@MInit"].Value = strMName;
                }
                

                cmdSQL.Parameters.Add(new SqlParameter("@EMail", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@EMail"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@EMail"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@EMail"].Value = strEMail;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Dept", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Dept"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(strMName))
                {
                    cmdSQL.Parameters["@Dept"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Dept"].Value = strDepartment;
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strTelephone;

                cmdSQL.Parameters.Add(new SqlParameter("@HRate", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@HRate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@HRate"].Value = strRate;

                cmdSQL.Parameters.Add(new SqlParameter("@TechnicianID", SqlDbType.Int));
                cmdSQL.Parameters["@TechnicianID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechnicianID"].Value = intTechID; 


                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;

                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        //InsertServiceEvent()
        public static int InsertServiceEvent(int intClientID, DateTime dtEventDate, string strPhone, string strContact)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;
            int intNewTicketID = 0; 

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertServiceEvent";

                cmdSQL.Parameters.Add(new SqlParameter("@ClientID", SqlDbType.Int));
                cmdSQL.Parameters["@ClientID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ClientID"].Value = intClientID;

                cmdSQL.Parameters.Add(new SqlParameter("@EventDate", SqlDbType.DateTime));
                cmdSQL.Parameters["@EventDate"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@EventDate"].Value = dtEventDate;

                cmdSQL.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@Phone"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Phone"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@Contact", SqlDbType.NVarChar, 30));
                cmdSQL.Parameters["@Contact"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@Contact"].Value = strPhone;

                cmdSQL.Parameters.Add(new SqlParameter("@NewTicketID", SqlDbType.Int));
                cmdSQL.Parameters["@NewTicketID"].Direction = ParameterDirection.Output;

                cmdSQL.Parameters.Add(new SqlParameter("@Errcode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue; 
                
                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)

                {
                    blnErrorOccurred = true;

                }
                finally
                {
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
                if (!blnErrorOccurred)
                {
                    if (cmdSQL.Parameters["@NewTicketID"].Value != DBNull.Value)
                    {
                        if (int.TryParse(cmdSQL.Parameters["@NewTicketID"].Value.ToString(), out intNewTicketID))
                        {
                            blnErrorOccurred = true;
                        }
                    }
                }
                cmdSQL.Parameters.Clear();
                cmdSQL.Dispose();
            }
            if (!blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return intNewTicketID; 
            }
           
            
        }
        
            
        public static DataSet GetClientList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

    
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetClientList";

   

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch
                    {
                        blnErrorOccurred = true;
                        daSQL = null;
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                }
            
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
        public static Int32 InsertProblem(Int32 intTicketID, Int32 intIncidentNo, string strProbDesc, Int32 intTechID, string strProductID )
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertProblem";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TicketID"].Value = intTicketID;

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@IncidentNo"].Value = intIncidentNo;

                cmdSQL.Parameters.Add(new SqlParameter("@ProbDesc", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@ProbDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProbDesc"].Value = strProbDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar, 10));
                cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ProductID"].Value = strProductID;

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;

                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static DataSet GetOpenProblems()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspGetOpenProblems";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }
        
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
     
        }
        public static DataSet GetProductByID(string strProductID)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            if (!string.IsNullOrWhiteSpace(strProductID))
            {
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetProductByID";

                    cmdSQL.Parameters.Clear();
                    cmdSQL.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.NVarChar,10));
                    cmdSQL.Parameters["@ProductID"].Direction = ParameterDirection.Input;
                    cmdSQL.Parameters["@ProductID"].Value = strProductID;

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch
                    {
                        blnErrorOccurred = true;
                        daSQL = null;
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                }
            }
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
        public static int InsertResolution(string intTicketID, string intIncidentNo, string intResNo, string strResDesc, string dtDateFix, string dtDateOnsite, int intTechID, string decHours, string decMileage, string decCostMiles, string decSupplies, string decMisc, string intNoCharge)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            Boolean blnErrorOccurred = false;
            Int32 intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspInsertResolution";

                cmdSQL.Parameters.Add(new SqlParameter("@TicketID", SqlDbType.Int));
                cmdSQL.Parameters["@TicketID"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(intTicketID))
                {
                    cmdSQL.Parameters["@TicketID"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@TicketID"].Value = Convert.ToInt32(intTicketID); 
                }

                cmdSQL.Parameters.Add(new SqlParameter("@IncidentNo", SqlDbType.Int));
                cmdSQL.Parameters["@IncidentNo"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(intIncidentNo))
                {
                    cmdSQL.Parameters["@IncidentNo"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@IncidentNo"].Value = Convert.ToInt32(intIncidentNo);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@ResNo", SqlDbType.Int));
                cmdSQL.Parameters["@ResNo"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(intResNo))
                {
                    cmdSQL.Parameters["@ResNo"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@ResNo"].Value = Convert.ToInt32(intResNo);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@ResDesc", SqlDbType.NVarChar, 500));
                cmdSQL.Parameters["@ResDesc"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@ResDesc"].Value = strResDesc;

                cmdSQL.Parameters.Add(new SqlParameter("@DateFix", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateFix"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(dtDateFix))
                {
                    cmdSQL.Parameters["@DateFix"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateFix"].Value = Convert.ToDateTime(dtDateFix);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@DateOnsite", SqlDbType.DateTime));
                cmdSQL.Parameters["@DateOnsite"].Direction = ParameterDirection.Input;
                if(string.IsNullOrWhiteSpace(dtDateOnsite))
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@DateOnsite"].Value = Convert.ToDateTime(dtDateOnsite);
                }
                

                cmdSQL.Parameters.Add(new SqlParameter("@TechID", SqlDbType.Int));
                cmdSQL.Parameters["@TechID"].Direction = ParameterDirection.Input;
                cmdSQL.Parameters["@TechID"].Value = intTechID;

                cmdSQL.Parameters.Add(new SqlParameter("@Hours", SqlDbType.Decimal));
                cmdSQL.Parameters["@Hours"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decHours))
                {
                    cmdSQL.Parameters["@Hours"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Hours"].Value = Convert.ToDecimal(decHours);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Mileage", SqlDbType.Decimal));
                cmdSQL.Parameters["@Mileage"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decMileage))
                {
                    cmdSQL.Parameters["@Mileage"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Mileage"].Value = Convert.ToDecimal(decMileage);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@CostMiles", SqlDbType.Decimal));
                cmdSQL.Parameters["@CostMiles"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decCostMiles))
                {
                    cmdSQL.Parameters["@CostMiles"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@CostMIles"].Value = Convert.ToDecimal(decCostMiles);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@Supplies", SqlDbType.Decimal));
                cmdSQL.Parameters["@Supplies"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decSupplies))
                {
                    cmdSQL.Parameters["@Supplies"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Supplies"].Value = Convert.ToDecimal(decSupplies);
                };

                cmdSQL.Parameters.Add(new SqlParameter("@Misc", SqlDbType.Decimal));
                cmdSQL.Parameters["@Misc"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(decMisc))
                {
                    cmdSQL.Parameters["@Misc"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@Misc"].Value = Convert.ToDecimal(decMisc);
                }

                cmdSQL.Parameters.Add(new SqlParameter("@NoCharge", SqlDbType.Int));
                cmdSQL.Parameters["@NoCharge"].Direction = ParameterDirection.Input;
                if (string.IsNullOrWhiteSpace(intNoCharge))
                {
                    cmdSQL.Parameters["@NoCharge"].Value = DBNull.Value;
                }
                else
                {
                    cmdSQL.Parameters["@NoCharge"].Value = Convert.ToDecimal(intNoCharge);
                }

                try
                {
                    intRetCode = cmdSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    blnErrorOccurred = true;

                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }
            }
            if (blnErrorOccurred)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public static DataSet GetProductList()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

     
                cnSQL = AcquireConnection();
                if (cnSQL == null)
                {
                    blnErrorOccurred = true;
                }
                else
                {
                    cmdSQL = new SqlCommand();
                    cmdSQL.Connection = cnSQL;
                    cmdSQL.CommandType = CommandType.StoredProcedure;
                    cmdSQL.CommandText = "uspGetProductList";

  

                    cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                    cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                    dsSQL = new DataSet();
                    try
                    {
                        daSQL = new SqlDataAdapter(cmdSQL);
                        intRetCode = daSQL.Fill(dsSQL);
                        daSQL.Dispose();
                    }
                    catch
                    {
                        blnErrorOccurred = true;
                        daSQL = null;
                    }
                    finally
                    {
                        cmdSQL.Parameters.Clear();
                        cmdSQL.Dispose();
                        cnSQL.Close();
                        cnSQL.Dispose();
                    }

                }
            
            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }
        }
        public static DataSet ProblemsByInstitution()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspProblemsByInstitution";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }

        }
        public static DataSet ProblemsByClient()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspProblemsByClient";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }

        }
        public static DataSet ProblemsByTechnician()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspProblemsByTechnician";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }

        }
        public static DataSet ProblemsByProduct()
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = "uspProblemsByProduct";

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }

        }
        public static DataSet GetReport(string strReportSP)
        {
            SqlConnection cnSQL;
            SqlCommand cmdSQL;
            SqlDataAdapter daSQL;
            DataSet dsSQL = null;
            Boolean blnErrorOccurred = false;
            int intRetCode = 0;

            cnSQL = AcquireConnection();
            if (cnSQL == null)
            {
                blnErrorOccurred = true;
            }
            else
            {
                cmdSQL = new SqlCommand();
                cmdSQL.Connection = cnSQL;
                cmdSQL.CommandType = CommandType.StoredProcedure;
                cmdSQL.CommandText = strReportSP;

                cmdSQL.Parameters.Add(new SqlParameter("@ErrCode", SqlDbType.Int));
                cmdSQL.Parameters["@ErrCode"].Direction = ParameterDirection.ReturnValue;

                dsSQL = new DataSet();
                try
                {
                    daSQL = new SqlDataAdapter(cmdSQL);
                    intRetCode = daSQL.Fill(dsSQL);
                    daSQL.Dispose();
                }
                catch(Exception ex)
                {
                    blnErrorOccurred = true;
                    daSQL = null;
                }
                finally
                {
                    cmdSQL.Parameters.Clear();
                    cmdSQL.Dispose();
                    cnSQL.Close();
                    cnSQL.Dispose();
                }

            }

            if (blnErrorOccurred)
            {
                return null;
            }
            else
            {
                return dsSQL;
            }

        }
    
    }
}