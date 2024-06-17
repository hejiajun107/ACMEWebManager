using Certify.ACME.Anvil;
using Certify.ACME.Anvil.Acme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACMEWebManager.Service
{
    public class CertService
    {
        public async Task Gen(GenCertInfo info)
        {
            var acme = new AcmeContext(WellKnownServers.LetsEncryptV2);
            var account = await acme.NewAccount(info.Account, true);
            var pemKey = acme.AccountKey.ToPem();

            var order = await acme.NewOrder(new[] { info.Domain });
            var authz = (await order.Authorizations()).First();
            var dnsChallenge = await authz.Dns();
            var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);

            var result = await dnsChallenge.Validate();
            var privateKey = KeyFactory.NewKey(KeyAlgorithm.RS256);

            while (result.Status != Certify.ACME.Anvil.Acme.Resource.ChallengeStatus.Valid)
            {
                Thread.Sleep(1000);
                result = await dnsChallenge.Validate();
            }

            var cert = await order.Generate(new CsrInfo
            {
                CountryName = info.CountryName,
                State = info.State,
                Locality = info.Locality,
                Organization = info.Organization,
                OrganizationUnit = info.OrganizationUnit,
                CommonName = info.Domain,
            }, privateKey);


            var certPem = cert.ToPem();//.ToPem();
            var certPfx = cert.ToPfx(privateKey).Build("ryine", "www.ryine.com");
       

        }
    }
}
