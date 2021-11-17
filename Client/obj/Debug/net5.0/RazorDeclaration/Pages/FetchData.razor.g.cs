// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace ToDo.Client.Pages
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
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using ToDo.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using ToDo.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\_Imports.razor"
using Plk.Blazor.DragDrop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Pages\FetchData.razor"
using ToDo.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 53 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Pages\FetchData.razor"
       
    private Category[] categories;
    private Category newCat = new Category();

    protected override async Task OnInitializedAsync()
    {
        categories = await Http.GetFromJsonAsync<Category[]>("api/category");
    }

    public async Task AddCategory() {
        List<TodoItem> MyDoList = new List<TodoItem>()
         {
            new TodoItem(){Title="Style this list", Active=1, Sort=1},
            new TodoItem(){Title="Fix a bug", Active=1, Sort=1},
            new TodoItem(){Title="Build a feature", Active=1, Sort=1},
            new TodoItem(){Title="Create a PR", Active=1, Sort=1}
        }; 
       // MyDoList.Add();

       newCat.ToDo = MyDoList;

        
        await Http.PostAsJsonAsync<Category>("api/Category", newCat);
            await OnInitializedAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
