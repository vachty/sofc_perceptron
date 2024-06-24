using Network.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Service
{
    public interface IEmailService
    {
        List<string> EmailsToVocabulary(string[] emailMessages);

        InputModel EmailToInputs(string email, List<string> vocabulary);
    }
}
