using System;

namespace GDCTechnicalAssignment{
    class TAWriter : ITAWriter{
        /// <summary>Takes the input String parameter and writes it to the console.</summary>
        public void Write(String output){
            Console.WriteLine(output);
        }

    }
}