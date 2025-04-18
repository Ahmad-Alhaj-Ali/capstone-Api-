using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using capstone.DTOs.Signups.Request;
using capstone.DTOs.SignIns.Request;
using capstone.Helpers.Validation;
using Microsoft.Data.SqlClient;

namespace capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sec1Controller : ControllerBase
    {
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



        [HttpPut("restpass")]
        public async Task<IActionResult> restpass([FromBody] SignInInputDTO input)
        {
            try
            {




                return StatusCode(400, "failed to create account");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An Error Was Occured {ex.Message}");
            }

        }




  
    }
}
