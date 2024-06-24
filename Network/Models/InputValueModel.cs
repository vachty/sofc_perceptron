using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    public class InputValueModel
    {
        public InputValueModel(double value) 
        {
            this.Value = value;
        }

        public double Value { get; }

        public WeightModel Weight { get; set; }
    }
}
