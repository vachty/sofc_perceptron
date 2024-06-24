using Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Service
{
    public class EmailService : IEmailService
    {
        public List<string> EmailsToVocabulary(string[] emailMsgs)
        {
           return emailMsgs.SelectMany(email => email.Split(' ')).Distinct().ToList();
        }

        public InputModel EmailToInputs(string email, List<string> vocabulary)
        {
            double[] vector = new double[vocabulary.Count];
            string[] words = email.Split(' ');

            for (int i = 0; i < vocabulary.Count; i++)
            {
                vector[i] = words.Count(w => w.Equals(vocabulary[i], StringComparison.OrdinalIgnoreCase));
            }

            var inputValues = PrepareInputValues(vector);
            var inputModel = new InputModel(inputValues);

            return inputModel;
        }
        private List<InputValueModel> PrepareInputValues(double[] values)
        {
            var list = new List<InputValueModel>();

            foreach (var value in values)
            {
                list.Add(new InputValueModel(value));
            }

            return list;
        }

    }
}
