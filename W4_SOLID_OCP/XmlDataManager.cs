using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W4_SOLID_OCP
{
    public class XmlDataManager : IDataManager
    {
        public List<Character> Characters { get; set; }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write(Character c)
        {
            throw new NotImplementedException();
        }
    }
}
