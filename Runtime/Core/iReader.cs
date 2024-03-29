namespace Wsh.Localization {

    public interface iReader {

        string Read(int localId, string language);
        string Read(string localId, string language);
        void Dispose();

    }
}