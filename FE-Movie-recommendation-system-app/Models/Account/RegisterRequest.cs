using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = ModelConstants.InvalidEmailErrorMessage)]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = ModelConstants.InvalidPasswordLengthErrorMessage)]
        public string Password { get; set; }
}

