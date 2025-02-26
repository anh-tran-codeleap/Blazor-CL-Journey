# Blazor Training For Frontend Development with C#

## Share data in Blazor Application
```
create a state with properties (data) & methods (action for interact with the properties) [Encapsulation]
|
v
register add dependency as AddScoped in Program.cs -> in the component page @using namespace and @inject the State
|
v
Using EventCallBack as [Parameter] of component for parent component to interact with child component
```
## Bind controls to data in Blazor
Blazor lets you bind HTML controls to properties so that changing values are automactically displayed in the user interface (UI).

Suppose you're developing a page that collects information from customers about their pizza preferences. You want to load the information from a database and enable customers to make changes, such as recording their favorite toppings. When there's a change from the user or an update in the database, you want the new values to display in the UI as quickly as possible.

In this unit, you'll learn how to use data binding in Blazor to tie UI elements to data values, properties, or expressions.
Example of Binding Data to a specific event
```C#
@page "/"

<h1>My favorite pizza is: @favPizza</h1>

<p>
    Enter your favorite pizza:
    <input @bind-value="favPizza" @bind-value:event="oninput" />
</p>

@code {
    private string favPizza { get; set; } = "Margherita"
}
```
Example of bind and format bound values
```C#
@page "/ukbirthdaypizza"

<h1>Order a pizza for your birthday!</h1>

<p>
    Enter your birth date:
    <input @bind="birthdate" @bind:format="dd-MM-yyyy" />
</p>

@code {
    private DateTime birthdate { get; set; } = new(2000, 1, 1);
}
```
As an alternative to using the @bind:format directive, you can write C# code to format a bound value. Use the get and set accessors in the member definition, as in this example:
```C#
@page "/pizzaapproval"
@using System.Globalization

<h1>Pizza: @PizzaName</h1>

<p>Approval rating: @approvalRating</p>

<p>
    <label>
        Set a new approval rating:
        <input @bind="ApprovalRating" />
    </label>
</p>

@code {
    private decimal approvalRating = 1.0;
    private NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;
    private CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
    
    private string ApprovalRating
    {
        get => approvalRating.ToString("0.000", culture);
        set
        {
            if (Decimal.TryParse(value, style, culture, out var number))
            {
                approvalRating = Math.Round(number, 3);
            }
        }
    }
}
```