using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace EloCounter
{
    public class PrintPageSettings
    {
        public Font Font { get; set; }
        public Font HeaderFont { get; set; }

        public int TopMargin { get; set; }
        public int BottomMargin { get; set; }
        public int LeftMargin { get; set; }
        public int RightMargin { get; set; }

        public int HeaderMargin { get; set; }
        public int NameBoxWidth { get; set; }

    }
}
