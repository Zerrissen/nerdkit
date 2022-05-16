using Sharprompt;

namespace nerdkit.functions
{
    internal class networking
    {
        public static void menu()
        {
            while (true)
            {
                nerdkit.Title();
                var option = Prompt.Select("Networking Tools", new[] { "NetTest", "Back" });
                switch (option)
                {
                    case "NetTest":
                        assessments.nettest.controller();
                        break;
                    case "Back":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            }
        }
    }
}
