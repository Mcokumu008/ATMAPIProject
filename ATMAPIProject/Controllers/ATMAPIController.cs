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
            // Validate the credentials
            if (request.header.connectionID != this.ss.AppUser || request.header.connectionPassword != this.ss.AppPass)
            {
                LogError(nameof(ProcessTransactions), "Unauthorized access attempt: Invalid connectionID or connectionPassword");

                return Unauthorized(new
                {
                    statusCode = "401",
                    statusDescription = "The caller is not authorized for this request"
                });
            }

            try
            {
                // Process the transaction asynchronously
                var response = await _client.ProcessTransactionsAsync();

                // Check if the transaction response is null
                if (response == null)
                {
                    LogError(nameof(ProcessTransactions), "Transaction processing failed, response is null.");

                    return StatusCode(500, new
                    {
                        statusCode = "500",
                        statusDescription = "Unable to process the transaction"
                    });
                }

                // Return the successful response with transaction result
                return Ok(new
                {
                    statusCode = "200",
                    statusDescription = "Success",
                    transactionResult = response
                });
            }
            catch (HttpRequestException ex)
            {
                // Handle network or request-specific issues
                LogError(nameof(ProcessTransactions), $"HttpRequestException: {ex.Message}");
                return StatusCode(503, new
                {
                    statusCode = "503",
                    statusDescription = "Service is unavailable. Please try again later."
                });
            }
            catch (TimeoutException ex)
            {
                // Handle timeout issues separately
                LogError(nameof(ProcessTransactions), $"TimeoutException: {ex.Message}");
                return StatusCode(504, new
                {
                    statusCode = "504",
                    statusDescription = "The request timed out. Please try again later."
                });
            }
            catch (Exception ex)
            {
                // Log full exception for debugging
                LogError(nameof(ProcessTransactions), $"Exception: {ex.ToString()}");

                return StatusCode(500, new
                {
                    statusCode = "500",
                    statusDescription = "An error has occurred. Please contact support."
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
                // Try to call the web service asynchronously
                var response = await _client.GetAccountBalanceAsync(request.Account);

                // Check if response indicates account not found (this check depends on your service response)
                if (response == null)
                {
                    return StatusCode(404, new
                    {
                        statusCode = "404",
                        statusDescription = string.Format("Account number-{0} not found", request.Account)
                    });
                }


                // If the account is found, return success
                return Ok(new
                {
                    statusCode = "200",
                    statusDescription = "Success",
                    accountBalance = response
                });
            }
            catch (HttpRequestException ex)
            {
                // Catches network issues, server down, DNS issues, or when endpoint is not found
                if (ex.Message.Contains("404"))
                {
                    return NotFound(new
                    {
                        statusCode = "404",
                        statusDescription = "Endpoint not found"
                    });
                }

                return StatusCode(500, new
                {
                    statusCode = "500",
                    statusDescription = "The server is unreachable. Please try again later."
                });
            }
            catch (TimeoutException)
            {
                // Handle timeouts
                return StatusCode(504, new
                {
                    statusCode = "504",
                    statusDescription = "The request to the server timed out. Please try again later."
                });
            }
            catch (Exception)
            {
                // Handle other unanticipated exceptions
                return StatusCode(500, new
                {
                    statusCode = "500",
                    statusDescription = "server error occurred"
                });
            }


            ////catch (Exception ex)
            ////{
            ////    LogError(nameof(GetAccountBalance), ex.Message);
            ////    return StatusCode(500, new
            ////    {
            ////        statusCode = "500",
            ////        statusDescription = "An error has occurred"
            ////    });
            //}
        }

        private void LogError(string functionName, string errorMessage)
        {
            try
            {
                string path = this.ss.logpath;
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

