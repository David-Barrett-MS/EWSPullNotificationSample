/*
 * By David Barrett, Microsoft Ltd. 2018-2022. Use at your own risk.  No warranties are given.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 * */

using System;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;

namespace EWSSPullNotificationSample.Auth
{
    public class OAuthHelper
    {
        private static Exception _lastError = null;
        private static IPublicClientApplication _publicClientApplication = null;
        private static IConfidentialClientApplication _confidentialClientApplication = null;
        private static AuthenticationResult _lastAuthResult = null;

        public static Exception LastError
        {
            get { return _lastError; }
        }

        public static async Task<AuthenticationResult> GetDelegateToken(string ClientId, string TenantId, string Scope = "EWS.AccessAsUser.All")
        {
            var pcaOptions = new PublicClientApplicationOptions
            {
                ClientId = ClientId,
                TenantId = TenantId
            };

            var pca = PublicClientApplicationBuilder
                .CreateWithApplicationOptions(pcaOptions);

            pca = pca.WithRedirectUri("http://localhost/code");

            _publicClientApplication = pca.Build();

            var ewsScopes = new string[] { $"https://outlook.office.com/{Scope}" };

            try
            {
                // Make the interactive token request
                _lastAuthResult = await _publicClientApplication.AcquireTokenInteractive(ewsScopes).ExecuteAsync();
                return _lastAuthResult;
            }
            catch (Exception ex)
            {
                _lastError = ex;
            }
            return null;
        }

        public static async Task<AuthenticationResult> RenewToken()
        {
            if (_publicClientApplication != null && _lastAuthResult != null)
            {
                try
                {
                    _lastAuthResult = await _publicClientApplication.AcquireTokenSilent(new string[] { "https://outlook.office.com/.default" }, _lastAuthResult.Account).ExecuteAsync();
                    return _lastAuthResult;
                }
                catch (Exception ex)
                {
                    _lastError = ex;
                }
                return null;
            }

            if (_confidentialClientApplication == null || _lastAuthResult == null)
                return null;

            var ewsScopes = new string[] { "https://outlook.office.com/.default" };
            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                _lastAuthResult = await _confidentialClientApplication.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();
                return _lastAuthResult;
            }
            catch (Exception ex)
            {
                _lastError = ex;
            }
            return null;
        }

        public static async Task<AuthenticationResult> GetApplicationToken(string ClientId, string TenantId, string ClientSecret)
        {
            // Configure the MSAL client to get tokens
            var ewsScopes = new string[] { "https://outlook.office.com/.default" };

            if (_confidentialClientApplication == null)
                _confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                    .WithClientSecret(ClientSecret)
                    .Build();

            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                _lastAuthResult = await _confidentialClientApplication.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();
            }
            catch (Exception ex)
            {
                _lastError = ex;
            }
            return _lastAuthResult;
        }

        public static async Task<AuthenticationResult> GetApplicationToken(string ClientId, string TenantId, X509Certificate2 ClientCertificate)
        {
            // Configure the MSAL client to get tokens
            var ewsScopes = new string[] { "https://outlook.office.com/.default" };

            if (_confidentialClientApplication == null)
                _confidentialClientApplication = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                    .WithCertificate(ClientCertificate)
                    .Build();

            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                _lastAuthResult = await _confidentialClientApplication.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();
            }
            catch (Exception ex)
            {
                _lastError = ex;
            }
            return _lastAuthResult;
        }
    }
}
