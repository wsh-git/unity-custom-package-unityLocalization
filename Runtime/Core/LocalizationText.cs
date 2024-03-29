using System;
using UnityEngine;
using UnityEngine.UI;

namespace Wsh.Localization {

    [RequireComponent(typeof(Text))]
    public class LocalizationText : MonoBehaviour {

        [Serializable]
        public class FontCustom {
            public LanguageType languageType;
            public Font font;
            public bool isStatic;
            public float fontSize;
        }

        [SerializeField]private string m_localId;
        [SerializeField]private FontCustom[] m_fontCustoms;

        private Text m_text;
        private LocalizationManager m_localizationManager;

        // Start is called before the first frame update
        void Start() {
            m_text = GetComponent<Text>();
            m_localizationManager = LocalizationManager.Instance;
            InitFont();
            ReadText();
        }

        private void ReadText() {
            m_text.text = m_localizationManager.GetLocalText(m_localId);
        }

        private void InitFont() {
            int index = -1;
            if(m_fontCustoms.Length > 0) {
                for(int i = 0; i < m_fontCustoms.Length; i++) {
                    if(m_fontCustoms[i].languageType == m_localizationManager.Language) {
                        index = i;
                        break;
                    }
                }
                if(index >= 0) {
                    var fontCustom = m_fontCustoms[index];
                    if(fontCustom != null) {
                        m_text.font = fontCustom.font;
                        if(fontCustom.isStatic) {
                            if(fontCustom.fontSize != 0) {
                                transform.localScale = new Vector3(fontCustom.fontSize, fontCustom.fontSize, fontCustom.fontSize);
                            }
                        } else {
                            m_text.fontSize = (int)fontCustom.fontSize;
                        }
                    }
                }
            }
        }

        [ContextMenu("ResetFont")]
        public void ResetFont() {
            InitFont();
        }

    }
}