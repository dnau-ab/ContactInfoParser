using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ContactInfoParser
{
    class Program
    {
        static void Main(string[] args)
        {

            BusinessCardParser parser = new BusinessCardParser();
            // list of contacts found
            List<ContactInfo> contacts = new List<ContactInfo>();

            // if file given to read
            if (args.Length > 0)
            {
                try {
                    String contents = File.ReadAllText(args[0]);
                    contacts.Add(parser.getContactInfo(contents));

                    Console.WriteLine();

                    // Output the contact information for each read
                    foreach (ContactInfo contact in contacts)
                    {
                        Console.WriteLine("Name: " + contact.getName());
                        Console.WriteLine("Phone: " + contact.getPhoneNumber());
                        Console.WriteLine("Email: " + contact.getEmailAddress() + "\n");
                    }
                } catch(FileNotFoundException e)
                {
                    Console.WriteLine("Could not find file: " + args[0]);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else // no file to read, do tests instead
            {
                // fetch all test file paths from test directory
                String[] testFiles = Directory.GetFiles("../../Tests", "*.txt");

                foreach (String file in testFiles)
                {
                    String contents = File.ReadAllText(file);
                    contacts.Add(parser.getContactInfo(contents));
                    Console.WriteLine("Looking for contacts in '" + file + "'");
                }
                Console.WriteLine();

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
}
