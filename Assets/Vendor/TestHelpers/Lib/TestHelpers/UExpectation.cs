using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestHelpers
{

    public class UExpectation
    {
        public int calledCount = 0;
        public int calledExpect = -1;
        public string methodName = "";
        public object[] parameters = new object[0];
        public object returns;
        public Type type;
        public Type returnType;

        /// <summary>
        /// Set the parameters that should be passed to the fake.
        /// </summary>
        /// <param name="parameters">list of arbitrary parameters</param>
        /// <returns>reference to self</returns>
        public UExpectation With(params object[] parameters)
        {
            this.parameters = parameters;

            return this;
        }

        /// <summary>
        /// Set expectation of how many times method should be called.
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public UExpectation ToBeCalled(int times = 0)
        {
            this.calledExpect = times;

            return this;
        }

        /// <summary>
        /// set the return value for the expectation.
        /// </summary>
        /// <param name="returns"></param>
        /// <returns></returns>
        public UExpectation AndReturns<T>(T returns)
        {
            this.returns = returns;

            return this;
        }
    }
}