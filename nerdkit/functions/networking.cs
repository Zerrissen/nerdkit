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
                    // TODO LIST
                    // Get network neighbour information via ARP
                    // Local network port scanning via nmap?
                    // netstat to show current connections
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
