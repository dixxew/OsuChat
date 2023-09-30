using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuChat.MVVM.Model
{
    internal class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }

        public Profile()
        {
            Id = 0;
            ImageSource = "";
            Name = "Dixxew";
        }
    }
}
