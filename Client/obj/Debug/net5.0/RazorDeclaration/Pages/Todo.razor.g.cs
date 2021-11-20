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
#line 3 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Pages\Todo.razor"
using ToDo.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Pages\Todo.razor"
using ToDo.Shared.Utils;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo")]
    public partial class Todo : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 107 "D:\USERS\RAFEEK\Work\Blazor\ToDo\Client\Pages\Todo.razor"
       
      
    private string newTodo, newTodoTitle;
    private Category[] categories ;
    private Category newCat = new Category();
    public List<Category> ToDoList = null;
    
    private bool ShowLoading {get; set;}
    
    

    protected override async Task OnInitializedAsync()
    {
        ShowLoading = true;
        ToDoList = new List<Category>();
        categories = await Http.GetFromJsonAsync<Category[]>("api/category");
        //await JSRuntime.InvokeVoidAsync("alert", System.Text.Json.JsonSerializer.Serialize(categories)); 
        if (categories != null ) {
            foreach (var category in categories){
                 ToDoList.Add(category);
            }
             
        } 

        ShowLoading = false;

    }

    private async Task AddTodoTitle()
    {
      
        newCat = new  Category();

        newCat.Title = newTodoTitle;
        newCat.Active = 1;
        newCat.Sort = 1;       
        
        //await JSRuntime.InvokeVoidAsync("alert", System.Text.Json.JsonSerializer.Serialize(TimeUtils.ToUnixTimeSeconds())); 

        await Http.PostAsJsonAsync<Category>("api/category", newCat);
        await OnInitializedAsync();

        newTodoTitle = "";
        
    }

    private string GetTodoItemStatus(TodoItem item) {
        string itemStatus = "";

        if (item.Completed == 1) {
            itemStatus = "Completed";
        } else if (item.Active == 0){
            itemStatus = "Removed";
        }

        return itemStatus;
    }

    private bool TodoSelected(TodoItem item) {
        return (item.Completed == 1 ? true : false);
    }

    private async Task DeleteToDoItem(TodoItem item, Category cat) {
        //await JSRuntime.InvokeVoidAsync("alert", System.Text.Json.JsonSerializer.Serialize(item)); 
        item.Active = item.Active == 1 ? 0 : 1;
        if (item.Active == 0) {
            item.CompletedCssClass = item.CompletedCssClass + " deleted";
        } else {
            if(item.CompletedCssClass.Contains("deleted")){
                item.CompletedCssClass = item.CompletedCssClass.Replace(" deleted", "");
            }            
        }

        await AddTodoItem(cat, true);
    }

    private async Task TodoItemMarkComplete(TodoItem item, Category cat, ChangeEventArgs e) {        
        item.Completed = ((bool)e.Value)  ? 1: 0;
        item.CompletedCssClass = item.Completed == 1 ? "row completed" : "row";
        

        await AddTodoItem(cat, true);
    }

    private async Task AddTodoItem(Category cat, bool isUpdate) {
        newCat = new Category();
        newCat = cat;
        
        List<TodoItem> mydoList = new List<TodoItem>();

        if (!isUpdate) {
            mydoList.Add(new TodoItem(){ItemID=TimeUtils.ToUnixTimeSeconds(), Title=newTodo, Active=1, Sort=1, Completed=0, CompletedCssClass="row"});
        }    

        newTodo = "";    

        //await JSRuntime.InvokeVoidAsync("alert", System.Text.Json.JsonSerializer.Serialize(mydoList)); 

        if (newCat.ToDo != null) {
            foreach (var items in cat.ToDo)
            {   
                mydoList.Add(new TodoItem(){
                    Title=items.Title,                     
                    Active=items.Active, 
                    Sort=items.Sort, 
                    ItemID= items.ItemID, 
                    Completed= items.Completed, 
                    CompletedCssClass=items.CompletedCssClass });
            } 
        }
        
        newCat.ToDo = mydoList; 
        await Http.PutAsJsonAsync<Category>("api/category/"+newCat.CategoryID, newCat);

        await OnInitializedAsync();
        
    }
    public void OnItemDrop()
    {
       // DropedItem = item;
        StateHasChanged();
    }
    public void OnReplacedItemDrop()
    {
       // replacedItem = item;
        StateHasChanged();
    }

   /* public List<TodoItem> ToDoList = new List<TodoItem>() {
       new TodoItem(){Title = "Style this list"},
        new TodoItem(){Title = "Fix a bug"},
        new TodoItem(){Title = "Build a feature"},
        new TodoItem(){Title = "Create a PR"}
    }; */

  /*  public List<TodoItem> MyToDoList = new List<TodoItem>()
    {
            new TodoItem(){
                Title = "Drag this item", 
                TaskList=[
                    
                ]            
            },
            new TodoItem(){
                Title = "Add another item",
                TaskList = []
            },
            new TodoItem(){
                Title = "Remove this item",
                TaskList = []
            }
                
          //  new TodoItem(){Title = "Style this list"},
           // new TodoItem(){Title = "Fix a bug"},
           // new TodoItem(){Title = "Build a feature"},
           // new TodoItem(){Title = "Create a PR"},
    }; */

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
