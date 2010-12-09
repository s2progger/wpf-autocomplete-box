using System.Collections.Generic;

namespace WPFAutoCompleteBox.Provider
{
    public interface IAutoCompleteDataProvider
    {
        IEnumerable<object> GetItems(string textPattern);
    }
}
