* WPF Auto Complete Box

A reusable auto-complete textbox in WPF. This textbox allows users to start typing and have a list of matches show up below.

*** Building

This repository contains a Visual Studio project that will build the project. Once built, simply reference the DLL in any projects that use it.

*** Usage

Reference the component in your XAML:

```xml
<Window x:Class="YourClass"
  xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
  xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
  xmlns:AC="clr-namespace:WPFAutoCompleteBox.Controls;assembly=WPFAutoCompleteBox"
  x:Name="ThisWindow">
  <DockPanel>
    <AC:CompletableTextBox Name="listWithOptions" />
  </DockPanel>
</Window>
```

Then you need to create an auto-complete provider that will return matches as the user types, for this example we will assume we want to auto-complete a list of companies that have been retrieved from a database:

```C#
class CompanyNameACProvider : IAutoCompleteDataProvider
{
    ObservableCollection<Company> Companies;

    public CompanyNameACProvider(ObservableCollection<Company> companies)
    {
        Companies = companies;
    }

    public IEnumerable<object> GetItems(string textPattern)
    {
        if (textPattern.Length < 3) return null; // Don't bother returning results until more than 2 characters are entered.

        var companies = from c in Companies where c.Name != null && c.Name.ToUpper().Contains(textPattern.ToUpper()) orderby c.Name select c;

        return companies;
    }
}
```

Attach this provider to the auto-complete component and you're done:

```C#
public partial class MainWindow
{
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var manager = new WPFAutoCompleteBox.Core.AutoCompleteManager(listWithOptions);
        manager.DataProvider = new CompanyNameACProvider(Companies); // Companies would be a List of Company objects
    }
}
```
