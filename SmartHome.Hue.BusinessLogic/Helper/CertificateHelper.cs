using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Hue.BusinessLogic.Helper
{
    internal static class CertificateHelper
    {
        internal static bool CheckSslCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                   System.Security.Cryptography.X509Certificates.X509Chain chain,
                   System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            var startTime = DateTime.Parse(certificate.GetEffectiveDateString());
            var endTime = DateTime.Parse(certificate.GetExpirationDateString());
            if (startTime <= DateTime.Now && endTime >= DateTime.Now && certificate.Issuer.Contains("Philips Hue"))
            {
                return true;

            }

            else
            {
                return false;
            }
        }
    }
}
