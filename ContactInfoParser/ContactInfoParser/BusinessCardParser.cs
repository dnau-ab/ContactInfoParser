using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInfoParser {
    class BusinessCardParser {

        public ContactInfo getContactInfo(String document) {

            return new ContactInfo("", "", "");
        }

        // Returns full name found in given input or empty string
        private String findName(String input) {

            return String.Empty;
        }

        // Returns a phone number found in the given input or empty string
        private String findPhoneNumber(String input) {

            return String.Empty;
        }

        // Returns an email found in the given input or empty string
        private String findEmailAddress(String input) {

            return String.Empty;
        }

    }
}
