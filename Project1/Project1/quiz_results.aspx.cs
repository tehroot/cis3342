using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1 {
    public partial class Quiz_results : System.Web.UI.Page {

        protected void Page_Init(object sender, EventArgs e) {
            Quiz quiz = new Quiz();
            quiz.buildQuizKey();
            NameValueCollection request = Request.Form;
            IDictionary<int, Boolean> score = quiz.gradeQuiz(quiz, request);

        }
        protected void Page_Load(object sender, EventArgs e) {
            
        }
    }
}