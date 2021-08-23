using System;
using System.IO;
using System.Collections.Generic;

namespace GDCTechnicalAssignment
{
    class TAFileHandler
    {
        #region Declarations
        private String fileName;
        #endregion

        #region Constructor
        public TAFileHandler(){
            SetFileName(String.Empty);
        }        
        #endregion

        #region Methods
        /// <summary>Reads the file given to the object and returns the values.</summary>
        public List<String> ReadFile(){
            List<String> items = new List<String>();

            using(var reader = new StreamReader(GetFileName()))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(Strings.COMMA);
                    
                    //CSV contains names - we do not need this data; ignore it; grab value at index 2.
                    items.Add(values[2]);
                }
                reader.Close();
            }

            return items;
        }

        /// <summary>Verifies that a filname given by the user exists in the filesystem.</summary>
        public bool CheckFileExists(){
            if(File.Exists(GetFileName())){
                return true;
            }else if(File.Exists(GetFileName()+".csv")){
                SetFileName(GetFileName()+".csv");
                return true;
            }else{
                return false;
            }
        }
        #endregion

        #region GettersSetters
        /// <summary>Returns the fileName.</summary>
        public String GetFileName(){
            return fileName;
        }

        /// <summary>Sets the fileName.</summary>
        public void SetFileName(String x){
            fileName = x;
        }
        #endregion
    }
}
