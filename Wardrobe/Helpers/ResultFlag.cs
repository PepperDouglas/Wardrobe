namespace Wardrobe.Helpers
{
    public class ResultFlag
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResultFlag(bool success, string message) {
            Success = success;
            Message = message;
        }

        public ResultFlag(bool success) {
            Success = success;
        }

        public ResultFlag() {

        }
    }
}
