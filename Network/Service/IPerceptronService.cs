using Network.Models;

namespace Network.Service
{
    public interface IPerceptronService
    {
        double Predict(InputModel inputModel);

        void Train();
    }
}
