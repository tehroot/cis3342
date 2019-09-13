using System;
using System.Collections;
namespace Project1 {
    public class Quiz {

        public int student_id { get; set; }
        public String student_name { get; set; }
        public ArrayList questionList { get; set; }

        public Quiz() {
            
        }

        public Quiz(String student_name, int student_id ) {
            this.student_id = student_id;
            this.student_name = student_name;
            
        }
    }
}
