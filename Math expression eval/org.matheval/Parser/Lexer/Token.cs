﻿/*
    The MIT License

    Copyright (c) 2021 MathEval.org

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/
using org.matheval.Common;
using System;
using static org.matheval.Common.Afe_Common;

namespace org.matheval
{
    public class Token
    {
        #region Declare

        /// <summary>
        /// TokenType Value
        /// </summary>
        public TokenType Type { get; set; }

        /// <summary>
        /// String Value
        /// </summary>
        public string? IdentifierValue { get; set; }

        /// <summary>
        /// Double Value
        /// </summary>
        public decimal DoubleValue { get; set; }

        /// <summary>
        /// Number Value
        /// </summary>
        public int NumberValue { get; set; }

        /// <summary>
        /// Bool Value
        /// </summary>
        public bool BoolValue { get; set; }

        #endregion

        #region "Contructor"

        /// <summary>
        /// Initializes a new instance
        /// </summary>
        public Token() { }

        /// <summary>
        /// Initializes a new instance structure to a specified type token value
        /// </summary>
        /// <param name="type">Type token</param>
        public Token(TokenType type)
        {
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type token value and string value
        /// </summary>
        /// <param name="tokType">type</param>
        /// <param name="identifier">identifier</param>
        public Token(TokenType type, string identifier)
        {
            Type = type;
            IdentifierValue = identifier;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type token value and decimal value
        /// </summary>
        /// <param name="tokType">tokType</param>
        /// <param name="identifier">doubleValue</param>
        public Token(TokenType tokType, decimal doubleValue)
        {
            Type = tokType;
            DoubleValue = doubleValue;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type token value and int value
        /// </summary>
        /// <param name="tokType">tokType</param>
        /// <param name="numVal">number</param>
        public Token(TokenType tokType, int number)
        {
            Type = tokType;
            NumberValue = number;
        }

        /// <summary>
        /// Initializes a new instance structure to a specified type token value and Boolean value
        /// </summary>
        /// <param name="tokType">tokType</param>
        /// <param name="numVal">boolVal</param>
        public Token(TokenType tokType, bool boolVal)
        {
            Type = tokType;
            BoolValue = boolVal;
        }

        #endregion

        #region Function

        /// <summary>
        /// Compare to value input
        /// </summary>
        /// <param name="compareTo"></param>
        /// <returns>int value</returns>
        public int CompareTo(object compareTo)
        {
            Token compareToEmp = (Token)compareTo;
            if (Type == TokenType.TOKEN_EOF
                && compareToEmp.Type == TokenType.TOKEN_EOF) return 0;

            if (Type == TokenType.TOKEN_PAREN_OPEN
                && compareToEmp.Type == TokenType.TOKEN_PAREN_OPEN) return 0;

            if (Type == TokenType.TOKEN_PAREN_CLOSE
                && compareToEmp.Type == TokenType.TOKEN_PAREN_CLOSE) return 0;

            if (Type == TokenType.TOKEN_COMMA
                && compareToEmp.Type == TokenType.TOKEN_COMMA) return 0;

            if (Type == TokenType.TOKEN_IDENTIFIER
                && compareToEmp.Type == TokenType.TOKEN_IDENTIFIER)
            {
                return string.Compare(IdentifierValue, compareToEmp.IdentifierValue);
            }
            if (Type == TokenType.TOKEN_ASCII
                && compareToEmp.Type == TokenType.TOKEN_ASCII)
            {
                return string.Compare(IdentifierValue, compareToEmp.IdentifierValue);
            }
            return -1;
        }

        /// <summary>
        /// Convert value to string
        /// </summary>
        /// <returns>string value</returns>
        public override string ToString()
        {

            if (Type == TokenType.TOKEN_EOF)
            {
                return Afe_Common.Const_EOF;
            }
            else if (Type == TokenType.TOKEN_IDENTIFIER || Type == TokenType.TOKEN_ASCII)
            {
                return IdentifierValue!; //Null Assert: Should never be null with these token types
            }
            else if (Type == TokenType.TOKEN_NUMBER_DECIMAL)
            {
                return DoubleValue.ToString();
            }
            else if (Type == TokenType.TOKEN_BOOL)
            {
                return BoolValue.ToString();
            }
            else if (Type == TokenType.TOKEN_PAREN_OPEN)
            {
                return char.ToString(Afe_Common.Const_BRACKETS_OPEN);
            }
            else if (Type == TokenType.TOKEN_PAREN_CLOSE)
            {
                return char.ToString(Afe_Common.Const_BRACKETS_CLOSE);
            }
            else if (Type == TokenType.TOKEN_COMMA)
            {
                return char.ToString(Afe_Common.Const_COMMA);
            }
            else if (Type == TokenType.TOKEN_OP)
            {
                return IdentifierValue!; //Null Assert: Should never be null with these token types
            }
            else if (Type == TokenType.TOKEN_UOP)
            {
                return IdentifierValue!; //Null Assert: Should never be null with these token types
            }
            else if (Type == TokenType.TOKEN_IF)
            {
                return Afe_Common.Const_IF;
            }
            else if (Type == TokenType.TOKEN_CASE)
            {
                return Afe_Common.Const_CASE;
            }
            return string.Empty;
        }
        #endregion
    }
}
