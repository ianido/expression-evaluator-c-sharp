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
using System.Globalization;
using System.Threading;

namespace org.matheval.Functions
{
    /// <summary>
    /// Return the position of a specific character or substring within a text string (case sensitive)
    /// FIND("a","ABCDabcABCabc") -> 5
    /// FIND("ab","ABCDabcABCabc",6) -> 11
    /// </summary>
    public class findFunction : IFunction
    {
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>FunctionDefs</returns>
        public List<FunctionDef> GetInfo()
        {
            return new List<FunctionDef>{
                       new FunctionDef(Afe_Common.Const_Find, new System.Type[]{ typeof(string), typeof(string), typeof(decimal) }, typeof(decimal), 3),
                       new FunctionDef(Afe_Common.Const_Find, new System.Type[] { typeof(string), typeof(string) }, typeof(decimal), 2)};
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="args">args</param>
        /// <param name="dc">dc</param>
        /// <returns>Value</returns>
        public object? Execute(Dictionary<string, object?> args, ExpressionContext dc)
        {
            int pos = Find(args, dc);
            return pos >= 0 ? pos + 1 : pos;
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="args">args</param>
        /// <returns>Index find</returns>
        public int Find(Dictionary<string, object?> args, ExpressionContext dc)
        {
            int result;
            // because IndexOf uses the current culture info for string comparison
            var ci = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = dc.WorkingCulture ?? ci;
            if (args.Count == 2)
            {
                result = Afe_Common.ToString(args[Afe_Common.Const_Key_Two], dc.WorkingCulture).IndexOf(Afe_Common.ToString(args[Afe_Common.Const_Key_One], dc.WorkingCulture));
            }
            else
            {
                result = Afe_Common.ToString(args[Afe_Common.Const_Key_Two], dc.WorkingCulture).IndexOf(Afe_Common.ToString(args[Afe_Common.Const_Key_One], dc.WorkingCulture), decimal.ToInt32(Afe_Common.ToDecimal(args[Afe_Common.Const_Key_Three], dc.WorkingCulture)) - 1);
            }

            Thread.CurrentThread.CurrentCulture = ci;
            return result;
        }
    }
}
