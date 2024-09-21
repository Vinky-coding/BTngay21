using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinhvienBTngay21
{
    class Sinhvien
    {
        public string Hoten { get; set; }
        public string MSSV { get; set; }
        public double DiemTB { get; set; }

        public void NhapThongTin()
        {
            Console.Write(" - Nhap ho va ten sinh vien: ");
            Hoten = Console.ReadLine();
            Console.Write(" - Nhap ma so sinh vien: ");
            MSSV = Console.ReadLine();
            Console.Write(" - Nhap diem trung binh cua sinh vien: ");
            DiemTB = double.Parse(Console.ReadLine());
        }
        public void HienThiThongTin()
        {
            Console.WriteLine("Ho va ten: " + Hoten);
            Console.WriteLine("Ma sinh vien: " + MSSV);
            Console.WriteLine("Diem trung binh: " + DiemTB);
        }
    }
    class DanhsachSinhvien
    {
        private List<Sinhvien> danhsach;

        public DanhsachSinhvien()
        {
            danhsach = new List<Sinhvien>();
        }
        public void ThemSinhVien(Sinhvien sv)
        {
            danhsach.Add(sv);
        }
        public void HienThiDanhSach()
        {
            Console.WriteLine("Hien thi danh sach nhu sau: ");
            foreach (var sv in danhsach)
            {

                sv.HienThiThongTin();
                Console.WriteLine();
            }
        }
        public Sinhvien DiemTbcao()
        {
            Sinhvien sinhvienmax = null;
            foreach (var sv in danhsach)
            {
                if (sinhvienmax == null || sv.DiemTB > sinhvienmax.DiemTB)
                {
                    sinhvienmax = sv;
                }
            }
            return sinhvienmax;
        }
        public Sinhvien Timkiemsinhvien(string mssv)
        {
            foreach (var sv in danhsach)
            {
                if (sv.MSSV.Equals(mssv))
                {
                    return sv;
                }
            }
            return null;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Moi nhap n: ");
            int n = int.Parse(Console.ReadLine());

            DanhsachSinhvien T = new DanhsachSinhvien();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("\n");
                Sinhvien sv = new Sinhvien();
                sv.NhapThongTin();
                T.ThemSinhVien(sv);
            }

            T.HienThiDanhSach();


            Sinhvien sinhvienmax = T.DiemTbcao();
            if (sinhvienmax != null)
            {
                Console.WriteLine("Sinh vien co diem trung binh cao nhat la: ");
                sinhvienmax.HienThiThongTin();
            }

            Console.Write("\nNhap ma sinh vien can tim: ");
            string msvTim = Console.ReadLine();

            Sinhvien masvtimthay = T.Timkiemsinhvien(msvTim);
            if (masvtimthay != null)
            {
                Console.WriteLine("\nSinh vien co ma sv tim thay la: ");
                masvtimthay.HienThiThongTin();
            }
            else 
            {
                Console.WriteLine("Khong co sinh vien nao co ma sinh vien can tim!");    
            }
        }
    }
}


