using System;
using System.Text.RegularExpressions;

public class InputPattern
{
    public readonly static string accountPattern = @"^([0-9]{11})$";
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

    /// <summary>
    /// Registers the input judge.
    /// </summary>
    /// <returns>返回值0代表账号或密码错误，1代表成功，2代表密码重复错误。</returns>
    public static int RegisterInputJudge(string account, string password, string checkPassword)
    {
        if (!isLegalInput(account, accountPattern))
        {
            return 0;
        }
        if (!isLegalInput(password, passwordPattern))
        {
            return 0;
        }
        if (!password.Equals(checkPassword))
        {
            return 2;
        }
        return 1;
    }
}


