using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestHelpers
{

    public class UFake : MonoBehaviour
    {
        public class VoidType
        {
        }

        private class Expectation
        {
            public int calledCount = 0;
            public int calledExpect = -1;
            public string methodName = "";
            public object[] parameters;
            public object returns;
        }

        private List<Expectation> expectations;
        private Expectation expectation;

		public UFake()
		{
			expectations = new List<Expectation> ();
		}

        /// <summary>
        /// Set new method expectation.
        /// </summary>
        /// <param name="methodName">method that should be called </param>
        /// <returns>reference to self</returns>
        public UFake Expects (string methodName)
        {
            expectation = new Expectation();

            expectations.Add(expectation);

            expectation.methodName = methodName;

            return this;
        }

        /// <summary>
        /// Set the parameters that should be passed to the fake.
        /// </summary>
        /// <param name="parameters">list of arbitrary parameters</param>
        /// <returns>reference to self</returns>
        public UFake With (params object[] parameters)
        {
            expectation.parameters = parameters;

            return this;
        }

        /// <summary>
        /// Set expectation of how many times method should be called.
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public UFake ToBeCalled (int times = 0)
        {
            expectation.calledExpect = times;

            return this;
        }

        /// <summary>
        /// set the return value for the expectation.
        /// </summary>
        /// <param name="returns"></param>
        /// <returns></returns>
        public UFake AndReturns (object returns)
        {
            expectation.returns = returns;

            expectation = null;

            return this;
        }

        /// <summary>
        /// Check if fake meets the set expectations.
        /// </summary>
        /// <returns>true if expectations are met.</returns>
        public bool MeetsExpectations ()
        {
            bool result = true;

            foreach (Expectation expectation in expectations) {
                if (expectation.calledExpect >= 0 && expectation.calledExpect != expectation.calledCount) {
                    result = false;
                    Debug.Log("Expected method " + expectation.methodName + " to be called " + expectation.calledExpect + " times but called " + expectation.calledCount);
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Call from inside methods in the fake to keep track of which methods were called.
        /// </summary>
        /// <typeparam name="T">return type for method</typeparam>
        /// <param name="methodName">name of method</param>
        /// <param name="parameters">parameters passed to method</param>
        /// <returns>any stored return value</returns>
        public T evaluateMethod<T> (string methodName, params object[] parameters)
        {
            foreach (Expectation expectation in expectations) {
                if (expectation.methodName == methodName) {
                    ++expectation.calledCount;

                    if (expectation.returns != null) {
                        return (T)expectation.returns;
                    }

                    break;
                }
            }

            return default(T);
        }

        /// <summary>
        /// Call from inside method in the fake to keep track of which methods were called.
        /// </summary>
        /// <param name="methodName">name of method</param>
        /// <param name="parameters">parameters passed to method</param>
        public void evaluateMethod (string methodName, params object[] parameters)
        {
            foreach (Expectation expectation in expectations) {
                if (expectation.methodName == methodName) {
                    ++expectation.calledCount;
                    break;
                }
            }
        }

        /// <summary>
        /// Reset the fake.
        /// </summary>
        public void Done ()
        {
            expectations.Clear();
        }
    }
}
