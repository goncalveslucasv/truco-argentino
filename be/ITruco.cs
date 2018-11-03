using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be
{
    public interface ITruco
    {
        string nombre { get; set; }
       
        ITruco reCantar { get; set; }

        int PuntosQueridos { get;  }

        int PuntosNoQueridos { get; }
    }
}
