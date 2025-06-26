using Microsoft.AspNetCore.Components;

namespace Flafel.Maui.Components.Controls.SharedControls.Forms.Base
{
    public abstract class FormControlBase<T> : ComponentBase where T : class
    {
        protected bool IsLoading { get; set; }
        protected string ErrorMessage { get; set; } = string.Empty;

        [Parameter]
        public EventCallback OnCollapse { get; set; }

        [Parameter]
        public EventCallback<(T, bool)> OnAfterSubmit { get; set; }

        protected abstract Task OnSubmit();
        protected abstract Task OnInit();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ErrorMessage = string.Empty;
                IsLoading = true;
                await Task.Delay(1000);
                await OnInit();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }
        protected async Task SubmitFormHandler()
        {
            try
            {
                ErrorMessage = string.Empty;
                IsLoading = true;
                await Task.Delay(1000);
                await OnSubmit();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }
        protected void CollapseForm()
        {
            if (!IsLoading)
            {
                OnCollapse.InvokeAsync();
            }
        }
    }
}
