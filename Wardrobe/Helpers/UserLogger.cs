namespace Wardrobe.Helpers
{
    public class UserLogger
    {
        public static int UserId { get; set; } = 0;
        public static bool IsLogged { get; set; } = false;

        public static string Cookie { get; set; } = "";
    }
}
