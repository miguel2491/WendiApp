using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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
            conn.CreateTable<LocalizaModel>();
        }

        public IEnumerable<LocalizaModel> GetPuntos()
        {
            var members = (from mem in conn.Table<LocalizaModel>() select mem);
            return members.ToList();
        }

        public string AddPos(LocalizaModel member)
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
            conn.Delete<LocalizaModel>(ID);
        }
        public void DeleteRutas()
        {
            conn.DeleteAll<LocalizaModel>();
        }
        //--------------------------------------------------------------------------------
    }
}
