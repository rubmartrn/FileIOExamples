using Microsoft.AspNetCore.Components;

namespace UniversityProgram.blazor.Pages
{
    public partial class Counter
    {

        [Parameter]
        public string UserName { get; set; }

        [Parameter]
        public EventCallback<string> OnChanged { get; set; }

        private int currentCount = 0;

        private async Task IncrementCount()
        {
            await OnChanged.InvokeAsync("տեքտս");
            UserName = "Բարև Ձեզ";
            currentCount++;
        }
    }
}