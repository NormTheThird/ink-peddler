﻿using InkPeddler.Data.Interceptors;
using System.Data.Entity.Infrastructure.Interception;

namespace InkPeddler.Services
{
    public interface IBaseService
    {

    }

    public class BaseService : IBaseService
    {
        public ILoggingService LoggingService { get; private set; }
        public IMapperService MapperService { get; private set; }

        public BaseService()
        {
            this.LoggingService = new LoggingService();
            this.MapperService = new MapperService();
            DbInterception.Add(new TemporalTableCommandTreeInterceptor());
        } 
    }
}
