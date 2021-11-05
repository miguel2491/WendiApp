using SQLite;

namespace WendiPanic.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int id { set; get; }
        public string nombre { set; get; }
        public string app { set; get; }
        public string apm { set; get; }
        public string telefono { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public string rol { set; get; }
        public string token { set; get; }
        public string foto { set; get; }
        public int status { set; get; }
    }
}
