using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using capstone.DTOs.Signups.Request;
using capstone.DTOs.SignIns.Request;
using capstone.Helpers.Validation;
using Microsoft.Data.SqlClient;
using capstone.Models;
using capstone.DTOs.RestPass;
using Azure.Core;

namespace capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sec1Controller : ControllerBase
    {
        private readonly FoodtekDbContext FooddbContext;
        public sec1Controller(FoodtekDbContext FoodtekDbContext)
        {
            FooddbContext = FoodtekDbContext;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpInputDTO input)
        {

            try
            {
                if (ValidationHelper.IsValidUserName(input.UserName) && ValidationHelper.IsValidEmail(input.Email) && ValidationHelper.IsValidPassword(input.PasswordHash) && ValidationHelper.IsValidFirstName(input.FirstName) && ValidationHelper.IsValidLastName(input.LastName))
                {
                    string connectionString = "Data Source=AHMAD-PC\\SQLEXPRESS;Initial Catalog=FoodtekDB;Integrated Security=True;Trust Server Certificate=True";
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = connection;
                    command.CommandTimeout = 20;
                    command.CommandText = @"INSERT INTO [dbo].[Users]([UserNameHash], [PasswordHash], [Email], [FirstName], [LastName], [Role])VALUES (@UserNameHash, @PasswordHash, @Email, @FirstName, @LastName, @Role)";

                    command.Parameters.AddWithValue("@UserNameHash", input.UserName);
                    command.Parameters.AddWithValue("@PasswordHash", input.PasswordHash);
                    command.Parameters.AddWithValue("@Email", input.Email);
                    command.Parameters.AddWithValue("@FirstName", input.FirstName);
                    command.Parameters.AddWithValue("@LastName", input.LastName);
                    command.Parameters.AddWithValue("@Role", "client");
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return StatusCode(201, "account created");
                    }
                    else
                    {
                        return StatusCode(400, "failed to create account");
                    }


                }
                return StatusCode(400, "failed to create account");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }
        }







        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInInputDTO input)
        {
            try
            {
                if (ValidationHelper.IsValidEmail(input.Email) && ValidationHelper.IsValidPassword(input.Password))
                {
                    string connectionString = "Data Source=AHMAD-PC\\SQLEXPRESS;Initial Catalog=FoodtekDB;Integrated Security=True;Trust Server Certificate=True";
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 20;
                    command.CommandText = @"SELECT COUNT(*) FROM [dbo].[Users] WHERE [Email] = @Email AND [PasswordHash] = @PasswordHash";

                    command.Parameters.AddWithValue("@Email", input.Email);
                    command.Parameters.AddWithValue("@PasswordHash", input.Password);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result > 0)
                    {
                        return Ok("Login successful");
                    }
                    else
                    {
                        return Unauthorized("Invalid email or password");
                    }


                }
                return StatusCode(400, "invalid email or password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }

        }



        [HttpPost("RestRequest")]
        public async Task<IActionResult> RestRequest([FromBody] ResetRequestDTO input)
        {
            try
            {
                var user = FooddbContext.Users.Where(x => x.Email == input.Email).SingleOrDefault();

                if (user != null)
                {
                    var otp = new Random().Next(100000, 999999).ToString();

                    var otpEntry = new Otp
                    {
                        UserId = user.Id,
                        Otpcode = otp,
                        ExpiryDate = DateTime.UtcNow.AddMinutes(10)
                    };
                }
                return NotFound("Email not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }

        }



        [HttpPost("CheckOtp")]
        public async Task<IActionResult> CheckOtp([FromBody] OtpVerificationDto input)
        {
            try
            {
                var otp = FooddbContext.Otps.Where(x=>x.Otpcode==input.Otp).SingleOrDefault();

                if (otp != null && otp.ExpiryDate > DateTime.UtcNow)
                {
                    return Ok("OTP verified.");
                }

                return BadRequest("Invalid or expired OTP.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }

        }
        [HttpPut("NewPassword")]
        public async Task<IActionResult> NewPassword([FromBody] ResetPasswordDto input)
        {
            try
            {
                var user = FooddbContext.Users.Where(x => x.Email == input.Email).SingleOrDefault();
                if (user != null)
                {
                    if (ValidationHelper.IsValidPassword(input.NewPassword))
                    {
                        user.PasswordHash = input.NewPassword;
                    }
                    else
                    {
                        throw new Exception("Invaliad password");
                    }
                    

                }
                return Ok("Password reset successful");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }

        }





    }
}
