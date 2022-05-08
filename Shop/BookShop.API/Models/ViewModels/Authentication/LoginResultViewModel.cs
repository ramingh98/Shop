namespace BookShop.API.Models.ViewModels.Authentication
{
    public class LoginResultViewModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}