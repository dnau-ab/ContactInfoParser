using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactInfoParser {
    class Program {
        static void Main(string[] args) {

            // Parser
            BusinessCardParser infoParser = new BusinessCardParser();

            // list of contacts found
            List<ContactInfo> contacts = new List<ContactInfo>();

            String[] testFiles = Directory.GetFiles("../../Tests", "*.txt");

            foreach (String file in testFiles)
            {
                String contents = File.ReadAllText(file);
                contacts.Add(infoParser.getContactInfo(contents));
                Console.WriteLine("Looking for contacts in '" + file + "'");
            }

            // Output the contact information for each read
            foreach (ContactInfo contact in contacts)
            {
                Console.WriteLine("Name: " + contact.getName());
                Console.WriteLine("Phone: " + contact.getPhoneNumber());
                Console.WriteLine("Email: " + contact.getEmailAddress() + "\n");
            }

        }
    }
}
