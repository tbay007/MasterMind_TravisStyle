using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind_TravisStyle.Models
{
    public class MasterMindModel
    {
        /// <summary>
        /// Instantiates random number to the four long values.
        /// The four long values will become a string and will be used for the game
        /// </summary>
        public MasterMindModel() 
        { 
            var randomNumber = new Random();
            this.Number1 = randomNumber.Next(1, 6);
            this.Number2 = randomNumber.Next(1, 6);
            this.Number3 = randomNumber.Next(1, 6);
            this.Number4 = randomNumber.Next(1, 6);

            FullNumber = String.Format("{0}{1}{2}{3}", Number1, Number2, Number3, Number4 );
        }
        public long Number1 { get; set; }
        public long Number2 { get; set; }
        public long Number3 { get; set; }
        public long Number4 { get; set; }

        public string FullNumber { get; set; }
    }
}
