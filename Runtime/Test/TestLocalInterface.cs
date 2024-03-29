using UnityEngine;

namespace Wsh.Localization {

    public class TestLocalInterface : MonoBehaviour {
        
        public class LocalReader : iReader {

            public void Dispose() {

            }

            public string Read(int localId, string language) {
                return "Test int localId from " + language;
            }

            public string Read(string localId, string language) {
                return "Test string localId from " + language;
            }
        }

        private void Start() {
            LocalReader localReader = new LocalReader();
            LocalizationManager.Instance.Init(LanguageType.CN, localReader);
        }

    }
}