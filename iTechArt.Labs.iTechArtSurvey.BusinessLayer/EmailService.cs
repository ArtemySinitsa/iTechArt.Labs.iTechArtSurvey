using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace iTechArt.Labs.iTechArtSurvey.BusinessLayer
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
