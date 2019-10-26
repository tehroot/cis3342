using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Utilities;

namespace Project3.Classes {
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


    }
}