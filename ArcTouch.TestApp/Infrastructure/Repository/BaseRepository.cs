using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace ArcTouch.TestApp
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        readonly object _lock = new object();
        readonly IUIFunctions uiFunctionsService;
        readonly IMobileCenterCrashes mobileCeterCrashesService;

        public BaseRepository(IUIFunctions uiFunc,
                              MobileCenterCrashes mbcService)
        {
            uiFunctionsService = uiFunc;
            mobileCeterCrashesService = mbcService;

            if (App.AppSQLiteConnection == null)
            {
                App.AppSQLiteConnection = DBContext.Instance;
                CreateDB();
            }
        }

        /// <summary>
        /// Creates the db.
        /// </summary>
        void CreateDB()
        {
            try
            {
                App.AppSQLiteConnection.CreateTable<Dates>(SQLite.CreateFlags.None);
                App.AppSQLiteConnection.CreateTable<Results>(SQLite.CreateFlags.None);
                App.AppSQLiteConnection.CreateTable<Images>(SQLite.CreateFlags.None);
                App.AppSQLiteConnection.CreateTable<Genres>(SQLite.CreateFlags.None);
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.CreateDatabaseErrorMessage, ToastType.Error, 8000);
            }
        }

        /// <summary>
        /// Add the specified TEntity.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Add(T TEntity)
        {
            try
            {
                lock (_lock)
                    App.AppSQLiteConnection.InsertOrReplaceWithChildren(TEntity, true);
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.SaveLocalDataErrorMessage, ToastType.Error, 8000);
            }
        }

        /// <summary>
        /// Delete the specified TEntity.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Delete(T TEntity)
        {
            try
            {
                lock (_lock)
                    App.AppSQLiteConnection.Delete(TEntity, true);
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.DeleteLocalDataErrorMessage, ToastType.Error, 8000);
            }
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        public T Get(int pkId)
        {
            try
            {
                lock (_lock)
                {
                    return App.AppSQLiteConnection.GetWithChildren<T>(pkId, true);
                }
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GetLocalDataErrorMessage, ToastType.Error, 8000);
                return new T();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public List<T> GetAll()
        {
            try
            {
                lock (_lock)
                    return App.AppSQLiteConnection.GetAllWithChildren<T>();
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GetLocalDataErrorMessage, ToastType.Error, 8000);
                return new List<T>();
            }
        }

        /// <summary>
        /// Gets all with predicate.
        /// </summary>
        /// <returns>The all with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                lock (_lock)
                    return App.AppSQLiteConnection.GetAllWithChildren(predicate, true);
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GetLocalDataErrorMessage, ToastType.Error, 8000);
                return new List<T>();
            }
        }

        /// <summary>
        /// Gets the with predicate.
        /// </summary>
        /// <returns>The with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public T GetWithPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                lock (_lock)
                    return App.AppSQLiteConnection.GetAllWithChildren(predicate, true).FirstOrDefault();
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GetLocalDataErrorMessage, ToastType.Error, 8000);
                return new T();
            }
        }

        /// <summary>
        /// Update the specified TEntity.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Update(T TEntity)
        {
            try
            {
                lock (_lock)
                    App.AppSQLiteConnection.Update(TEntity);
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.UpdateLocalDataErrorMessage, ToastType.Error, 8000);
            }
        }

        /// <summary>
        /// Any this instance.
        /// </summary>
        /// <returns>The any.</returns>
        public bool Any()
        {
            try
            {
                lock (_lock)
                    return App.AppSQLiteConnection.Table<T>().Any();
            }
            catch
            {
                mobileCeterCrashesService.AskBeforeSendCrashReport();
                uiFunctionsService.ShowToast(Constants.GetLocalDataErrorMessage, ToastType.Error, 8000);
                return false;
            }
        }
    }
}