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
using System.Collections.Generic;

namespace org.matheval.Functions
{
    /// <summary>
    /// Returns a new string of a specified length in which the beginning of the current string is padded with spaces or with a specified Unicode character.
    /// For Example:
    /// lpad("abc",5,"*") => **abc
    /// lpad("abc",2,"*") => abc
    /// </summary>
    public class lpadFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{new FunctionDef(Afe_Common.Const_LPAD, new System.Type[]{ typeof(string), typeof(decimal), typeof(string)}, typeof(string), 3)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public object? Execute(Dictionary<string, object?> args, ExpressionContext dc)
        {
            return LeftPad(Afe_Common.ToString(args[Afe_Common.Const_Key_One], dc.WorkingCulture), decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Two], dc.WorkingCulture)), Afe_Common.ToString(args[Afe_Common.Const_Key_Three], dc.WorkingCulture));
        }

        /// <summary>
        /// Formula LeftPad
        /// </summary>
        /// <param name="stringValue">stringValue</param>
        /// <param name="length">length</param>
        /// <param name="padString">padString</param>
        /// <returns>Value LeftPad</returns>
        private string LeftPad(string stringValue, int length, string padString)
        {
            if (!string.IsNullOrEmpty(stringValue) && string.IsNullOrEmpty(padString))
            {
                return stringValue;
            }
            else if (!string.IsNullOrEmpty(padString))
            {
                return stringValue.PadLeft(length, char.Parse(padString));
            }
            return string.Empty;
        }
    }
}
