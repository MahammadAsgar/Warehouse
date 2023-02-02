using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Business.Services.Abstractions.User
{
    public interface IMailService
    {
        Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true);
        Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
        Task SendPasswordResetMail(string to, string userName, string resetToken);
        Task SendEmailConfirmMail(string to, string userName, string confirmToken);
    }
}
