// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="chandjriddle">
//   
// </copyright>
// <summary>
//   Main Program
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WascherCom.Auto.CalendarToBlog
{
    using System.Configuration;

    using WascherCom.Auto.CalendarToBlog.DataAccess;

    /// <summary>
    /// Main Program
    /// </summary>
    public class Program
    {
        public Program()
        {
            var reader = new CalendarReader();

            var posts = reader.GetPostableEvents(ConfigurationManager.AppSettings["calenderId"]);
        }

        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            new Program();
        }
    }
}
