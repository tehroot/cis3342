using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Utilities;

namespace Utilities {
    public class emailService {

        protected static String generateEmailId() {
            byte[] randArray = new byte[32];
            Random rnd = new Random();
            rnd.NextBytes(randArray);
            return System.Text.Encoding.UTF8.GetString(randArray, 0, randArray.Length);
        }

        protected static Boolean createEmail(Email email) {
            try {
                DBConnect dbConnect = new DBConnect();
                DateTime now = DateTime.Now;
                String ID = generateEmailId();
                //.ToString("yyyy-MM-dd HH:mm:ss.fff);"
                SqlCommand cmd = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "createNewEmail"
                };
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@sender", email.email_sender);
                cmd.Parameters.AddWithValue("@recipient", email.email_recipient);
                cmd.Parameters.AddWithValue("@email_content", email.email_content);
                cmd.Parameters.AddWithValue("@subject", email.email_subject);
                cmd.Parameters.AddWithValue("@timestamp", now);
                int rowCount = dbConnect.DoUpdateUsingCmdObj(cmd);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch (SqlException ex) {
                Debug.WriteLine("SQL Exception in creating an email.");
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        protected static DataSet getEmailDataSet(String username) {
            try {
                DBConnect dbConnect = new DBConnect();
                SqlCommand get_aggregate_dataset = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "mapEmailsandFolders"
                };
                get_aggregate_dataset.Parameters.AddWithValue("@username", username);
                DataSet aggregate_dataset = dbConnect.GetDataSetUsingCmdObj(get_aggregate_dataset);
                return aggregate_dataset;
            } catch (SqlException ex) {
                Debug.WriteLine("SQL error getEmailDataSet" + ex.StackTrace);
                return null;
            }
        }

        protected static List<String> getFolderList(String username) {
            try {
                List<String> folders = new List<String>();
                DBConnect dbConnect = new DBConnect();
                SqlCommand get_folders = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "getAllUserEmailFolders"
                };
                get_folders.Parameters.AddWithValue("@username", username);
                DataSet folderset = dbConnect.GetDataSetUsingCmdObj(get_folders);
                if (folderset.Tables[0].Rows.Count >= 1) {
                    foreach (DataRow x in folderset.Tables[0].Rows) {
                        folders.Add(x["folder_tag"].ToString());
                    }
                    return folders;
                } else {
                    return new List<String>();
                }
            } catch (SqlException ex) {
                Debug.WriteLine("SQL error getFolderList" + ex.StackTrace);
                return new List<String>();
            }
        }

        public static DataSet getEmails(String username) {
            return getEmailDataSet(username);
        }

        public static List<String> getFolders(String username) {
            return getFolderList(username);
        }
    }
}