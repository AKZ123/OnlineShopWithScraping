using ECom.Database;
using ECom.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services
{
    public class ScreperService
    {
        #region Singleton
        public static ScreperService Instance
        {
            get
            {
                if (instance == null) instance = new ScreperService();
                {
                    return instance;
                }
            }
        }
        private static ScreperService instance{get;set;}
        private ScreperService()
        {

        }
        #endregion

        public void AddScreper(ScreperURL screperURL)
        {
            using (var context=new CBContext())
            {
                context.Entry(screperURL).State = System.Data.Entity.EntityState.Unchanged;
                context.ScreperURLs.Add(screperURL);
                context.SaveChanges();
            }
        }

        public List<ScreperURL> GetScreperNames(int productID)
        {
            using (var context=new CBContext())
            {
                return context.ScreperURLs.Where(x=>x.ProductID==productID).ToList();
            }
        }

        public ScreperURL GetScreper(int ScreperId)
        {
            using (var context=new CBContext())
            {
                return context.ScreperURLs.Find(ScreperId);
            }
        }

    }
}
