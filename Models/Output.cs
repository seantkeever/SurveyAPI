using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyAPI.Models
{
    public class Output
    {
        public Output(bool success, List<OutputVariable> outputvariables)
        {
            this.success = success;
            this.outputvariables = outputvariables;
        }
        public bool success { get; set; }
        public List<OutputVariable> outputvariables { get; set; }


        public class OutputVariable
        {
            public OutputVariable(string name, string value)
            {
                this.name = name;
                this.value = value;
            }
            public string name { get; set; }
            public string value { get; set; }
        }
    }
}
