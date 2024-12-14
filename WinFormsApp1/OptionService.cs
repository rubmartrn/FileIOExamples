
using FileIoExamples.Business;

namespace WinFormsApp1
{
    internal class OptionService : IOptionService
    {
        private string option = string.Empty;
        public string GetSelectedOption()
        {
            OptionGetter getter = new OptionGetter();
            getter.Closed += onClosed;
            if (getter.ShowDialog() == DialogResult.OK)
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
