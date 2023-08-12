using Microsoft.AspNetCore.Http;

namespace Homework_1.Controllers
{
    public static class StaticDB
    {
        public static List<string> userNames = new List<string>
        {
            "Marko",
            "Sharko",
            "Darko",
            "Tarko",
            "Barko"
        };
    }
}
