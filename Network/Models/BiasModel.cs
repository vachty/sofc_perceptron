using Network.Extensions;

namespace Network.Models
{
    public class BiasModel
    {
        public BiasModel() 
        {
          Bias = Bias.GetRandomNumber(0,10);
        }

        public double Bias { get; set; }
    }
}
