using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDocker.interfaces;
using TestDocker.Models;

namespace TestDocker.Services
{
    static public class GetINameById<T> where T : INameId
    {

       public static string GetName(List<T> db, int id)
        {
            return db.FirstOrDefault(a => a.Id == id).Name; ;
        }


        public async static Task<string> GetNameAsync(List<T> db, int id)
        {
           return await Task.Run(() => GetName(db, id));
        }
    }
}
