MVC .NET CSS Dropdown Menu
--------

Create a simple MVC .NET CSS dropdown menu. The project includes HTML, CSS, Javascript and an easy MVC partial view to render custom css dropdown menus.

(screenshot.jpg)

The dropdown menu includes an underlying HTML "select" element, which is kept in-sync with the values in the dropdown menu. This allows for easy querying of the dropdown menu values through typical jQuery calls, for example:

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
