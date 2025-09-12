using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4_SOLID_OCP
{
    public interface IPhone
    {
        void MakeCall(string phoneNumber);
        void CancelCall();
        int TakePicture();
        void PlayGame();
    }
}
