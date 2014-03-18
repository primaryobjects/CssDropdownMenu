MVC .NET CSS Dropdown Menu
--------

Create a simple MVC C# ASP .NET CSS dropdown menu. The project includes HTML, CSS, Javascript and an easy MVC partial view to render custom css dropdown menus.

![](screenshot.jpg)

To include the dropdown menu in your view, you can use a partial view helper or the raw html. For example:

```
@Html.Partial("DropDownMenu", new DropDownMenu("lstMonsters") { Label = "Monster:", Items = UIManager.GetDropDownList(() => UIManager.GetEnumStrings<MonsterType>(), false) })
```

The dropdown menu includes an underlying HTML "select" element, which is kept in-sync with the values in the dropdown menu. This allows for easy management of the dropdown menus with javascript and jquery calls, for example:

```
// Automatically select an option in the dropdown.
$('#lstMonsters').val(5);

// Setup a change event for a dropdown.
$('#lstMonsters').change(function () {
	$('#status').text('You selected ' + $(this).find(':selected').text() + '.');
});
```

The example project includes a helper method for rendering enum values within the dropdowns. The dropdown menu can be easily customized via style.css.

## Author

Kory Becker
http://www.primaryobjects.com/kory-becker.aspx
