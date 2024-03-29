using Wsh.Singleton;

namespace Wsh.Localization {

    public class LocalizationManager : NonMonoSingleton<LocalizationManager> {

        public LanguageType Language => m_languageType;

        private iReader m_reader;
        private LanguageType m_languageType;
        private string m_languageString;
        private bool m_isInit;

        public void Init(LanguageType languageType,iReader reader) {
            SetLanguage(languageType);
            m_reader = reader;
            m_isInit = true;
        }

        protected override void OnInit() {

        }

        public void SwitchLanguage(LanguageType languageType) {
            SetLanguage(languageType);
        }

        private void SetLanguage(LanguageType languageType) {
            m_languageType = languageType;
            m_languageString = m_languageType.ToString();
        }
        
        public string GetLocalText(int localId) {
            if(!m_isInit) {
                Log.Error("LocalizationManger do not Init.");
                return null;
            }
            return m_reader.Read(localId, m_languageString);
        }

        public string GetLocalText(int localId, params object[] args) {
            string text = GetLocalText(localId);
            return string.Format(text, args);
        }

        public string GetLocalText(string localId) {
            if(!m_isInit) {
                Log.Error("LocalizationManger do not Init.");
                return null;
            }
            return m_reader.Read(localId, m_languageString);
        }

        public string GetLocalText(string localId, params object[] args) {
            string text = GetLocalText(localId);
            return string.Format(text, args);
        }

        protected override void OnDeinit() {
            m_reader.Dispose();
        }

    }
}