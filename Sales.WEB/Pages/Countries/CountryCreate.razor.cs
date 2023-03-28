using Blazored.Modal;
using Blazored.Modal.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Sales.Shared.Entities;

namespace Sales.WEB.Pages.Countries
{
    partial class CountryCreate
    {
        private Country country = new();
        private CountryForm? countryForm;

        private string url { get; set; } = "/api/countries";

        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; } = default!;

        private async Task Create()
        {
            var httpResponse = await repository.Post<Country, CountryForm>(url, country);
            if (httpResponse.Error)
            {
                var message = await httpResponse.GetErrorMessageAsync();
                await sweetAlertService.FireAsync("Error", message, SweetAlertIcon.Error);
                return;
            }

            await BlazoredModal.CloseAsync(ModalResult.Ok());
            Return();
        }

        private void Return()
        {
            countryForm!.FormPostedSuccesFully = true;
            navigationManager.NavigateTo("/countries");
        }
    }
}
