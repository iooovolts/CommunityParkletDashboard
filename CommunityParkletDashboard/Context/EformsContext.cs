using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using CommunityParkletDashboard.Models;
using Dapper;

namespace CommunityParkletDashboard.Context
{
    public class EformsContext
    {
        public string sqlTableCPA = ConfigurationManager.AppSettings["liveCPATable"];
        public string sqlTableCPAEmail = ConfigurationManager.AppSettings["liveCPAEmailTable"];
        public string dbConnection = ConfigurationManager.ConnectionStrings["liveSqlConnection"].ToString();

        public List<COMMUNITY_PARKLET_APPLICATION> GetParkletApplications()
        {
            var lApplications = new List<COMMUNITY_PARKLET_APPLICATION>();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"SELECT * FROM {sqlTableCPA}";
                    lApplications = conn.Query<COMMUNITY_PARKLET_APPLICATION>(sql).ToList();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return lApplications;
            }
            return lApplications;
        }

        public List<COMMUNITY_PARKLET_APPLICATION_EMAIL> GetParkletApplicationsEmails()
        {
            var lApplicationEmails = new List<COMMUNITY_PARKLET_APPLICATION_EMAIL>();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"SELECT * FROM {sqlTableCPAEmail}";
                    lApplicationEmails = conn.Query<COMMUNITY_PARKLET_APPLICATION_EMAIL>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return lApplicationEmails;
            }
            return lApplicationEmails;
        }

        public COMMUNITY_PARKLET_APPLICATION EditParkletApplication(int refNumber)
        {
           // var lApplication = new COMMUNITY_PARKLET_APPLICATION();
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"SELECT * FROM {sqlTableCPA} WHERE REF_NUMBER = '{refNumber}'";
                    return conn.Query<COMMUNITY_PARKLET_APPLICATION>(sql).Where(c => c.REF_NUMBER.Equals(refNumber)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                throw ex;
            }

        }

        public bool UpdateParkletApplication(COMMUNITY_PARKLET_APPLICATION cpa, int refNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql =
                        $"UPDATE {sqlTableCPA} SET [NAME] = '{cpa.NAME}', [EMAIL] = '{cpa.EMAIL}', [PHONE] = '{cpa.PHONE}',[NOTES] = '{cpa.NOTES}',[STATUS] = '{cpa.STATUS}', [PARKLET_24HR_CONTACT] = '{cpa.PARKLET_24HR_CONTACT}', [PARKLET_TIME_FRAME] = '{cpa.PARKLET_TIME_FRAME}' WHERE REF_NUMBER = '{refNumber}'";
                    conn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteParkletApplicationEmail(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"DELETE FROM {sqlTableCPAEmail} WHERE ID = {id}";
                    conn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteParkletApplication(int refNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"DELETE FROM {sqlTableCPA} WHERE REF_NUMBER = {refNumber}";
                    conn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool SaveCP(string status, string notes, int refNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(dbConnection))
                {
                    var sql = $"UPDATE {sqlTableCPA} SET STATUS = {status}, NOTES = {notes} WHERE REF_NUMBER = {refNumber}";
                    conn.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"ERROR: " + ex.Message);
                return false;
            }
            return true;
        }
    }
}