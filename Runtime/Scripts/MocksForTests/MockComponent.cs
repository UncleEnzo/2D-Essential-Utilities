using UnityEngine;

namespace Nevelson.Utils
{
    public class MockComponent : MonoBehaviour
    {
        public string MockStringField = "Mock String";
        public string MockStringGetterSetter { get; set; } = "Mock Strang";
        private string _mockString = "Muck Stwing";
        public string MockStringGetterSetterWithRef
        {
            get => _mockString;
            set => _mockString = value;
        }
    }
}