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
        public virtual double gaji()
        {
            return gaji_pokok;
        }
        public void info()
        {
            Console.WriteLine("Nama: " + getNama());
            Console.WriteLine("ID: " + getId());
            Console.WriteLine("Gaji Pokok: " + getGajiPokok());
            Console.WriteLine("Gaji Akhir: " + gaji());
        }
    }
    class Tetap : Karyawan
    {
        private double tunjangan = 500000;
        public Tetap(string nama, string id, double gaji_pokok) : base(nama, id, gaji_pokok)
        {
        }
        public override double gaji()
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
        public override double gaji()
        {
            return getGajiPokok() - potongan_kontrak;
        }
    }
    class Magang : Karyawan
    {
        public Magang(string nama, string id, double gaji_pokok) : base(nama, id, gaji_pokok)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Kontrak karyawan1 = new Kontrak("Budi", "K001", 3000000);
            Magang karyawan2 = new Magang("Andi", "M001", 2000000);
            Tetap karyawan3 = new Tetap("Caca", "T001", 4000000);
            karyawan3.setGajiPokok(5000000);
            karyawan1.info();
            karyawan2.info();
            karyawan3.info();
        }
    }
}
