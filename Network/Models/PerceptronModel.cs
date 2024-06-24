namespace Network.Models
{
    public class PerceptronModel
    {
        public PerceptronModel(InputModel[] inputs, InputModel[] trainningInputs)
        {
            InputModels = inputs.ToList();
            TrainningInputModels = trainningInputs.ToList();

            Weights = new List<WeightModel>();
            UsedWeights = new List<WeightModel>();

            Bias = new BiasModel();

            LearningRate = 0.1;
        }

        public double LearningRate { get; }

        public List<InputModel> InputModels { get; }

        public List<InputModel> TrainningInputModels { get; }

        public int Coeficient { get; set; }

        public List<WeightModel> Weights { get; set; }

        public List<WeightModel> UsedWeights { get; set; }

        public BiasModel Bias { get; set; }
        
    }
}
