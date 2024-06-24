using Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Service
{
    public class PerceptronService : IPerceptronService
    {
        private PerceptronModel perceptron;

        public PerceptronService(PerceptronModel perceptron) 
        {
            this.perceptron = perceptron;
        }

        public double Predict(InputModel inputModel)
        {
            return Calculate(inputModel);
        }

        public void Train()
        {
            var counter = 0;

            do
            {
                for (int i = 0; i < perceptron.TrainningInputModels.Count; i++)
                {
                    var prediction = Predict(perceptron.TrainningInputModels[i]);
                    var error = perceptron.TrainningInputModels[i].Result - prediction;

                    if (error != 0)
                    {
                        foreach (var inputValue in perceptron.TrainningInputModels[i].InputValues)
                        {
                            var weight = perceptron.Weights.Find(x => x.Id == inputValue.Weight.Id);
                            weight.Weight += perceptron.LearningRate * (double)error * inputValue.Value;

                            inputValue.Weight.Weight += perceptron.LearningRate * (double)error * inputValue.Value;
                        }

                        perceptron.Bias.Bias += perceptron.LearningRate * (double)error;
                    }
                    else
                    {
                        perceptron.TrainningInputModels.Remove(perceptron.TrainningInputModels[i]);
                    }
                }

            } while (perceptron.TrainningInputModels.Any());
        }

        private double ActivateFunction(double x)
        {
            return x >= 0 ? 1 : 0;
        }

        private double Calculate(InputModel inputModel)
        {
            double result = 0;

            foreach (var inputValue in inputModel.InputValues)
            {
                if (!perceptron.TrainningInputModels.Any())
                {
                    for (var i = 0; i < perceptron.Weights.Count; i++)
                    {
                        var weight = perceptron.Weights[i];
                        if (!perceptron.UsedWeights.Any(x => x.Id.Equals(weight.Id)))
                        {
                            perceptron.UsedWeights.Add(weight);
                            inputValue.Weight = perceptron.Weights[0];

                            break;
                        }
                    }
                }
                if (inputValue.Weight == null)
                {
                    var weight = new WeightModel();
                    perceptron.Weights.Add(weight);

                    inputValue.Weight = weight;
                }

                result += inputValue.Value * inputValue.Weight.Weight;
            }

            result += perceptron.Bias.Bias;

            return ActivateFunction(result);
        }
    }
}
