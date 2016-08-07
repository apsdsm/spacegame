using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestHelpers
{

    public class UFake : MonoBehaviour
    {
        
        private List<UExpectation> expectations;
        private UExpectation expectation;

        public UFake()
        {
            expectations = new List<UExpectation>();
        }

        public UExpectation Expects(string methodName)
        {
            expectation = new UExpectation();
            expectations.Add(expectation);
            expectation.methodName = methodName;

            return expectation;
        }

        public UExpectation Expects<T>(string methodName)
        {
            expectation = new UExpectation();
            expectations.Add(expectation);
            expectation.methodName = methodName;
            expectation.type = typeof(T);

            return expectation;
        }

        public UMethodCall Call(string methodName)
        {
            UMethodCall methodCall = new UMethodCall();
            methodCall.methodName = methodName;
           
            return methodCall;
        }

        public UMethodCall Call<T>(string methodName)
        {
            UMethodCall methodCall = new UMethodCall();
            methodCall.methodName = methodName;
            methodCall.type = typeof(T);

            return methodCall;
        }

        public bool MeetsExpectations()
        {
            bool result = true;

            foreach (UExpectation expectation in expectations) {
                if (expectation.calledExpect >= 0 && expectation.calledExpect != expectation.calledCount) {
                    result = false;
                    Debug.Log("Expected method " + expectation.methodName + " to be called " + expectation.calledExpect + " times but called " + expectation.calledCount);
                    break;
                }
            }

            return result;
        }

        private UExpectation _evaluate(string methodName, Type type, object[] parameters)
        {
            foreach (UExpectation expectation in expectations) {
                if (expectation.methodName != methodName) {
                    continue;
                }

                if (parameters != null && expectation.parameters.Length != parameters.Length) {
                    continue;
                }

                for (int i = 0; i < expectation.parameters.Length; i++) {
                    if (expectation.parameters[i] != parameters[i]) {
                        continue;
                    }
                }

                if (expectation.type != type) {
                    continue;
                }

                expectation.calledCount++;
                return expectation;
            }

            return null;
        }

        public T Evaluate<T>(UMethodCall methodCall)
        {
            UExpectation expectation = _evaluate(methodCall.methodName, methodCall.type, methodCall.parameters);

            if (expectation != null && expectation.returns != null) {
                Debug.Log(expectation.returns);
                return (T)(expectation.returns);
            }

            return default(T);
        }
           

        public void Evaluate(UMethodCall methodCall)
        {
            UExpectation expectation = _evaluate(methodCall.methodName, methodCall.type, methodCall.parameters);
        }
            
        /// <summary>
        /// Reset the fake.
        /// </summary>
        public void Done()
        {
            expectations.Clear();
        }
    }
}
