using ApiDoc.Models;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApiDoc.Controllers
{
  public class Email
  {
    public static IRestResponse SendEmail(string vm)
    {
      //  byte[] bytes = System.Convert.FromBase64String(newNurse.TestDataPdf.Substring(51));
      // var apiKey = Environment.GetEnvironmentVariable("MAIL_GUN");
      RestClient client = new RestClient();
      client.BaseUrl = new Uri("https://api.mailgun.net/v3");
      client.Authenticator =
          new HttpBasicAuthenticator("api", "70cfbc947fe94da8a0278c1fdbc0caf0-9dfbeecd-03160751");
      RestRequest request = new RestRequest();
      request.AddParameter("domain", "sandbox2aacf526a3be40bdb2a96d55126386af.mailgun.org", ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter("from", "<test@sandbox2aacf526a3be40bdb2a96d55126386af.mailgun.org>");
      request.AddParameter("to", $"{vm}");
      request.AddParameter("subject", "appointment has been cancelled");
      request.AddParameter("text", $"this appointment has been cancelled please contact us to reschedule");
      //   request.AddFileBytes("attachment", bytes, $"{newNurse.FirstName} - {newNurse.LastName}", "application/pdf");
      request.Method = Method.POST;
      return client.Execute(request);
    }
  }

}