using ATMAPIProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ATMAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMAPIController : ControllerBase
    {
        private readonly ATMAPI.ATMAPI_PortClient _client;
        private readonly ServerSettings ss = new ServerSettings();

        public ATMAPIController(ATMAPI.ATMAPI_PortClient client)
        {
            _client = client;
            ss.Getsettings("settings.txt");
        }

        [HttpPost("ProcessTransactions")]
        public async Task<ActionResult> ProcessTransactions([FromBody] ProcessTransactionsRequest request)
        {
            if (request.header.connectionID != this.ss.AppUser || request.header.connectionPassword != this.ss.AppPass)
            {
                return Unauthorized(new
                {
                    statusCode = "401",
                    statusDescription = "The caller is not authorized for this request"
                });
            }

            try
            {
                var response = await _client.ProcessTransactionsAsync();
                return Ok(new
                {
                    statusCode = "200",
                    statusDescription = "Success"
                });
            }
            catch (EndpointNotFoundException)
            {
                return NotFound(new
                {
                    statusCode = "404",
                    statusDescription = "Endpoint not found"
                });
            }
            catch (Exception ex)
            {
                LogError(nameof(ProcessTransactions), ex.Message);
                return StatusCode(500, new
                {
                    statusCode = "500",
                    statusDescription = "An error has occurred"
                });
            }
        }

        [HttpPost("GetAccountBalance")]
        public async Task<ActionResult> GetAccountBalance([FromBody] GetAccountBalanceRequest request)
        {
            if (request.header.connectionID != this.ss.AppUser || request.header.connectionPassword != this.ss.AppPass)
            {
                return Unauthorized(new
                {
                    statusCode = "401",
                    statusDescription = "The caller is not authorized for this request"
                });
            }

            try
            {
                var response = await _client.GetAccountBalanceAsync(request.Account);
                return Ok(new
                {
                    statusCode = "200",
                    statusDescription = "Success"
                });
            }
            catch (EndpointNotFoundException)
            {
                return NotFound(new
                {
                    statusCode = "404",
                    statusDescription = string.Format("Account number-{0} not found", request.Account)
                });
            }
            catch (Exception ex)
            {
                LogError(nameof(GetAccountBalance), ex.Message);
                return StatusCode(500, new
                {
                    statusCode = "500",
                    statusDescription = "An error has occurred"
                });
            }
        }

        private void LogError(string functionName, string errorMessage)
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "logs");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string logFile = Path.Combine(path, $"{DateTime.Now:yyyy-MMM-dd}.txt");
                string logMessage = $"{DateTime.Now:yyyy-MMM-dd HH:mm:ss} - {functionName} - {errorMessage}{Environment.NewLine}";
                System.IO.File.AppendAllText(logFile, logMessage);
            }
            catch
            {
                // Handle any errors that occur during logging
            }
        }
    }
}

