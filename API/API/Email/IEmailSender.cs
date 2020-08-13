using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Email
{
    public interface IEmailSender
    {
        // Sends Email with the given information

        Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}
