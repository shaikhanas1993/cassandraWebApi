    using System.Collections.Generic;  
    using System.Threading.Tasks; 
    using cassandraWebapi.Models; 
      
    namespace cassandraWebapi.DataAccess  
    {  
        public interface IDataAccessProvider  
        {  
            // Task AddRecord(PlayList playList);  
            // Task UpdateRecord(PlayList playList);  
            // Task DeleteRecord(string id);  
            // Task<PlayList> GetSingleRecord(string id);  
            Task<IEnumerable<PlayList>> GetAllRecords();  
        }  
    }  