using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    public class InputModel
    {
        public InputModel(List<InputValueModel> inputValues, double? result = null ) 
        {
            InputValues = inputValues;
            Result = result;
        }

        public double? Result { get; set; }

        public List<InputValueModel> InputValues { get; }
    }
}
