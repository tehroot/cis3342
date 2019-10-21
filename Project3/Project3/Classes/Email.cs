using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3.Classes {
    public class Email {
        private String _email_id { get; set; }
        private String _email_sender { get; set; }
        private String _email_recipient { get; set; }
        private String _email_content { get; set; }
        private String _email_subject { get; set; }
        private Boolean _email_flag { get; set; }

        public String email_id {
            get { return _email_id; }
            set {
                if (value != null && value != "") {
                    _email_id = value;
                } else {
                    //change exception type
                    throw new ArgumentException("Email ID cannot be blank.");
                }

            }
        }
        public String email_sender {
            get { return _email_sender; }
            set {
                if (value != null && value != "") {
                    _email_sender = value;
                } else {
                    throw new ArgumentException("Email Sender cannot be blank.");
                }
            }
        }
        public String email_recipient {
            get { return _email_recipient; }
            set {
                if (value != null && value != "") {
                    _email_recipient = value;
                } else {
                    throw new ArgumentException("Email Recipient cannot be blank.");
                }

            }
        }

        public String email_content { get { return _email_content; }
            set {
                if (value != null) {
                    _email_content = value;
                } else {
                    //change exception type, null not allowed
                    throw new ArgumentException("Null content not allowed, error");
                }
            }
        }
        public String email_subject { get { return _email_subject; }
            set {
                if (value != null && value != "") {
                    _email_subject = value;
                } else {
                    throw new ArgumentException("Email Subject cannot be blank.");
                }
            }
        }
        public Boolean email_flag { get { return _email_flag; }
            set {
                _email_flag = value;    
            }
        }
    }
}