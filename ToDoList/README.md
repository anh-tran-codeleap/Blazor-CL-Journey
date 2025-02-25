## Data binding and events

### Render C# expression values
```C#
// a leading @ character to render value of a C# experssion in Razor
<p role="status">Current count: @currentCount</p>
// More explicit with ()
<p role="status">Current count: @(currentCount)</p>
```
### Add control flow
```C#
@if (currentCount > 3)
{
    <p>You win!</p>
}

<ul>
    @foreach (var item in items)
    {
        <li>@item.Name</li>
    }
</ul>
```
### Handle Event
Blazor components often handle UI events. To specify an event callback for an event from a UI element, you use an attribute that starts with `@on` and ends with the event name.For example, you can specify the `IncrementCount` method as a handler for a button click event using the `@onclick` attribute, like this:
```C#
<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```
You can specify C# event handlers for other HTML events too, like `@onchange, @oninput`, and so on. Event handling methods can be synchronous or asynchronous. You can also define event handlers inline using C# lambda expressions:
```C#
<button class="btn btn-primary" @onclick="() => currentCount++">Click me</button>
```
Event handler methods can optionally take an event argument with information about the event. For example, you can access the value of an input element that changed, like this:
```C#
<input @onchange="InputChanged" />
<p>@message</p>

@code {
    string message = "";

    void InputChanged(ChangeEventArgs e)
    {
        message = (string)e.Value;
    }
}
```
## Create A To Do List
```bash
dotnet new razorcomponent -n Todo -o Components/Pages
```