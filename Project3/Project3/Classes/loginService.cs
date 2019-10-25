using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utilities;

namespace Project3.Classes {
    public class loginService {
        

        protected static bool addUser(User user) {
            if (checkUser(user.username) == false) {
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
                dbConnect.GetDataSetUsingCmdObj(cmd);
                int rowCount = int.Parse(cmd.Parameters["@return"].Value.ToString());
                if (rowCount != -1 && rowCount == 1) {
                    return true;
                } else {
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

        protected static User returnUserInformation(String username, String password) {
            if (checkUserLogin(username, password)) {
                DBConnect dbConnect = new DBConnect();
                SqlCommand cmd = new SqlCommand {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "getUserByInfo"
                };
                cmd.Parameters.AddWithValue("@accountID", username);
                DataSet userSet = dbConnect.GetDataSetUsingCmdObj(cmd);
                User user = new User(userSet.Tables[0].Rows[0][0].ToString(), userSet.Tables[0].Rows[0][1].ToString(), 
                    bool.Parse(userSet.Tables[0].Rows[0][2].ToString()), bool.Parse(userSet.Tables[0].Rows[0][3].ToString()), 
                    userSet.Tables[0].Rows[0][4].ToString(), userSet.Tables[0].Rows[0][5].ToString(), 
                    userSet.Tables[0].Rows[0][6].ToString(), userSet.Tables[0].Rows[0][7].ToString());
                return user;
            } else {
                return null;
            }
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
    }
}