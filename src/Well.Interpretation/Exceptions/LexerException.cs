﻿using System;

namespace Well.Interpretation.Exceptions
{
    public class LexerException:Exception
    {
        public LexerException(string token)
            :base($"String '{token}' cannot be converted to any token.")
        {
            Token = token;
        }

        public string Token { get; }
    }
}