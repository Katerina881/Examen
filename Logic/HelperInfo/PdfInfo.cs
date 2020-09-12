using Logic.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.HelperInfo
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<VkladViewModel> Vklads { get; set; }
    }
}
