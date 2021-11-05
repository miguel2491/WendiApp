﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using WendiPanic.Models;
using Xamarin.Forms;

namespace WendiPanic.SQLiteDB
{
    public class UserDB
    {
        private SQLiteConnection conn;

        public UserDB()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Usuario>();

        }

        public IEnumerable<Usuario> GetMembers()
        {
            var members = (from mem in conn.Table<Usuario>() select mem);
            return members.ToList();
        }


        public string AddMember(Usuario member)
        {
            try
            {
                conn.Insert(member);
                return "success baby bluye ;*";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }

        }

        public string UpdateMember(int id, string username, int status)
        {
            try
            {
                var res = "Fallo";
                var data = conn.Table<Usuario>();
                var d1 = (from values in data
                          where values.id == id
                          select values).Single();
                if (true)
                {
                    d1.id = id;
                    d1.username = username;
                    d1.status = status;
                    conn.Update(d1);
                    res = "Correcto";
                }
                return "Res->" + res;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UpdateMemberToken(int id, string token)
        {
            try
            {
                var res = "Fallo";
                var data = conn.Table<Usuario>();
                var d1 = (from values in data
                          where values.id == id
                          select values).Single();
                if (true)
                {
                    d1.token = token;
                    //d1.status = status;
                    conn.Update(d1);
                    res = "Correcto";
                }
                return "Res->" + res;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string CerrarSesion(int id, int status)
        {
            try
            {
                var res = "Fallo";
                var data = conn.Table<Usuario>();
                var d1 = (from values in data
                          where values.id == id
                          select values).Single();
                if (true)
                {
                    d1.status = status;
                    conn.Update(d1);
                    res = "Correcto";
                }
                return "Res->" + res;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public void DeleteMember(int ID)
        {
            conn.Delete<Usuario>(ID);
        }
        public void DeleteMembers()
        {
            conn.DeleteAll<Usuario>();
        }
    }
}
