using System;
using System.Collections.Generic;

namespace MetricsManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetAll();

        IList<T> GetByTimePeriod(int agentid, DateTimeOffset timeFrom, DateTimeOffset timeTo);

        IList<T> GetByTimePeriodSorted(int agentid, DateTimeOffset timeFrom, DateTimeOffset timeTo);

        long GetLastTime(int id);

        T GetById(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
