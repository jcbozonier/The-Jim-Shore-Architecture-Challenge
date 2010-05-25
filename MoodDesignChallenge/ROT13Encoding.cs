﻿using System;

namespace MoodDesignChallenge
{
    public class ROT13Encoding
    {
        public void Encode(string stringToEncode, Func<string, string> resultChannel)
        {
            var result = "";

            foreach (var character in stringToEncode)
            {
                if (character >= 'A' && character <= 'Z' || 
                    character >= 'a' && character <= 'z')
                {
                    result += (char)(character + 13);
                }
                else
                    result += character;
            }

            resultChannel(result);
        
        }
    }
}