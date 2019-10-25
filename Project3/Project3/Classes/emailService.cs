using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        protected static Boolean createEmail(String Sender, String Recipient, String Content, String Subject) {
            DBConnect dbConnect = new DBConnect();
            DateTime now = DateTime.Now;
            String ID = generateEmailId();
            //.ToString("yyyy-MM-dd HH:mm:ss.fff);"
            Email email = new Email(ID, Sender, Recipient, Content, Subject, now);
            SqlCommand cmd = new SqlCommand {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "createNewEmail"
            };

        }
    }
}