using System.Text.RegularExpressions;

class NotificationParser
{
  static void Main()
  {
    Console.WriteLine("Enter the notification channels: ");
    string? input = Console.ReadLine();
    Console.WriteLine(ParseNotificationChannels(input));
  }

  static string ParseNotificationChannels(string? input)
  {
    if (string.IsNullOrEmpty(input))
    {
      return "No valid channels found";
    }

    var validChannels = new HashSet<string> { "BE", "FE", "QA", "Urgent" };
    var matches = Regex.Matches(input, @"\[(.*?)\]");

    var channels = new List<string>();

    foreach (Match match in matches)
    {
      string tag = match.Groups[1].Value;
      if (validChannels.Contains(tag))
      {
        channels.Add(tag);
      }
    }

    return channels.Count > 0 ? $"Receive channels: {string.Join(", ", channels)}" : "No valid channels found";
  }
}
