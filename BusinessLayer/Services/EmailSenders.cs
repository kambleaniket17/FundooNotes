﻿// -------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailSender.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator name="Aniket Kamble"/>
// ---------------------------------------------------------------------------------------------------------------------------
namespace BusinessLayer.Services
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public class EmailSenders : IEmailSender
    {
        public Task SendEmailAsync(string Email, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.Host = "smtp.gmail.com";
            client.Port = 587;                 //// setup Smtp authentication    
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("privateuser1199@gmail.com", "private252");
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();
            string fromaddress = "FundooApp<Fundoo@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            msg.To.Add(new MailAddress(Email));

            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;
            client.EnableSsl = true;
            client.Send(msg);
            return Task.FromResult(0);
        }
    }
}