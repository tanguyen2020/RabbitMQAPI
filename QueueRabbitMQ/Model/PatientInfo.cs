using System;
using System.Collections.Generic;
using System.Text;

namespace QueueRabbitMQ.Model
{
    public class PatientInfo
    {
        public int BENHNHAN_ID { get; set; }
        public string MAYTE { get; set; }
        public string FID { get; set; }
        public string SOVAOVIEN { get; set; }
        public string TENBENHNHAN { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public int GIOITINH { get; set; }
        public DateTime? NGAYSINH { get; set; }
        public DateTime? NGAYGIOSINH { get; set; }
        public int? NAMSINH { get; set; }
        public string MANOISINH { get; set; }
        public string SODIENTHOAI { get; set; }
        public string SONHA { get; set; }
        public string DIACHI { get; set; }
        public string DIACHITHUONGTRU { get; set; }
        public string DIACHILIENLAC { get; set; }
        public string DIACHICOQUAN { get; set; }
        public int? TINHTHANH_ID { get; set; }
        public int? QUANHUYEN_ID { get; set; }
        public string XAPHUONG_ID { get; set; }
        public string SOLUUTRUNOITRU { get; set; }
        public string SOLUUTRUNGOAITRU { get; set; }
        public int? NGHENGHIEP_ID { get; set; }
        public int? QUOCTICH_ID { get; set; }
        public int? DANTOC_ID { get; set; }
        public bool VIETKIEU { get; set; } = false;
        public bool NGUOINUOCNGOAI { get; set; } = false;
        public string CMND { get; set; }
        public string HOCHIEU { get; set; }
        public string EMAIL { get; set; }
        public string HINHANH_DAIDIEN { get; set; }
        public int? NHOMMAU_ID { get; set; }
        public int? YEUTORH_ID { get; set; }
        public string TIENSUDIUNG { get; set; }
        public string TIENSUBENH { get; set; }
        public string TIENSUHUTTHUOCLA { get; set; }
        public bool TUVONG { get; set; } = false;
        public DateTime? NGAYTUVONG { get; set; }
        public DateTime? THOIGIANTUVONG { get; set; }
        public int? NGUYENNHANTUVONG_ID { get; set; }
        public int? NGUOIGHINHANTUVONG_ID { get; set; }
        public DateTime? THOIGIANGHINHANTUVONG { get; set; }
        public int? NHANVIEN_ID { get; set; }
        public int? DONVICONGTAC_ID { get; set; }
        public string DIENTHOAIBAN { get; set; }
        public int? TINHTRANGHONNHAN_ID { get; set; }
        public int? NGUOILIENHE_ID { get; set; }
        public string NGUOILIENHE { get; set; }
        public string THONGTIN_NLH { get; set; }
        public int? MOIQUANHE_ID { get; set; }
        public string GHICHU { get; set; }
        public bool ACTIVE { get; set; }
        public string PID { get; set; }
        public int? TRINHDOVANHOA_ID { get; set; }
        public string QueueName { get; set; }
    }
}
