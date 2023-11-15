using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuChat.Core
{
    public abstract class ViewModel : ObservableObject, IDisposable
    {
        public void Dispose() { }
    }
}
