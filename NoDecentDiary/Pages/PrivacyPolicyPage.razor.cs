﻿using Microsoft.AspNetCore.Components;
using NoDecentDiary.Components;
using NoDecentDiary.Shared;

namespace NoDecentDiary.Pages
{
    public partial class PrivacyPolicyPage : PageComponentBase
    {
        private string? Content { get; set; }


        [CascadingParameter]
        public Error Error { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await LoadingData();
            await base.OnInitializedAsync();
        }

        private async Task LoadingData()
        {
            try
            {
                var url = I18n.T("FilePath.PrivacyPolicy");
                using var stream = await FileSystem.OpenAppPackageFileAsync(url);
                using var sr = new StreamReader(stream);
                Content = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }
        }
    }
}