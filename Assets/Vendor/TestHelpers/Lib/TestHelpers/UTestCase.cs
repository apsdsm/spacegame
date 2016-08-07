using UnityEngine;
using System.Reflection;

namespace TestHelpers
{
    /// <summary>
    /// A test case object that can be used as the base class for Unity
    /// integration tests. It doesn't do anything special, but allows for
    /// a somewhat more natural language when defining tests.
    /// </summary>
    public class UTestCase : MonoBehaviour
    {
        // true if test is finished and should not longer update
        private bool finished = false;

        // true if 'TestIfReady' can be called.
        private bool readyToStart = false;

        // keep track of how many frames have passed
        private int frame = 0;

        // keep track of how many frames have passed since test was declared ready
        private int frameSinceReady = 0;

        // time that has passed since test started
        private float time = 0.0f;

        // time that has passed since test became ready
        private float timeSinceReady = 0.0f;

        // will be true after an assertion was made
        private bool madeSuccessfulAssertion = false;

        // methods that will be called if defined in child classes
        private MethodInfo testOnceMethod;
        private MethodInfo testEachMethod;
        private MethodInfo testOnceWhenReadyMethod;
        private MethodInfo testEachWhenReadyMethod;


        /// <summary>
        /// Returns true if the test is ready to start (assuming that the test
        /// is waiting on the TryToReady method to return true).
        /// </summary>
        protected bool Ready
        {
            get { return readyToStart; }
        }


        /// <summary>
        /// Return the number of frames passed since test started.
        /// </summary>
        protected int Frame
        {
            get { return frame; }
        }


        /// <summary>
        /// Return the frames passed since test was made ready.
        /// </summary>
        protected int FrameSinceReady
        {
            get { return frameSinceReady; }
        }


        /// <summary>
        /// Return the time that has passed since the test started.
        /// </summary>
        protected float TotalTime
        {
            get { return time; }
        }


        /// <summary>
        /// Return the time that has passed since the test was made ready.
        /// </summary>
        protected float TotalTimeSinceReady
        {
            get { return timeSinceReady; }
        }

        /// <summary>
        /// Get references to any test methods that were defined in the inherited class.
        /// </summary>
        void Awake ()
        {
            testOnceMethod = GetType().GetMethod("Test", BindingFlags.Instance | BindingFlags.NonPublic);
            testEachMethod = GetType().GetMethod("TestEachFrame", BindingFlags.Instance | BindingFlags.NonPublic);
            testOnceWhenReadyMethod = GetType().GetMethod("TestWhenReady", BindingFlags.Instance | BindingFlags.NonPublic);
            testEachWhenReadyMethod = GetType().GetMethod("TestEachFrameWhenReady", BindingFlags.Instance | BindingFlags.NonPublic);

        }

        /// <summary>
        /// We'll hijack this event to take care of setup
        /// </summary>
        void Start () { SetUp(); }


        /// <summary>
        /// Try to invoke a test method. If any assertions were made will automatically
        /// call the IntegrationTest.Pass method - which will only come into effect if
        /// the assertion was true.
        /// </summary>
        /// <param name="method"></param>
        private void TryInvokeTestMethod (MethodInfo method)
        {
            if (method != null) {
                method.Invoke(this, new object[] { });
            }
        }

        /// <summary>
        /// Each frame, the test will try to run any methods that were set as testing methods.
        /// If any assertions were made that were successful (using the in build Assert methods)
        /// then the test will pass.
        /// </summary>
        void Update ()
        {
            if (finished) {
                return;
            }

            TryInvokeTestMethod(testOnceMethod);

            TryInvokeTestMethod(testEachMethod);

            ++frame;

            time += Time.deltaTime;

            if (!readyToStart) {
                readyToStart = TryToReady();
            }

            if (readyToStart) {

                TryInvokeTestMethod(testOnceWhenReadyMethod);

                TryInvokeTestMethod(testEachWhenReadyMethod);

                ++frameSinceReady;

                timeSinceReady += Time.deltaTime;
            }

            if (madeSuccessfulAssertion) {
                Pass();
            }
        }


        /// <summary>
        /// If this method is overwritten, if can contain logic that will try to execute
        /// frame update. This is good for storing parts of the test that require components
        /// to have already been awakened, and perhaps run through a few update cycles before
        /// any real testing can occur.
        /// 
        /// You can test to make sure everything is ready to start the test here, and when it
        /// is, return a true value to let the test know it can now execute the `TestIfReady` 
        /// and `TestEachFrameIfReady` methods. 
        /// </summary>
        /// <returns></returns>
        virtual public bool TryToReady ()
        {
            return false;
        }


        /// <summary>
        /// Is called before the test.
        /// </summary>
        virtual public void SetUp () { }


        /// <summary>
        /// Is called after a test is successful.
        /// </summary>
        virtual public void TearDown () { }


        /// <summary>
        /// Makes the test pass. Will call teardown automatically.
        /// </summary>
        public void Pass ()
        {
            finished = true;
            IntegrationTest.Pass();
            TearDown();
        }

        /// <summary>
        /// Make the test fail. Wall call teardown automatically.
        /// </summary>
        /// <param name="message"></param>
        public void Fail (string message = "")
        {
            finished = true;
            IntegrationTest.Fail(message);
            TearDown();
        }

        /// <summary>
        /// Asserts that the condition passed to the method is true.
        /// </summary>
        /// <param name="condition">condition to check</param>
        /// <param name="message">optional message to pass if check fails</param>
        public void AssertThat (bool condition, string message = "")
        {
            IntegrationTest.Assert(condition, message);

            if (condition == true) {
                madeSuccessfulAssertion = true;
            }
        }


        /// <summary>
        /// Assert that a and b are more or less the same. What constitutes 'more or less'
        /// can be tweaked by changing the epsilon value.
        /// </summary>
        /// <param name="a">a value to compare</param>
        /// <param name="b">b value to compare</param>
        /// <param name="epsilon">a small number that represents an acceptable difference between a and b</param>
        /// <param name="message">optional error message</param>
        public void AssertSimilar (float a, float b, float epsilon = 0.01f, string message = "")
        {
            float remainder = Mathf.Abs(a - b);

            IntegrationTest.Assert(remainder < epsilon);

            if (remainder < epsilon) {
                madeSuccessfulAssertion = true;
            }
        }

        /// <summary>
        /// Assert that two vectors are facing the same direction.
        /// </summary>
        /// <param name="a">a value to compare</param>
        /// <param name="b">b value to compare</param>
        /// <param name="message">optional error message</param>
        public void AssertSameDirection (Vector3 a, Vector3 b, string message = "")
        {
            a.Normalize();
            b.Normalize();

            if (a == b) {
                IntegrationTest.Assert(true, "Vectors oriented in same direction");
                madeSuccessfulAssertion = true;
            }
            else {
                IntegrationTest.Fail(gameObject, message == "" ? "Vectors not oriented in same direction" : message);
            }
        }

    }
}
