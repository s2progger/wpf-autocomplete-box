using System.Collections.Generic;

namespace WPFAutoCompleteBox.Provider
{
    public interface IAutoCompleteDataProvider
    {
        IEnumerable<string> GetItems(string textPattern);
    }
}
