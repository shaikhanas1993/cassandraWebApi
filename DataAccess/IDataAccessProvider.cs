    using System.Collections.Generic;  
    using System.Threading.Tasks; 
    using cassandraWebapi.Models; 
      
    namespace cassandraWebapi.DataAccess  
    {  
        public interface IDataAccessProvider  
        {  
             Task AddRecord(PlayList playList);  
            Task UpdateRecord(int id,PlayList playList);  
             Task DeleteRecord(int id);  
             Task<PlayList> GetSingleRecord(int id);  
            Task<IEnumerable<PlayList>> GetAllRecords();  
        }  
    }  
