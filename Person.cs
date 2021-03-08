using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Midterm245;
using Week4_Class1;


namespace Week5_PersonClassinWindows
{

    class Person
    {

       
        private string fName;
        private string mName;
        private string lName;
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string email;
        private string phone;
        private string pause;
        protected string feedback;


        public string FName
        {
            get
            {
                return fName;
            }

            set
            {
                if (value.Length > 0)
                {
                    fName = value;
                }
                else
                {
                    feedback += "\nERROR: First Name cannot be blank";
                }
            }
        }

        public string MName
        {
            get
            {
                return mName;
            }

            set
            {
                mName = value;
            }
        }

        public string LName
        {
            get
            {
                return lName;
            }

            set
            {
                if (value.Length > 0)
                {
                    lName = value;
                }
                else
                {
                    feedback += "\nERROR: Last Name cannot be blank";
                }
            }
        }

        public string Street1
        {
            get
            {
                return street1;
            }

            set
            {
                if (value.Length > 0)
                {
                    street1 = value;
                }
                else
                {
                    feedback += "\nERROR: Street 1 cannot be blank";
                }
            }
        }

        public string Street2
        {
            get
            {
                return street2;
            }

            set
            {
                street2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }

            set
            {
                if (value.Length > 0)
                {
                    city = value;
                }
                else
                {
                    feedback += "\nERROR: City cannot be blank";
                }
            }
        }

        public string State
        {
            get
            {
                return state;
            }

            set
            {
                if (value.Length == 2)
                {
                    state = value;
                }
                else
                {
                    feedback += "\nERROR: State must be 2 letter abbreviation.";
                }
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }

            set
            {
                if (value.Length == 5)
                {
                    zip = value;
                }
                else
                {
                    feedback += "\nERROR: Zip Code must be 5 digits.";
                }

                int intStr; bool intResultTryParse = int.TryParse(value, out intStr);
                if (intResultTryParse == true)
                {
                    zip = value;
                }
                else
                {
                    feedback += "\nERROR: Zip Code must be 5 digits.";
                }
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (value.Length == 10)
                {
                    phone = value;
                }
                else
                {
                    feedback += "\nERROR: Phone Number must be 10 digits.";
                }

                int intStr; bool intResultTryParse = int.TryParse(value, out intStr);
                if (intResultTryParse == true)
                {
                    phone = value;
                }
                else
                {
                    feedback += "\nERROR: Phone Number must be xxxxxxxxxx format.";
                }
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (ValidationLibrary.IsValidEmail(value))
                {
                    email = value;      
                }
                else
                {
                    feedback += "\nERROR: Invalid email."; 
                }
            }
        }

        public string Feedback
        {
            get { return feedback; }        //allows outside code to see feedback
            // Notice there is no SET...This is because only the class can change feedback  
        }

        public Person()
        {
            //Initialize so that there are no nulls, especially feedback
            fName = "";
            mName = "";
            lName = "";
            street1 = "";
            street2 = "";
            city = "";
            state = "";
            zip = "";
            phone = "";
            email = "";
            feedback = "";
        }





    }

}
