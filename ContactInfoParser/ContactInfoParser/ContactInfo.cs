using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoParser {
    class ContactInfo {

        private String name;
        private String phone;
        private String email;

        public ContactInfo(String name, String phone, String email){
            this.name = name;
            this.phone = phone;
            this.email = email;
        }

        // Returns the contact's full name: "John Doe", "Bob Ross"
        public String getName() { return name; }

        // Returns the contact's phone number formatted as a sequence of digits
        public String getPhoneNumber() { return phone; }

        // Returns the contact's email address: "email123@gmail.com", "helpdesk@company.net"
        public String getEmailAddress() { return email; }

    }
}
