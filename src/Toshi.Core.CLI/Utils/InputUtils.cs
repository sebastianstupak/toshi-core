namespace Toshi.Core.CLI;

internal static class InputUtils
{
    internal static string InputSecret(string secretName)
    {
        Console.WriteLine($"Enter {secretName}:");

        var secret = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && secret.Length > 0)
            {
                Console.Write("\b \b");
                secret = secret[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                secret += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        return secret;
    }
}
