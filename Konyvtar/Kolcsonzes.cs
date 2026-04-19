using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public class Kolcsonzes
    {
        public Tag tag { get; private set; }
        private DateTime mikortol;
        public List<Tetel> tetelek;

        public Kolcsonzes(Tag tag, DateTime mikortol, List<Tetel> tetelek)
        {
            this.tag = tag;
            this.mikortol = mikortol;
            this.tetelek = tetelek;
        }
    }
}
