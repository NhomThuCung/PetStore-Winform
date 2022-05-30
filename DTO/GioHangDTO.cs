using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GioHangDTO
    {
        
        private string maTC;
        private string tenTC;
        private decimal giaBan;

        public string MaTC { get => maTC; set => maTC = value; }
        public string TenTC { get => tenTC; set => tenTC = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
    }
}
