using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestHelpers
{

    public class UMethodCall
    {
        public string methodName = "";
        public object[] parameters = new object[0];
        public Type type;

        /// <summary>
        /// Set the parameters that should be passed to the fake.
        /// </summary>
        /// <param name="parameters">list of arbitrary parameters</param>
        /// <returns>reference to self</returns>
        public UMethodCall With(params object[] parameters)
        {
            this.parameters = parameters;

            return this;
        }

        /// <summary>
        /// set the return value for the expectation.
        /// </summary>
        /// <param name="returns"></param>
        /// <returns></returns>
        public T AndReturns<T>()
        {
            // early eval

            return default(T);
        }
    }
}