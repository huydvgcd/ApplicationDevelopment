using System.Collections.Generic;
using ApplicationDevelopment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplicationDevelopment.ViewModels
{
    public class AdminViewModel
    {
        public List<ApplicationUser> Users { set; get; } = new List<ApplicationUser>();
        [BindProperty]
        public InputModel Input { get; set; }
        public SelectList RoleSelectList { get; set; }
        

        public class InputModel
        {
            
            public string Role { get; set; }


        }
    }
}