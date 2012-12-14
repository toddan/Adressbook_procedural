using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adressbook_procedural
{
    /* 
     * Adressbook_procedural
     * Tord Munk
     * 
     * ABOUT:
     *  Program to demostrate the use of arrays and structs
     *  This program shows a very basic way of using sructs and arrays in C#
     *  It is written in a procedural way inorder to be easly understood by beginners
     *  
     * LICENSE:
     *  Do what you want
     * */

    /*
     * Contact struct.
     * This is the "container" of our contact data.
     * 
     * Take note that the biggest difference between a struct and a class
     * is that a struct can only hold data and can not hold any functions.
     * */
    struct Contact
    {
        public string firstName;
        public string lastName;
        public string adress;
        public string phoneNumber;
    }

    class Program
    {
        /*
         * keep track of the number of contacts inserted in the contact array
         * */
        static int INDEX = 0;

        /*
         * Contact array storing all contacts in memory
         * */
        static Contact[] Contacts = new Contact[10];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"Adress book program" + '\n'
                                + " a - add new contact " + '\n'
                                + " p - print all contacts" + '\n'
                                + " s - search for contact" + '\n');
                Console.Write("Command: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "a":
                        contact_dialog();
                        break;
                    case "p":
                        print_all_contacts();
                        break;
                    case "s":
                        search_for_contacts();
                        break;
                }
            }
        }

        /*
         * new contact dialog when you add a new contact the computer needs
         * to ask the user contact information
         * */
        static void contact_dialog()
        {
            Console.Write("Enter the first name of you contact: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter the last name of you contact: ");
            string lastname = Console.ReadLine();
            Console.Write("Enter the adress of you contact: ");
            string adress = Console.ReadLine();
            Console.Write("Enter the phone number of you contact: ");
            string phonenumber = Console.ReadLine();

            add_contact(create_contact(firstname, lastname, adress, phonenumber));

        }

        /*
         * Allocates a new contact and returns it
         * */
        static Contact create_contact(string firstName, string lastName, string Adress, string phoneNumber)
        {
            Contact new_contact = new Contact();
            new_contact.firstName = firstName;
            new_contact.lastName = lastName;
            new_contact.adress = Adress;
            new_contact.phoneNumber = phoneNumber;
            return new_contact;
        }

        /*
         * Add a new contact to the "database" array
         * incrementing the INDEX variable to keep track of number of contacts
         * */
        static void add_contact(Contact contact)
        {
            Contacts[INDEX++] = contact;
        }

        /*
         * Loops thru the contact array and prints each contact
         * */
        static void print_all_contacts()
        {
            for (int i = 0; i < INDEX; i++)
            {
                print_contact(i);
            }
            Console.ReadKey();
        }

        /*
         * Prints a contact from the contact array
         * using array index as key
         * */
        static void print_contact(int index)
        {
            Console.WriteLine("*********************************************");
            Console.WriteLine("first name: " + Contacts[index].firstName);
            Console.WriteLine("last name: " + Contacts[index].firstName);
            Console.WriteLine("adress: " + Contacts[index].firstName);
            Console.WriteLine("phone number: " + Contacts[index].firstName);
            Console.WriteLine("*********************************************");
        }

        /*
         * Searching a contact for its name
         * */
        static void search_for_contacts()
        {
            Console.Write("enter the name of the contact you want to display: ");
            string name = Console.ReadLine();
            print_contact(look_up_contact(name));
            Console.ReadKey();
        }

        /*
         * Loops thru contacts array and return a contact
         * if name is found. Returns the index of the contact
         * */
        static int look_up_contact(string name)
        {
            for (int i = 0; i < INDEX; i++)
            {
                if (Contacts[i].firstName == name)/* if we find a contact with the right name we return its index */
                {
                    return i;
                }
            }
            return 0; /* if no contact is found we return zero.
                       * 
                       * There is something terrebly wrong with this logic!
                       * Maybe you could figure it out? ;)
                       **/
        }

    }
}
