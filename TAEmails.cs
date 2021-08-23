using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GDCTechnicalAssignment{
    public class TAEmails{
        #region Declarations
        private List<String> goodEmailList;
        private List<String> badEmailList;
        private ITAWriter writer;
        #endregion

        #region Constructor
        public TAEmails(ITAWriter writer){
            goodEmailList = new List<String>{};
            badEmailList = new List<String>{};
            this.writer = writer;
        }
        #endregion

        #region methods
        /// <summary>Iterates through each given value and checks that it is a valid email address, then assigns to the appropriate list if it was valid or not.</summary>
        public void ProcessEmails(List<String> emails){
            foreach(String item in emails){
                if(IsValidEmail(item)){
                    goodEmailList.Add(item);
                }else{
                    badEmailList.Add(item);
                }
            }
            
        }

        /// <summary>Outputs the emails found in the good and bad email lists to the console.</summary>
        public void ShowEmails(){
            writer.Write(Strings.GOODEMAILS);
            foreach(String item in GetGoodEmails()){
                writer.Write($"\t{item}");
            }                    
            writer.Write(Strings.BADEMAILS);
            foreach(String item in GetBadEmails()){
                writer.Write($"\t{item}");
            }
        }

        /// <summary>Uses regex to determine if the email address is valid. Note: this is only a basic verification process and sending test emails is the best way to verify an email address.</summary>
        public static bool IsValidEmail(String email)
        {
            if (String.IsNullOrEmpty(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        #endregion


        #region GettersSetters        
        /// <summary>Returns a List of Strings containing the good emails that have been so far determined and added.</summary>
        public List<String> GetGoodEmails(){
            return goodEmailList;
        }

        /// <summary>Returns a List of Strings containing the bad emails that have been so far determined and added.</summary>
        public List<String> GetBadEmails(){
            return badEmailList;
        }
        #endregion
    }
}