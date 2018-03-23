using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace ContactInfoParser {
    class BusinessCardParser {

        private static HashSet<String> firstNames;
        private static HashSet<String> lastNames;

        // where to look for resources (eg. firstNames.csv, lastNames.csv)
        private String resourceDir = @"..\..\Resources\";

        public BusinessCardParser()
        {
            try
            {
                // if name dictionaries not initialized, init them
                if (firstNames == null)
                    firstNames = new HashSet<String>(File.ReadAllLines(resourceDir + "firstNames.csv"));
                if (lastNames == null)
                    lastNames = new HashSet<String>(File.ReadAllLines(resourceDir + "lastNames.csv"));
            } catch (Exception e)
            {
                // unable to find or open name data files
                if (firstNames == null)
                    Console.WriteLine("Could not find firstNames.csv in resource directory '" + resourceDir + "'");
                if (lastNames == null)
                    Console.WriteLine("Could not find lastNames.csv in resource directory '" + resourceDir + "'");
            }
        }

        public ContactInfo getContactInfo(String document) {

            List<KeyValuePair<String, uint> > names = new List<KeyValuePair<String, uint> >();
            KeyValuePair<String, uint> name = new KeyValuePair<String, uint>(String.Empty, 0);
            String phone = String.Empty;
            String email = String.Empty;

            // check each line for name, email, phone
            String[] lines = document.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                // multiple "names" may be found considering their structure
                // add any possible names to a list to be filtered
                name = findName(lines[i]);
                if (name.Key != String.Empty)
                    names.Add(name);

                // if phone or email have not been found already, search for them
                if (phone == String.Empty)
                    phone = findPhoneNumber(lines[i]);
                if (email == String.Empty)
                    email = findEmailAddress(lines[i]);
            }

            // Filter "names" to find an max scoring name
            foreach (KeyValuePair<String, uint> n in names)
            {
                if (n.Value > name.Value)
                    name = n;
            }

            return new ContactInfo(name.Key, phone, email);
        }

        // Returns pair of full name and score
        // Score is determined by presence in the names sets
            // A name in the last names set is awarded 2 points
            // A name in the first names set is awarded 1 point
            // A name in neither set is awarded 0 points;
        private KeyValuePair<String, uint> findName(String input) {
            Match name = Regex.Match(input, Patterns.name);

            // if there is a potential name, check to see if it is in the dictionary
            if (name.Value != String.Empty)
            {
                String[] fullName = name.Value.Split(' ');
                uint score = 0;
                if (fullName.Length >= 2) { // first [middle?] last
                    // check last name
                    if (lastNames != null && lastNames.Contains(fullName[fullName.Length-1]))
                        score += 2;
                    // check first name
                    if (firstNames != null && firstNames.Contains(fullName[0]))
                        score += 1;

                    return new KeyValuePair<String, uint>( name.Value, score);
                }
                
            }

            // potential name not found
            return new KeyValuePair<String, uint>(String.Empty, 0); ;
        }

        // Returns a phone number found in the given input or empty string
        private String findPhoneNumber(String input)
        {
            input = input.ToLower();
            if (input.Contains("fax"))  // ignore any fax numbers
                return String.Empty;

            // try to find a phone number in the input
            Match phone = Regex.Match(input, Patterns.phone);

            // if a phone number was found, clean it up
            if (phone.Value != String.Empty) {
                // Remove non-digits from phone string
                String filteredPhone = String.Empty;
                foreach (char c in phone.Value)
                {
                    if (char.IsDigit(c))
                        filteredPhone += c;
                }
                return filteredPhone;
            }

            // phone number not found
            return String.Empty;
        }

        // Returns an email found in the given input or empty string
        private String findEmailAddress(String input) {
            Match email = Regex.Match(input, Patterns.email);
            return email.Value;
        }

    }
}
