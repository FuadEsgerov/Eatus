using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Email
{
    public class SendEmailResponse
    {
        public bool Successful => ErrorMsg == null;

        public string ErrorMsg { get; set; }
    }
}
