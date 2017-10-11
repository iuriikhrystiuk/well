﻿using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Base;

namespace Well.Calculator.Tokens.Variable
{
    public class VariableTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^([a-zA-Z]\w*)$");

        protected override IToken Create(string input)
        {
            return new VariableToken(input);
        }
    }
}