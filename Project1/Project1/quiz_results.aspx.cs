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
            //need to write html responses for the css/classes etc in here in the label text
            //need to append inside the 
            label1.Text = "test";
            foreach (int i in quiz.questionList.Keys) {
                if (score[i]) {
                    //c# stringbuilder class for processing here, need to build an extremely large HTML string and render it to the asp label control
                    //in the opposing view, I assume that we need to do a sb.append for each object and then build it to the actual label at the end
                    //needs to be formatted in the row/column design used in the main site in order to be easily buildable
                } else if (!score[i]) {
                    
                } else {

                }
            }
        }
    }
}