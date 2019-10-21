using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project3.Classes {
    public class User {
        private String _username { get; set; }
        private String _password { get; set; }
        private Boolean _adminFlag { get; set; }
        private Boolean _banFlag { get; set; }

        public String username { get { return _username; }
            set {
                if (value != null && value != "") {
                    _username = value;
                } else {
                    throw new ArgumentException("Username cannot be blank.");
                }
            }
        }
        public String password { get { return _password; }
            set {
                if (value != null && value != "") {
                    _password = value;
                } else {
                    throw new ArgumentException("Password cannot be blank.");
                }
            }
        }
        public Boolean adminFlag { get { return _adminFlag; }
            set {
                _adminFlag = value;
            }
        }
        public Boolean banFlag { get { return _banFlag; }
            set {
                _banFlag = value;
            }
        }
    }
}