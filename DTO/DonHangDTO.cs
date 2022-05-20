using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {
        private int maDH;
        private int id;
        private DateTime createdDate;
        private int maKH;
        private string nguoiNhan;
        private string email;
        private string soDT;
        private string diaChi;
        private decimal tongTien;
        private bool status;

        public int MaDH { get => maDH; set => maDH = value; }
        public int Id { get => id; set => id = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string NguoiNhan { get => nguoiNhan; set => nguoiNhan = value; }
        public string Email { get => email; set => email = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
        public bool Status { get => status; set => status = value; }
    }
}
