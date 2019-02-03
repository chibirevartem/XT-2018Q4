using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epam.Task07.Entities;
using Epam.Task07.BLL.Interfaces;
using Epam.Task07.txtDAL.Interfaces;

namespace Epam.Task07.BLL
{
    public class AwardsLogic : IAwardsLogic
    {
        private const string allAwardsCacheKey = "GetAllAwards";
        private const string allUsersCacheKey = "GetAllUsers";

        private readonly IAwardsDAO awardsDAO;
        private readonly ICacheLogic cacheLogic;

        public AwardsLogic(IAwardsDAO awardsDAO, ICacheLogic cacheLogic)
        {
            this.awardsDAO = awardsDAO;
            this.cacheLogic = cacheLogic;
        }

        public bool Add(string awardTitle)
        {
            if (string.IsNullOrWhiteSpace(awardTitle))
            {
                return false;
            }
            else
            {
                try
                {
                    cacheLogic.Delete(allAwardsCacheKey);
                    awardsDAO.Add(new Award { Title = awardTitle,});
                }
                catch (Exception)
                {

                    throw new Exception();
                }
                return true;
            }
        }

        public IEnumerable<Award> GetAll()
        {
            var cacheResult = cacheLogic.Get<IEnumerable<Award>>(allAwardsCacheKey);

            if (cacheResult==null)
            {
                var result = awardsDAO.GetAll().ToArray();
                cacheLogic.Add(allAwardsCacheKey,result);

                return result;
            }
            else
            {
                return cacheResult;
            }
        }

        public bool Remove(int id)
        {
            cacheLogic.Delete(allUsersCacheKey);
            cacheLogic.Delete(allAwardsCacheKey);
            var result = awardsDAO.Remove(id);

            return result;
        }

        public bool RemoveAll()
        {
            cacheLogic.Delete(allAwardsCacheKey);
            cacheLogic.Delete(allUsersCacheKey);
            var result = awardsDAO.RemoveAll();
            return result;
        }

    }
}
