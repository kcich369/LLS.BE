using LLS.Domain.Dtos;
using LLS.Domain.ExternalServices;
using LLS.Domain.Results;
using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;

namespace LLS.Infrastructure.ExternalServices;

public sealed class MailjetEmailService(IMailjetClient mailjetClient) : IEmailService
{
    private readonly IMailjetClient _mailjetClient = mailjetClient;

    public async Task<IResult<bool>> Send(EmailData emailData)
    {
        var email = new TransactionalEmailBuilder()
            .WithFrom(new SendContact(emailData.From))
            .WithSubject(emailData.Subject)
            .WithHtmlPart(emailData.HtmlMessage)
            .WithTo(new SendContact(emailData.To))
            .WithBcc(emailData.Bccs.Select(x => new SendContact(x)))
            .Build();

        var response = await _mailjetClient.SendTransactionalEmailAsync(email);
        return Result<bool>.Success(true);
    }
}