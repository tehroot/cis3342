﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Web;
namespace Project1 {
    public class Quiz {
        //quiz has one attribute, a questionlist assembled from a loaded file located in the base project directory.
        public Dictionary<int, String> questionSet { get; set; }
        public Dictionary<int, String> questionList { get; set; }
        public IDictionary<String, String> userAnswers { get; set; }
        public IDictionary<int, String> userQuizAnswers { get; set; }


        public Quiz() {
            
        }

        //build the list of questions from a file stored in the application bin directory(contextualized for ASP.NET operating directory
        public void buildQuizList() {
            questionList = new Dictionary<int, string>();
            String filePath = HttpContext.Current.Request.PhysicalApplicationPath + "/questions.txt";
            List<String> fileRead = new List<String>(File.ReadAllLines(filePath));
            foreach (String s in fileRead) {
                String[] splitStrings = s.Split(new[] { ',' }, 2);
                questionList.Add(int.Parse(splitStrings[0]), splitStrings[1].TrimEnd('\\'));
            }
        }

        //build the asnwer key from a file stored in the application bin directory(contextualized for ASP.net operating directory
        public void buildQuizKey() {
            questionSet = new Dictionary<int, string>();
            String filePath = HttpContext.Current.Request.PhysicalApplicationPath + "/answers.txt";
            List<String> fileRead = new List<String>(File.ReadAllLines(filePath));
            foreach (String s in fileRead) {
                String[] splitStrings = s.Split(new[] { ',' }, 2);
                questionSet.Add(int.Parse(splitStrings[0]), splitStrings[1].TrimEnd('\\'));
            }
        }

        //sets the quiz object property to the values required in the aspx processing for display
        public void processUserAnswers(Quiz quiz, NameValueCollection nameValueCollection) {
            foreach (String s in nameValueCollection.AllKeys) {
                quiz.userAnswers.Add(s, nameValueCollection[s]);
            }

            foreach (String s in nameValueCollection.AllKeys) {
                quiz.userQuizAnswers.Add(int.Parse(s), nameValueCollection[s]);

            }
        }

        //grades the users quiz answers against the answer key and returns a dict of those values in a few configurations
        //for ease of use in the aspx cs page
        public IDictionary<int, Boolean> gradeQuiz(Quiz quiz, NameValueCollection nameValueCollection) {
            IDictionary<String, String> dict = new Dictionary<String, String>();
            IDictionary<int, String> new_dict = new Dictionary<int, String>();
            IDictionary<int, Boolean> big_dict = new Dictionary<int, Boolean>();
            foreach (var k in nameValueCollection.AllKeys) {
                dict.Add(k, nameValueCollection[k]);
            }
            //dict processing
            quiz.userAnswers = dict;
            dict.Remove("firstName");
            dict.Remove("tuid");
            foreach (var k in dict.Keys) {
                new_dict.Add(int.Parse(k), dict[k]);
            }
            quiz.userQuizAnswers = new_dict;
            foreach(int i in new_dict.Keys) {
                if (questionSet[i] == new_dict[i]) {
                    big_dict.Add(i, true);
                } else {
                    big_dict.Add(i, false);
                }
            }
            return big_dict;
        }

        //score the quiz by analyzing the dict storing whether a user answered the question correctly
        public Decimal scoreQuiz(IDictionary<int, Boolean> quizResults) {
            decimal score = 0;
            foreach (int i in quizResults.Keys) {
                if (quizResults[i]) {
                    score++;
                }
            }
            return score / quizResults.Count * 100;
        }
    }
}