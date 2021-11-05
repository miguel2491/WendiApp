using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WendiPanic.Models;
using Xamarin.Forms;

namespace WendiPanic.SQLiteDB
{
    public class LocalizaDB
    {
        private SQLiteConnection conn;

        public LocalizaDB()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Localiza>();
        }

        public IEnumerable<Localiza> GetPuntos()
        {
            var members = (from mem in conn.Table<Localiza>() select mem);
            return members.ToList();
        }

        public string AddPos(Localiza member)
        {
            try
            {
                conn.Insert(member);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public void DeletePunto(int ID)
        {
            conn.Delete<Localiza>(ID);
        }
        public void DeleteRutas()
        {
            conn.DeleteAll<Localiza>();
        }
        //--------------------------------------------------------------------------------
    }
}
