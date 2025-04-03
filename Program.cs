using System.Globalization;

namespace SiJemwan
{
    class Karyawan
    {
        private string nama;
        private string id;
        private double gaji_pokok;
        public Karyawan(string nama, string id, double gaji_pokok)
        {
            setNama(nama);
            setId(id);
            setGajiPokok(gaji_pokok);
        }
        public bool setNama(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Nama tidak boleh kosong");
                return false;
            }
            else 
            { 
                nama = value;
                return true;
            }
        }
        public string getNama() {
            return nama;
        }
        public bool setId(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("ID tidak boleh kosong");
                return false;
            }
            else
            {
                id = value;
                return true;
            }
        }
        public string getId()
        {
            return id;
        }
        public bool setGajiPokok(double value)
        {
            if (value < 0)
            {
                Console.WriteLine("Gaji pokok tidak boleh negatif");
                return false;
            }
            else
            {
                gaji_pokok = value;
                return true;
            }
        }
        public double getGajiPokok()
        {
            return gaji_pokok;
        }
        public virtual double HitungGaji()
        {
            return gaji_pokok;
        }
        public void info()
        {
            Console.WriteLine("\nNama: " + getNama());
            Console.WriteLine("ID: " + getId());
            Console.WriteLine("Gaji Pokok: Rp." + getGajiPokok().ToString("N2", new CultureInfo("id-ID")));
            Console.WriteLine("Gaji Akhir: Rp." + HitungGaji().ToString("N2", new CultureInfo("id-ID")));
        }
    }
    class Tetap : Karyawan
    {
        private double tunjangan = 500000;
        public Tetap(string nama, string id, double gaji_pokok) : base(nama, id, gaji_pokok)
        {
        }
        public override double HitungGaji()
        {
            return getGajiPokok() + tunjangan;
        }
        
    }
    class Kontrak : Karyawan
    {
        private double potongan_kontrak = 200000;
        public Kontrak(string nama, string id, double gaji_pokok) : base(nama, id, gaji_pokok)
        {
        }
        public override double HitungGaji()
        {
            return getGajiPokok() - potongan_kontrak;
        }
    }
    class Magang : Karyawan
    {
        public Magang(string nama, string id, double gaji_pokok) : base(nama, id, gaji_pokok)
        {
        }
        public override double HitungGaji()
        {
            return getGajiPokok();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string nama, id_pegawai;
            double gaji_pokok;
            while (true)
            {
                Console.Write("Masukkan Nama Pegawai: ");
                nama = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(nama))
                {
                    Console.WriteLine("\n\nNama tidak boleh kosong!!");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Masukkan ID Pegawai: ");
                id_pegawai = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(id_pegawai))
                {
                    Console.WriteLine("\n\nId Pegawai tidak boleh kosong!!");
                    continue;
                }

                break;
            }

            while (true)
            {
                Console.Write("Masukkan Gaji Pokok Pegawai: ");
                string gaji = Console.ReadLine() ?? "";

                if (double.TryParse(gaji, out double Gaji))
                {
                    if (Gaji < 200000) {
                        Console.WriteLine("\n\nInput Gaji minimal 200000!");
                        continue;
                    }
                    gaji_pokok = Gaji;
                    break;
                }
                Console.WriteLine("\n\nInput Gaji hanya boleh berupa angka!!");
                continue;
            }

            while (true)
            {
                Console.Write("\n1.Tetap\n2.Kontrak\n3.Magang\nPilih Jenis Pegawai (1/2/3): ");
                string tipe_pegawai = Console.ReadLine() ?? "";

                if (tipe_pegawai == "1")
                {
                    Tetap karyawan = new Tetap(nama, id_pegawai, gaji_pokok);
                    karyawan.info();
                    break;
                }
                else if (tipe_pegawai == "2")
                {
                    Kontrak karyawan = new Kontrak(nama, id_pegawai, gaji_pokok);
                    karyawan.info();
                    break;
                }
                else if (tipe_pegawai == "3")
                {
                    Magang karyawan = new Magang(nama, id_pegawai, gaji_pokok);
                    karyawan.info();
                    break;
                }
                else
                {
                    Console.WriteLine("\n\nInput tidak valid!!");
                    continue;
                }
            }
        }
    }
}
