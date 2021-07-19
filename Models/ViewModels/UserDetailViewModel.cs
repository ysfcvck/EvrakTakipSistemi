using EvrakTakipSistemi.Models.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakipSistemi.Models.ViewModels
{
    public class UserDetailViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        public static implicit operator AppUser(UserDetailViewModel userDetail)
        {
            return new AppUser
            {
                UserName = userDetail.UserName,
                Email = userDetail.Email,
                PhoneNumber = userDetail.PhoneNumber
            };
        }
    }
}
