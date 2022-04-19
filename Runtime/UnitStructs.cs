namespace Nevelson.Utils
{
    public struct TestCase<Output>
    {
        public string name;
        public Output expected;
    }

    public struct TestCase<I1, Output>
    {
        public string name;
        public I1 input;
        public Output expected;
    }

    public struct TestCase<I1, I2, Output>
    {
        public string name;
        public I1 input;
        public I2 input2;
        public Output expected;
    }
    public struct TestCase<I1, I2, I3, Output>
    {
        public string name;
        public I1 input;
        public I2 input2;
        public I3 input3;
        public Output expected;
    }
}