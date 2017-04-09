using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ArcTouch.TestApp
{
    /// <summary>
    /// Service Layer (Pattern) Class
    /// </summary>
    public class ApplicationServices<T> : IApplicationServices<T> where T : class, new()
    {
        readonly IBaseRepository<T> _baseRepository;
        readonly IMobileCenterCrashes mobileCeterCrashesService;
        readonly IMovieApplicationServices movieServices;
        readonly IConnectivityFunctions connectivityFunctionsService;

        public ApplicationServices(IBaseRepository<T> baseRepository,
                                   IMobileCenterCrashes mbcService,
                                   IMovieApplicationServices mService,
                                   IConnectivityFunctions connFuncService)
        {
            mobileCeterCrashesService = mbcService;
            movieServices = mService;
            connectivityFunctionsService = connFuncService;
            _baseRepository = baseRepository;

            App.AppHttpClient = BaseHttpClient.Instance;
        }

        /// <summary>
        /// Add the specified TEntity.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Add(T TEntity)
        {
            _baseRepository.Add(TEntity);
        }

        /// <summary>
        /// Delete the specified TEntity.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Delete(T TEntity)
        {
            _baseRepository.Delete(TEntity);
        }

        /// <summary>
        /// Get the specified pkId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="pkId">Pk identifier.</param>
        public T Get(int pkId)
        {
            return _baseRepository.Get(pkId);
        }

        /// <summary>
        /// Get the specified query, operation and parameters for online operations.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="operation">Operation.</param>
        /// <param name="parameters">Parameters.</param>
        public async Task<T> GetRemoteData(APIOperations operation, string parameters)
        {
            try
            {
                if (!await connectivityFunctionsService.IsConnectedAsync())
                    throw new ConnectionException();

                var data = await App.AppHttpClient.GetAsync($"{operation.GetDescription()}{parameters}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    var dataAsString = await data.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(dataAsString))
                    {
                        var jsonObject = JObject.Parse(dataAsString);
                        var entityName = typeof(T).Name.ToLower();
                        var obj = jsonObject[entityName];
                        var entity = ((JObject)obj).ToObject<T>();

                        if (!App.DisableDatabaseOperations)
                            Add(entity);

                        var all = GetAll();
                        return all.Last();
                    }
                }
                throw new FetchRemoteDataException();
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                throw new FetchRemoteDataException();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public List<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        /// <summary>
        /// Gets all for online operations.
        /// </summary>
        /// <returns>The all.</returns>
        /// <param name="operation">Operation.</param>
        /// <param name="parameters">Parameters.</param>
        public async Task<List<T>> GetAllRemoteData(APIOperations operation, string parameters)
        {
            try
            {
                if (!await connectivityFunctionsService.IsConnectedAsync())
                    throw new ConnectionException();
                
                var data = await App.AppHttpClient.GetAsync($"{operation.GetDescription()}{parameters}");

                if (data != null && data.IsSuccessStatusCode)
                {
                    var dataAsString = await data.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(dataAsString))
                    {
                        var jsonObject = JObject.Parse(dataAsString);
                        var entityName = typeof(T).Name.ToLower();
                        var obj = jsonObject[entityName];
                        var entities = ((JArray)obj).ToObject<List<T>>();

                        if (typeof(T) == typeof(Results))
                            entities = movieServices.AssociateGenresWithMovies(entities as List<Results>) as List<T>;

                        if (!App.DisableDatabaseOperations)
                            entities.ForEach((o) => Add(o as T));

                        return GetAll();
                    }
                }
                throw new FetchRemoteDataException();
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                throw new FetchRemoteDataException();
            }
        }

        /// <summary>
        /// Gets all with predicate.
        /// </summary>
        /// <returns>The all with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.GetAllWithPredicate(predicate);
        }

        /// <summary>
        /// Gets the with predicate.
        /// </summary>
        /// <returns>The with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public T GetWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return _baseRepository.GetWithPredicate(predicate);
        }

        /// <summary>
        /// Update the specified TEntity.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Update(T TEntity)
        {
            _baseRepository.Update(TEntity);
        }
    }
}