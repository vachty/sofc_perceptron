using Network.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Models
{
    public class WeightModel
    {
        public WeightModel() 
        {
            Weight = Weight.GetRandomNumber(0,10);
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public double Weight { get; set; }
    }
}
