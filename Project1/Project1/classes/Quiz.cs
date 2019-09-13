using System;
using System.Collections;
namespace Project1 {
    public class Quiz {

        public int student_id { get; set; }
        public String student_name { get; set; }
        public int question_num { get; set; }
        public string question_answer { get; set; }

        public Quiz() {
            question_num = 0;
            question_answer = "";
        }

        public Quiz(int question_num, String question_answer, String student_name, int student_id) {
            this.student_id = student_id;
            this.student_name = student_name;
            this.question_num = question_num;
            this.question_answer = question_answer;
        }
    }
}
