namespace Nevelson.Utils
{
    public class MockMonoSingletonComponent : MonoSingleton<MockMonoSingletonComponent>
    {
        public string Reference = "Default";
    }
}