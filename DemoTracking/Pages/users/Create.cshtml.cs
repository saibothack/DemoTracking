using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DemoTracking.Areas.Identity.Data;
using DemoTracking.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace DemoTracking.Pages_users
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ILogger<CreateModel> _logger;
        private readonly DemoTrackingContext _context;
        private string _role;

        public CreateModel(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<CreateModel> logger,
            DemoTrackingContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;

            /*var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);*/
        }

        public IActionResult OnGet()
        {
            var enumValues = Enum.GetValues(typeof(UserStatus)).Cast<UserStatus>().Select(e => new { Value = e.ToString(), Text = e.ToString() }).ToList();
            ViewData["UserStatus"] = new SelectList(enumValues, "Value", "Text", "");

            ViewData["RoleID"] = new SelectList(_roleManager.Roles, "Id", "Name");
            ViewData["CompanyID"] = new SelectList(_context.Company, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Rol")]
            public string RoleID { get; set; }

            [Required]
            [Display(Name = "Empresa")]
            public string CompanyID { get; set; }

            [Required]
            [Display(Name = "Nombre")]
            [DataType(DataType.Text)]
            public string Name { get; set; }

            [Required]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Nombre de usuario")]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "Teléfono")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña")]
            [Compare("Password", ErrorMessage = "Las constraseñas no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "Estatus")]
            public UserStatus Status { get; set; }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Input.RoleID.Equals("0"))
            {
                return Page();
            }

            if (Input.CompanyID.Equals("0"))
            {
                return Page();
            }

            var user = new User
            {
                CompanyID = Input.CompanyID,
                Name = Input.Name,
                UserName = Input.UserName,
                Email = Input.Email,
                PhoneNumber = Input.PhoneNumber,
                Status = Input.Status
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                Role role = await _roleManager.FindByIdAsync(Input.RoleID);
                await _userManager.AddToRoleAsync(user, role.Name);
                _logger.LogInformation("User created a new account with password.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToPage("./Index");
        }
    }
}