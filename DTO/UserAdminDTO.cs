using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserAdminDTO
    {
        private int id;
        private string userName;
        private string password;
        private string hoTen;
        private string cmnd;
        private DateTime ngaySinh;
        private string diaChi;
        private string email;
        private string phone;
        private DateTime createDate;
        private int maQuyen;
        private decimal tienLuong;

        public UserAdminDTO()
        {

        }

        public UserAdminDTO(int id, string userName, string password, string hoTen, string cmnd, DateTime ngaysinh, string diaChi, string email, string phone, DateTime createDate, int maQuyen, decimal tienLuong)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.HoTen = hoTen;
            this.Cmnd = cmnd;
            this.NgaySinh = ngaySinh;
            this.DiaChi = diaChi;
            this.Email = email;
            this.Phone = phone;
            this.CreateDate = createDate;
            this.MaQuyen = maQuyen;
            this.TienLuong = tienLuong;
        }
        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public int MaQuyen { get => maQuyen; set => maQuyen = value; }
        public decimal TienLuong { get => tienLuong; set => tienLuong = value; }
    }
}
