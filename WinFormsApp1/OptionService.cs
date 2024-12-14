
using FileIoExamples.Business;

namespace WinFormsApp1
{
    internal class OptionService : IOptionService
    {
        private readonly OptionGetter _getter;
        private string option = string.Empty;

        public OptionService(OptionGetter getter)
        {
            this._getter = getter;
        }
        public string GetSelectedOption()
        {
            _getter.Closed += onClosed;
            if (_getter.ShowDialog() == DialogResult.OK)
            {

            }

            return option;
        }

        void onClosed(object? sender, EventArgs e)
        {
            if (sender is OptionGetter optionGetter)
            {
                option = optionGetter.SelectedOption;
            }
        }
    }
}
