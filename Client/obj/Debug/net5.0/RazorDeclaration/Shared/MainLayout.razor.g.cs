// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ToDo.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using ToDo.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using ToDo.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Plk.Blazor.DragDrop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Shared\MainLayout.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Shared\MainLayout.razor"
      

    private async Task LogoutUser()
    {
        await _httpClient.GetAsync("auth/logoutuser");
        _navigationManager.NavigateTo("/", true);
    }
   

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
    }
}
#pragma warning restore 1591
