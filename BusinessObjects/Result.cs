using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Result
    {
        public int TotalQuestions { get; set; }

        public int Attempted { get; set; }

        public int Skipped { get; set; }

        public int Incorrect { get; set; }

        public double Marks { get; set; }
    }
}
