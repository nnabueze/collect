using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ErcasCollect.DataAccess;
using ErcasCollect.Domain.Models;

namespace ErcasCollect.Helpers.IdGenerator
{
    public class IdGenerator
    {



        public static string GetUniqueKey(int maxSize , int type)
        {

         
            // for just numeric
            if (type== 1)
            {

                char[] chars = new char[62];
                string randomset;
                randomset = "1234567890";
                chars = randomset.ToCharArray();
                int size = maxSize;
                byte[] data = new byte[1];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                size = maxSize;
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
                StringBuilder result = new StringBuilder(size);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);

                }
                return result.ToString();
            }
            else
            {
             
                char[] chars = new char[62];
                string randomset;
                randomset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                chars = randomset.ToCharArray();
                int size = maxSize;
                byte[] data = new byte[1];
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                crypto.GetNonZeroBytes(data);
                size = maxSize;
                data = new byte[size];
                crypto.GetNonZeroBytes(data);
                StringBuilder result = new StringBuilder(size);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);

                }
                return result.ToString();
            }

          
   
}

        //private string genNextId()
        //{
        //    var id = (from a in context.
        //              orderby a.nomor_nasabah descending
        //              select a.nomor_nasabah).First();

        //    return id.ToString();
        //}

        public  static string  CreateNumberSeriesFor(string acronym,string idfor, int lastissued)
        {

            ApplicationDbContext context = new ApplicationDbContext();
             var  idforexist = context.NumberSeries
   .Where(ru => ru.IdFor == "ercasbiller").FirstOrDefault();

            if (idforexist==null)
            {
                NumberSeries newmember = new NumberSeries();
                newmember.Acronym = acronym;
                newmember.IdFor = idfor;
              
                newmember.LastIssued = lastissued;
                newmember.LastDateIssued = DateTime.UtcNow;
                context.NumberSeries.Add(newmember);
                context.SaveChangesAsync();
                return acronym+Convert.ToString(lastissued);
            }
            else
            {
                idforexist.LastIssued += 1;
                idforexist.LastDateIssued = DateTime.UtcNow;
                context.SaveChanges();
                return acronym + Convert.ToString(lastissued);
            }
           
        
        }

        public static string RandomInt(int length)
        {
            var rnd = new Random(DateTime.UtcNow.Millisecond);
            string rNum = DateTime.UtcNow.Millisecond + rnd.Next(0, 900000000).ToString();
            string temp = "";
            for (int i = 0; i < length; i++)
            {
                temp += rNum[rnd.Next(0, rNum.Length)].ToString();
            }

            return temp;
        }
    }
}
