using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IUIHelper
    {
        void DisableButton(string name);
        void ChangeButtonText(string name, string value);
        void ChangeTurnLabel(MapValues mapValues);
        void SetButtonText(string id, string value);
    }
}
