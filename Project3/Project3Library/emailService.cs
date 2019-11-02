using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Utilities;

namespace Utilities {
    public class emailService {

        /*
        protected static String generateEmailId() {
            byte[] randArray = new byte[32];
            Random rnd = new Random();
            rnd.NextBytes(randArray);
            return System.Text.Encoding.UTF8.GetString(randArray, 0, randArray.Length);
        }
        */
        protected static String generateEmailId() {
            string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            String s = "";
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider()) {
                while (s.Length < 15) {
                    byte[] singleByte = new byte[1];
                    provider.GetBytes(singleByte);
                    char character = (char)singleByte[0];
                    if (valid.Contains(character)) {
                        s += character;
                    }
                }
            }
            return s;
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
                if (rowCount != -1 && rowCount == 2) {
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

        protected static DataSet getEmailDataSet(String username, String folder) {
            try {
                DBConnect dbConnect = new DBConnect();
                SqlCommand get_aggregate_dataset = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "mapEmailsandFolders"
                };
                get_aggregate_dataset.Parameters.AddWithValue("@username", username);
                get_aggregate_dataset.Parameters.AddWithValue("@folder_tag", folder);
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
                delete_user_email.Parameters.AddWithValue("@id",id);
                delete_user_email.Parameters.AddWithValue("@username",username);
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
                    Email new_email = new Email(email.Tables[0].Rows[0][0].ToString(), email.Tables[0].Rows[0][1].ToString(),
                        email.Tables[0].Rows[0][2].ToString(), email.Tables[0].Rows[0][3].ToString(), email.Tables[0].Rows[0][4].ToString(),
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

        protected static Boolean updateEmailReportFlag(String id, Boolean flagVal) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand flag_Email = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "updateReportFlag"
                };

                flag_Email.Parameters.AddWithValue("@id", id);
                if (flagVal) {
                    flag_Email.Parameters.AddWithValue("@flag", 1);
                } else {
                    flag_Email.Parameters.AddWithValue("@flag", 0);
                }
                int rowCount = dBConnect.DoUpdateUsingCmdObj(flag_Email);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch(Exception ex) {
                Debug.WriteLine("SQL Errror updateEmailReportFlag" + ex.StackTrace);
                return false;
            }
        }

        protected static Boolean moveEmailFolder(String id, String folder, String username) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand move_email = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "moveEmailToFolder"
                };
                move_email.Parameters.AddWithValue("@id", id);
                move_email.Parameters.AddWithValue("@username", username);
                move_email.Parameters.AddWithValue("@folder_tag", folder);
                int rowCount = dBConnect.DoUpdateUsingCmdObj(move_email);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                Debug.WriteLine("SQL Error moveEmailToFolder" + ex.StackTrace);
                return false;
            }
        }

        protected static Boolean createNewFolder(String username, String folder) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand create_folder = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "createNewFolder"
                };
                create_folder.Parameters.AddWithValue("@username", username);
                create_folder.Parameters.AddWithValue("@folder_tag", folder);
                int rowCount = dBConnect.DoUpdateUsingCmdObj(create_folder);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                Debug.WriteLine("SQL Error createNewFolder" + ex.StackTrace);
                return false;
            }
        }

        protected static DataSet getSearchEmailDataSet(String username, String searchPattern) {
            try {
                DBConnect dbConnect = new DBConnect();
                SqlCommand get_aggregate_dataset = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "searchEmailsWithValue"
                };
                get_aggregate_dataset.Parameters.AddWithValue("@username", username);
                get_aggregate_dataset.Parameters.AddWithValue("@search_term", searchPattern);
                DataSet aggregate_dataset = dbConnect.GetDataSetUsingCmdObj(get_aggregate_dataset);
                return aggregate_dataset;
            } catch (SqlException ex) {
                Debug.WriteLine("SQL error getEmailDataSet" + ex.StackTrace);
                return null;
            }
        }

        protected static DataSet getAllFlaggedEmails() {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand get_flagged_dataset = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "getAllFlaggedEmails"
                };
                DataSet flagged_emails_dataset = dBConnect.GetDataSetUsingCmdObj(get_flagged_dataset);
                return flagged_emails_dataset;
            } catch (SqlException ex) {
                Debug.WriteLine("SQL error GetFlaggedEmails" + ex.StackTrace);
                return null;
            }
        }

        protected static Boolean banUser(String id, Boolean banVal) {
            try {

                DBConnect dBConnect = new DBConnect();
                SqlCommand ban_user = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "banUser"
                };
                int banInt = 0;
                ban_user.Parameters.AddWithValue("@id", id);
                if (banVal == true) {
                    banInt = 1;
                } else {
                    banInt = 0;
                }
                ban_user.Parameters.AddWithValue("@banflag", banInt);
                int rowCount = dBConnect.DoUpdateUsingCmdObj(ban_user);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch (SqlException ex) {
                Debug.WriteLine("Sql exception banUser" +ex.StackTrace);
                return false;
            }
        }

        protected static String returnUserViaEmail(String id) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand return_user_email = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "userByEmailIdSender"
                };
                return_user_email.Parameters.AddWithValue("@id", id);
                DataSet user = dBConnect.GetDataSetUsingCmdObj(return_user_email);
                if (user.Tables[0].Rows.Count == 1) {
                    return user.Tables[0].Rows[0][0].ToString();
                } else {
                    return "";
                }
            } catch(SqlException ex) {
                Debug.WriteLine("SQL Exception returnUserViaEmail" + ex.StackTrace);
                return "";
            }
        }

        protected static Boolean isUserBanned(String username) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand user_banned = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "checkifUserBAnned"
                };
                user_banned.Parameters.AddWithValue("@username",username);
                DataSet banned = dBConnect.GetDataSetUsingCmdObj(user_banned);
                if (banned.Tables[0].Rows.Count == 0) {
                    return true;
                } else {
                    return false;
                }
            } catch(SqlException ex) {
                Debug.WriteLine("SQL Exception isUSerBanned" +ex.StackTrace);
                return false;
            }
        }

        protected static DataSet returnEntireUserList() {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand user_list = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "returnAllUsers"
                };
                DataSet users_set = dBConnect.GetDataSetUsingCmdObj(user_list);
                return users_set;
            } catch (SqlException ex) {
                Debug.WriteLine("SQL Exception returnEntireUserList" +ex.StackTrace);
                return null;
            }
        }

        protected static Boolean unbanUserByUsername(String username, Boolean banVal) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand ban_user = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "banUserByUsername"
                };
                int banInt = 0;
                ban_user.Parameters.AddWithValue("@username", username);
                if (banVal == true) {
                    banInt = 1;
                } else {
                    banInt = 0;
                }
                ban_user.Parameters.AddWithValue("@banflag", banInt);
                int rowCount = dBConnect.DoUpdateUsingCmdObj(ban_user);
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
                    return false;
                }
            } catch (SqlException ex) {
                Debug.WriteLine("Sql exception banUser" + ex.StackTrace);
                return false;
            }
        }

        public static Boolean unbanUser(String username, Boolean banval) {
            return unbanUserByUsername(username, banval);
        }

        public static DataSet returnUsersList() {
            return returnEntireUserList();
        }

        public static String returnUserFromEmailId(String id) {
            return returnUserViaEmail(id);
        }

        public static Boolean userBanned(String username) {
            return isUserBanned(username);
        }

        public static Boolean banUsername(String username, Boolean banVal) {
            return banUser(username, banVal);
        }
        public static DataSet getFlaggedEmails() {
            return getAllFlaggedEmails();
        }

        public static DataSet searchEmailsDataSet(String username, String searchPattern) {
            return getSearchEmailDataSet(username, searchPattern);
        }

        public static Boolean createEmailFolder(String username, String folder) {
            return createNewFolder(username, folder);
        }

        public static Boolean moveEmail(String id, String folder, String username) {
            return moveEmailFolder(id, folder, username);
        }

        public static Boolean flagEmail(String id, Boolean flagVal) {
            return updateEmailReportFlag(id, flagVal);
        }

        public static Boolean createNewEmail(Email email) {
            return createEmail(email);
        }

        public static String getID() {
            return generateEmailId();
        }

        public static Email getEmail(String id) {
            return getEmailById(id);
        }

        public static Boolean deleteEmail(String username, String id) {
            return deleteUserEmail(username, id);
        }

        public static DataSet getEmails(String username, String folder) {
            return getEmailDataSet(username, folder);
        }

        public static List<String> getFolders(String username) {
            return getFolderList(username);
        }

        public static List<String> returnUsersList(String username) {
            return returnValidUserList(username);
        }
    }
}