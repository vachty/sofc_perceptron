using Email.Service;
using Network.Models;
using Network.Service;

namespace Perceptron
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] emails = {
            "Predplatne na pornhub zdarma sleva",
            "Produktova porada v 10",
            "Sleva na kradene kokosy",
            "Pisu email ohledna porady v praci",
            "V praci bude porada",
            "Meeting v praci"};

            IEmailService emailService = new EmailService();
            var vocabulary = emailService.EmailsToVocabulary(emails);

            var trainningModels = emails
            .Select(email => emailService.EmailToInputs(email, vocabulary))
            .ToArray();

            trainningModels[0].Result = 1;
            trainningModels[1].Result = 0;
            trainningModels[2].Result = 1;
            trainningModels[3].Result = 0;
            trainningModels[4].Result = 0;
            trainningModels[5].Result = 0;

            string[] actualEmails = {
            "Dulezita porada dnes",
            "Prace na zitra",
            "Sleva na kradene veci",
            "Predplatne na xoyo"};

            var actualModels = actualEmails
            .Select(email => emailService.EmailToInputs(email, vocabulary))
            .ToArray();


            var perceptron = new PerceptronModel(actualModels, trainningModels);
            IPerceptronService perceptronService = new PerceptronService(perceptron);

            perceptronService.Train();

            foreach (var email in actualModels)
            {
                var output = perceptronService.Predict(email);
                Console.WriteLine($"Vstup: {string.Join(", ", email)} => Vystup: {(output == 1 ? "Spam" : "Neni spam")}");
            }
        }
    }
}