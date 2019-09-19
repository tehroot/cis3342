using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project1 {
    public partial class Quiz_results : System.Web.UI.Page {
        Quiz quiz = new Quiz();

        protected void Page_Init(object sender, EventArgs e) {
            quiz.buildQuizList();
            quiz.buildQuizKey();
        }
        protected void Page_Load(object sender, EventArgs e) {
            StringBuilder stringBuilder = new StringBuilder();
            NameValueCollection request = Request.Form;
            IDictionary<int, Boolean> quizgrade = quiz.gradeQuiz(quiz, request);
            var grade = quiz.scoreQuiz(quizgrade);
            //need to write html responses for the css/classes etc in here in the label text
            //need to append inside the 
            name.Text = Request["firstName"];
            tuid.Text = Request["tuid"];
            score.Text = grade.ToString();
            
            foreach (int i in quiz.questionList.Keys) {
                if (quizgrade[i]) {
                    //c# stringbuilder class for processing here, need to build an extremely large HTML string and render it to the asp label control
                    //in the opposing view, I assume that we need to do a sb.append for each object and then build it to the actual label at the end
                    //needs to be formatted in the row/column design used in the main site in order to be easily buildable
                    String htmlText = "<div class='row'>" +
                                        "<div class='col-25-alternate'>" +
                                            "<div class='image'><img src='/check-mark-yes.svg'/></div><div class='label-col'><label for='question" + i+"'>"+quiz.questionList[i]+""+
                                            "</label></div>" +
                                        "</div>" +
                                        "<div class='col-75-alternate'>" +
                                            "<label for='answer'>Your answer: "+quiz.userQuizAnswers[i]+"</label>" +
                                        "</div>"+
                                      "</div>";
                    stringBuilder.Append(htmlText);
                } else if (!quizgrade[i]) {
                    String htmlText = "<div class='row'>" +
                                        "<div class='col-25-alternate'>" +
                                            "<div class='image'><img src='/error-mark.svg'/></div><div class='label-col'><label for='question"+i+"'>"+quiz.questionList[i]+""+ 
                                            "</label></div>" +
                                        "</div>" +
                                        "<div class='col-75-alternate-wrong'>" +
                                            "<label for='answer'>Your Answer: "+quiz.userQuizAnswers[i]+"</label><label for='right-answer'> Right Answer: "+quiz.questionSet[i]+"" +
                                        "</div>"+
                                      "</div>";
                    stringBuilder.Append(htmlText);
                } else {
                    String htmlText = "<div class='row'>" +
                                        "<div class='col-25-alternate'> " +
                                            "<label>ERROR loading Question" +
                                            "</label>" +
                                        "</div>" +
                                     "</div>";
                    stringBuilder.Append(htmlText);
                }
            }
            label1.Text = stringBuilder.ToString();
        }
    }
}