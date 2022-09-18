﻿using Finances.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.CrossCutting.Helper
{
    public static class SessionHelper
    {
        public static T Get<T>(this ISession session, string key = null)
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;
            return session.TryGetValue(key, out byte[] bytes) ? JsonConvert.DeserializeObject<T>(GetString(bytes)) : default(T);
        }
        public static void Set<T>(this ISession session, T instance, string key = null)
        {
            if (string.IsNullOrEmpty(key))
                key = typeof(T).FullName;
            session.Set(key, GetBytes(JsonConvert.SerializeObject(instance)));
        }
        public static Users GetUsuario(this ISession session) => session.Get<Users>() == null ? session.Get<Users>(SessionKeys.Usuario) : session.Get<Users>();
        public static bool isLogado(this ISession session)
        {
            if (session.TryGetValue(typeof(Users).FullName, out byte[] bytesUsr))
                if (!string.IsNullOrEmpty(GetString(bytesUsr)))
                    return true;
            if (session.TryGetValue(SessionKeys.Usuario, out byte[] bytes))
                if (!string.IsNullOrEmpty(GetString(bytes)))
                    return true;
            return false;
        }
        private static byte[] GetBytes(string str) => Encoding.UTF8.GetBytes(str);
        private static string GetString(byte[] bytes) => Encoding.UTF8.GetString(bytes);
    }
    public static class SessionKeys
    {
        public static readonly string Usuario = "Usuario";
    }
}
