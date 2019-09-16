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
        Quiz quiz = new Quiz();

        protected void Page_Init(object sender, EventArgs e) {
            quiz.buildQuizKey();

        }
        protected void Page_Load(object sender, EventArgs e) {
            NameValueCollection request = Request.Form;
            IDictionary<int, Boolean> score = quiz.gradeQuiz(quiz, request);
            label1.Text = "test";
        }
    }
}