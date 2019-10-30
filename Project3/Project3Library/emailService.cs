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

        protected static Boolean deleteUserEmail(String username, String id) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand delete_user_email = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "deleteUserSideEmail"
                };
                delete_user_email.Parameters.AddWithValue("@id",username);
                delete_user_email.Parameters.AddWithValue("@username",id);
                int rowCount = dBConnect.DoUpdateUsingCmdObj(delete_user_email);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch(SqlException ex) {
                Debug.WriteLine("SQL error deleteUserSideEmail" + ex.StackTrace);
                return false;
            }
        }

        protected static Email getEmailById(String id) {
            try {
                DBConnect dbConnect = new DBConnect();
                SqlCommand get_email = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "getEmailByID"
                };
                get_email.Parameters.AddWithValue("@id", id);
                DataSet email = dbConnect.GetDataSetUsingCmdObj(get_email);
                if (email.Tables[0].Rows.Count == 1) {
                    Email new_email = new Email(email.Tables[0].Rows[0][0].ToString(), email.Tables[0].Rows[0][1].ToString(), email.Tables[0].Rows[0][2].ToString(),
                        email.Tables[0].Rows[0][3].ToString(), email.Tables[0].Rows[0][4].ToString(),
                        DateTime.Parse(email.Tables[0].Rows[0][6].ToString()));
                    return new_email;
                } else {
                    return null;
                }
            } catch (Exception ex) when (ex is SqlException || ex is FormatException) {
                Debug.WriteLine("SQL error getEmailById" + ex.StackTrace);
                return null;
            }
        }

        protected static List<String> returnValidUserList(String username) {
            try {
                List<String> usernames = new List<String>();
                DBConnect dBConnect = new DBConnect();
                SqlCommand get_users = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "getAllEmailableUsers"
                };
                get_users.Parameters.AddWithValue("@username", username);
                DataSet userSet = dBConnect.GetDataSetUsingCmdObj(get_users);
                if(userSet.Tables[0].Rows.Count >= 1) {
                    foreach (DataRow x in userSet.Tables[0].Rows) {
                        usernames.Add(x["username"].ToString() + "@fmail.io");
                    }
                    return usernames;
                } else {
                    return new List<String>();
                }
            } catch (Exception ex) when (ex is SqlException) {
                Debug.WriteLine("SQL Error returnValidUserList" + ex.StackTrace);
                return new List<String>();
            }
        }

        public static Email getEmail(String id) {
            return getEmailById(id);
        }

        public static Boolean deleteEmail(String username, String id) {
            return deleteUserEmail(username, id);
        }

        public static DataSet getEmails(String username) {
            return getEmailDataSet(username);
        }

        public static List<String> getFolders(String username) {
            return getFolderList(username);
        }
    }
}