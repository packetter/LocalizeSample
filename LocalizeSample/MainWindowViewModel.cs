using System.ComponentModel;
using System.Globalization;
using WPFLocalizeExtension.Engine;

namespace LocalizeSample
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel()
        {
            LocalizeDictionary.Instance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Culture")
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FormattedTitle)));
            };
        }

        public string TitleKey => "Title";

        public string[] Args => ["arg1"];

        public string FormattedTitle =>
            string.Format(
                LocalizeDictionary.Instance.GetLocalizedObject(
                    "LocalizeSample", "Resources", TitleKey,
                    LocalizeDictionary.Instance.Culture) as string ?? "",
                Args);
    }
}
