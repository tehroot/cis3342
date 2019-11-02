using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Utilities;

namespace Utilities {
    public class loginService {
        
        protected static bool addUser(User user) {
            if (checkUser(user.username) == false) {
                try {
                    DBConnect dbConnect = new DBConnect();
                    SqlCommand cmd = new SqlCommand {
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "createNewUser"
                    };
                    cmd.Parameters.AddWithValue("@username", user.username);
                    cmd.Parameters.AddWithValue("@password", user.password);
                    cmd.Parameters.AddWithValue("@adminflag", user.adminflag);
                    cmd.Parameters.AddWithValue("@banflag", user.banflag);
                    cmd.Parameters.AddWithValue("@firstname", user.firstname);
                    cmd.Parameters.AddWithValue("@lastname", user.lastname);
                    cmd.Parameters.AddWithValue("@alternateemail", user.alternateemail);
                    cmd.Parameters.AddWithValue("@avatar", user.avatar);
                    SqlParameter rowsAffected = new SqlParameter("@return", DbType.Int32);
                    rowsAffected.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(rowsAffected);
                    int rowCount = dbConnect.DoUpdateUsingCmdObj(cmd);
                    //int rowCount = int.Parse(cmd.Parameters["@return"].Value.ToString());
                    if (rowCount != -1 && rowCount == 4) {
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
            } else {
                return false;
            }
        }

        protected static bool checkUser(String username) {
            DBConnect dbConnect = new DBConnect();
            SqlCommand cmd = new SqlCommand {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "getAccountByID"
            };
            cmd.Parameters.AddWithValue("@accountID", username);
            DataSet accountIDDataSet = dbConnect.GetDataSetUsingCmdObj(cmd);
            if (accountIDDataSet.Tables[0].Rows.Count == 1) {
                return true;
            } else {
                return false;
            }
        }

        protected static bool checkUserLogin(String username, String password) {
            if (checkUser(username) == true) {
                DBConnect dbConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getAccountPassword"
                };
                cmd.Parameters.AddWithValue("@accountID", username);
                DataSet accountPasswordDataSet = dbConnect.GetDataSetUsingCmdObj(cmd);
                if (accountPasswordDataSet.Tables[0].Rows.Count == 1) {
                    if (accountPasswordDataSet.Tables[0].Rows[0][0].ToString() == password) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        protected static User returnUserInformation(String username) {
            try {
                DBConnect dbConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getUserByInfo"
                };
                cmd.Parameters.AddWithValue("@username", username);
                DataSet userSet = dbConnect.GetDataSetUsingCmdObj(cmd);
                Boolean flag = false;
                if (userSet.Tables[0].Rows[0][4].ToString() == "1") {
                    flag = true;
                }
                User user = new User(userSet.Tables[0].Rows[0][0].ToString(), userSet.Tables[0].Rows[0][1].ToString(), userSet.Tables[0].Rows[0][2].ToString(),
                    userSet.Tables[0].Rows[0][3].ToString(), flag, userSet.Tables[0].Rows[0][5].ToString());
                return user;
            } catch (Exception ex) {
                Debug.WriteLine("Error in SQL, returnUserInfo" + ex.StackTrace);
                return new User();
            }
        }

        protected static Boolean isUserAdmin(String username) {
            try {
                DBConnect dBConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand {
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "checkUserAdmin"
                };
                cmd.Parameters.AddWithValue("@username", username);
                DataSet userSet = dBConnect.GetDataSetUsingCmdObj(cmd);
                if(userSet.Tables[0].Rows.Count > 0) {
                    if (userSet.Tables[0].Rows[0][0].ToString() == username) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } catch(Exception ex) {
                Debug.WriteLine("Error in SQL, adminCheck" + ex.StackTrace);
                return false;
            }
        }
        public static bool checkAdmin(String username) {
            return isUserAdmin(username);
        }

        public static bool login(String username, String password) {
            return checkUserLogin(username, password);
        }

        public static bool checkUsername(String username) {
            return checkUser(username);
        }

        public static bool createUser(User user) {
            return addUser(user);
        }

        public static User returnUser(String username) {
            return returnUserInformation(username);
        }
    }
}