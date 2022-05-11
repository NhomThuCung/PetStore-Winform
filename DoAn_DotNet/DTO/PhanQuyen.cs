using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_DotNet.DTO
{
    class PhanQuyen
    {
        private int maQuyen;
        private string tenQuyen;

        public int MaQuyen { get => maQuyen; set => maQuyen = value; }
        public string TenQuyen { get => tenQuyen; set => tenQuyen = value; }
    }
}
