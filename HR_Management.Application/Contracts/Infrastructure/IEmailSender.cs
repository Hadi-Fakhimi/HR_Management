using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HR_Management.Application.Models;

namespace HR_Management.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
