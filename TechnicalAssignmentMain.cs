using System;
using SimpleInjector;

namespace GDCTechnicalAssignment
{
    class TechnicalAssignmentMain
    {
        private static readonly Container container;

        static void Main(string[] args)
        {
            var container = new Container();

            container.Register<TAFileHandler>();
            container.Register<TAEmails>();
            container.Register<ITAWriter, TAWriter>();

            container.Verify();

            var taFile = container.GetInstance<TAFileHandler>();
            var taEmail = container.GetInstance<TAEmails>();
            var taWriter = container.GetInstance<ITAWriter>();

            //Get a file name from the user and assign it to taFile.
            taFile.SetFileName(PromptUser());

            //Check that the file exists, then process the emails; if all goes well, print the output.
            if(taFile.CheckFileExists()){
                taEmail.ProcessEmails(taFile.ReadFile());
                taEmail.ShowEmails();
            }else{
                Console.WriteLine(Strings.FILENOTFOUND);
            }

            //Done - prompt user to close the app.
            PromptForExit();
        }

        static private String PromptUser(){
            Console.WriteLine(Strings.ENTERFILENAME);
            var name = Console.ReadLine();
            return name;
        }

        static private void PromptForExit(){
            Console.WriteLine(Strings.EXITMESSAGE);
            Console.ReadKey(true);
        }
    }

}
