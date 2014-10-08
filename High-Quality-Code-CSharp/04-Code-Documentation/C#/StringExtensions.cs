﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Extension methods for the <see cref="System.String"/> class.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Generate Md5 Hash form given string
    /// </summary>
    /// <param name="input">String that will be computed to hash.</param>
    /// <returns>The hash of the string.</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Convert string to  <see cref="System.Boolean"/>
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>If string is "true", "ok", "yes", "1", "да" return true</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Try to converst string to <see cref="System.Int16"/>.
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>The string value as <see cref="System.Int16"/></returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Try to converst string to <see cref="System.Int32"/>.
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>The string value as <see cref="System.Int32"/></returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Try to converst string to <see cref="System.Int64"/>.
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>The string value as <see cref="System.Int64"/></returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Try to converst string to <see cref="System.DateTime"/>.
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>The string value as <see cref="System.DateTime"/></returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Converts first latter of string to Uppercase
    /// </summary>
    /// <param name="input">The string to convert.</param>
    /// <returns>Input string with first latter converted to uppercase.</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Get substring between two <paramref name="startString"/> and <paramref name="endString"/>
    /// </summary>
    /// <param name="input">Main string</param>
    /// <param name="startString">Starting string</param>
    /// <param name="endString">Ending string</param>
    /// <param name="startFrom">Start position of the search (default 0)</param>
    /// <returns>The found substring</returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition =
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Convert Cyrillic to Latin Letters using Phonetic Traditional standart
    /// </summary>
    /// <param name="input">String to convert</param>
    /// <returns>String to Latian</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
    {
        "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
        "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
    };
        var latinRepresentationsOfBulgarianLetters = new[]
    {
        "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
        "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
        "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
    };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Convert Latin to Cyrillic Letters using Phonetic Traditional standart
    /// </summary>
    /// <param name="input">String to convert.</param>
    /// <returns>String to Cyrillic</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
    {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
        "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
    };

        var bulgarianRepresentationOfLatinKeyboard = new[]
    {
        "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
        "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
        "в", "ь", "ъ", "з"
    };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Convert the Cyrillic letters to Latin using Traditional Phonetic
    /// and remove all non-alphanumeric characters exept numbers,  ',' '\' and '_'
    /// </summary>
    /// <param name="input">String to change</param>
    /// <returns>Valid username string</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Convert the Cyrillic letters to Latin using Traditional Phonetic,
    /// replace all spaces with '_' and and remove all non-alphanumeric characters exept
    /// numbers, '_', '\', '-'
    /// </summary>
    /// <param name="input">String to chage</param>
    /// <returns>Valid filename string</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Get the first characters form a string
    /// </summary>
    /// <param name="input">The given string</param>
    /// <param name="charsCount">32-signed integer that shows the number of first characters to be selected</param>
    /// <returns>Substring with the first characters</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Get file extension of a file name
    /// </summary>
    /// <param name="fileName">String that represents a file name</param>
    /// <returns>String with file extension from file name. If file name is invalid returns empty string</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Get the type of a file extension
    /// </summary>
    /// <param name="fileExtension">File extension as a string</param>
    /// <returns>The content type of file extension. If file extension not fount 
    /// returns "application/octet-stream"
    /// </returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
    {
        { "jpg", "image/jpeg" },
        { "jpeg", "image/jpeg" },
        { "png", "image/x-png" },
        { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { "doc", "application/msword" },
        { "pdf", "application/pdf" },
        { "txt", "text/plain" },
        { "rtf", "application/rtf" }
    };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Get decimal number of a each character in the  ASCII table 
    /// </summary>
    /// <param name="input">String to convert</param>
    /// <returns>Returns string converted to byte array</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}

