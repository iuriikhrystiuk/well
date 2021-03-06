﻿using System.Text.RegularExpressions;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Constant
{
    public class ConstantTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^\d+(\.\d+){0,1}$");

        protected override IToken Create(string input)
        {
            return new ConstantToken(input);
        }
    }
}