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
        private String _firstname { get; set; }
        private String _lastname { get; set; }
        private String _alternateemail { get; set; }
        private String _avatar { get; set; }

        public User(String username, String password, Boolean adminflag, Boolean banflag, String firstname, String lastname, String alternateemail) {
            this.username = username;
            this.password = password;
            this.adminflag = adminflag;
            this.banflag = banflag;
            this.firstname = firstname;
            this.lastname = lastname;
            this.alternateemail = alternateemail;
        }

        public User(String Username, String Password, String Firstname, String Lastname, String Alternateemail, String Avatar) {
            username = Username;
            password = Password;
            this.adminflag = false;
            this.banflag = false;
            this.firstname = Firstname;
            this.lastname = Lastname;
            this.alternateemail = Alternateemail;
            this.avatar = Avatar;
        }

        public String username { get { return _username; }
            set {
                if (value != null && value != "") {
                    if (!loginService.checkUsername(value)) {
                        _username = value;
                    } else {
                        throw new ArgumentException("Username already taken.");
                    }
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
        public Boolean adminflag { get { return _adminFlag; }
            set {
                _adminFlag = value;
            }
        }
        public Boolean banflag { get { return _banFlag; }
            set {
                _banFlag = value;
            }
        }

        public String firstname { get { return _firstname; } set {
                if (value != null && value != "") {
                    _firstname = value;
                } else {
                    throw new ArgumentException("Firstname cannot be blank");
                }
            } 
        }

        public String lastname { get { return _lastname; } set {
                if (value != null && value != "") {
                    _lastname = value;
                } else {
                    throw new ArgumentException("Lastname cannot be blank");
                }
            } 
        }

        public String alternateemail { get { return _alternateemail; } set {
                if (value != null && value != "") {
                    _alternateemail = value;
                } else {
                    throw new ArgumentException("Alternate email cannot be blank");
                }
            } 
        }

        public String avatar { get { return _avatar; } set {
                if (value != null && value != "") {
                    _avatar = value;
                } else {
                    throw new ArgumentException("Avatar is invalid");
                }
            } 
        }
    }
}