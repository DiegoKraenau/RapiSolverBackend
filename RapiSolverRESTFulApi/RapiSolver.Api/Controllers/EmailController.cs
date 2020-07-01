using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net.Mail;
using RapiSolver.Core.Entities;

namespace RapiSolver.Api.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        [Route("send-email")]
        public async Task SendEmail([FromBody]Email email)
        {
            MailMessage message = new MailMessage(email.EmailOrigen, email.EmailDestino, email.TituloMensaje, email.Mensaje);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(email.EmailOrigen, email.Contraseña);

                await smtp.SendMailAsync(message);
                await Task.FromResult(0);
            }
        }
    }
}
