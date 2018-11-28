using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.RenderTree;
using Microsoft.JSInterop;

namespace BlazorFiddle.Blazor
{
    public class BaseBlazorFiddle : BlazorComponent
    {
        protected ElementRef Ref;

        [Parameter]
        protected string Code { get; set; }

        [Parameter]
        protected string Template { get; set; } = null;

        private bool isFirstRender = true;

        protected async override Task OnInitAsync()
        {
            await base.OnInitAsync();
        }

        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender)
            {
                isFirstRender = true;
                await JSRuntime.Current.InvokeAsync<object>("blazorFiddle.create", Ref, new
                {
                    Text = this.Code,
                    Template = this.Template,
                });
            }
        }
    }
}