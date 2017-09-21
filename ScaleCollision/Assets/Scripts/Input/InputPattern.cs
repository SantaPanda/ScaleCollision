using System;
using System.Text.RegularExpressions;

public class InputPattern
{
    public readonly static string accountPattern = @"^([0-9]|[A-z]){4,10}$";
    public readonly static string passwordPattern = @"^([0-9]|[A-z]){4,10}$";
    
    public InputPattern()
    {
    }

    public static bool isLegalInput(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }

    public static bool LoginInputJudge(string account, string password)
    {
        if (!isLegalInput(account, accountPattern))
        {
            return false;
        }
        if (!isLegalInput(password, passwordPattern))
        {
            return false;
        }
        return true;
    }

    public static bool RegisterInputJudge(string account, string password, string checkPassword)
    {
        if (!isLegalInput(account, accountPattern))
        {
            return false;
        }
        if (!isLegalInput(password, passwordPattern))
        {
            return false;
        }
        if (!password.Equals(checkPassword))
        {
            return false;
        }
        return true;
    }
}


