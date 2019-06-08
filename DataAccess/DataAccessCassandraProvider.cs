    using cassandraWebapi.Models;  
    using Cassandra;  
    using Cassandra.Mapping;  
    using Microsoft.Extensions.Logging;  
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Threading.Tasks;  
      
    namespace cassandraWebapi.DataAccess  
    {  
        public class DataAccessCassandraProvider : IDataAccessProvider  
        {  
            private readonly ILogger _logger;  
            private readonly IMapper mapper;  
            public DataAccessCassandraProvider(ILoggerFactory loggerFactory)  
            {  
                _logger = loggerFactory.CreateLogger("DataAccessCassandraProvider");  
                mapper = new Mapper(CassandraInitializer.session);  
               

            }  
      
            public async Task<IEnumerable<PlayList>> GetAllRecords()  
            {  
                IEnumerable<PlayList> musicPlaylists = await mapper.FetchAsync<PlayList>("SELECT * FROM MusicPlaylist");  
                // IEnumerable<PlayList> musicPlaylists =  mapper.Fetch<PlayList>("SELECT * FROM MusicPlaylist");  
                return musicPlaylists;  
            }


            public async Task<PlayList> GetSingleRecord(int id)  
            {  
                var playList = await mapper.SingleOrDefaultAsync<PlayList>("SELECT * FROM MusicPlaylist WHERE SongId = ?", id);  
                return playList;  
            }    

            public async Task AddRecord(PlayList playList)  
            {  
                await mapper.InsertAsync(playList);  
                
            } 

            public async Task DeleteRecord(int id)  
            {  
                var deleteStatement = new SimpleStatement("DELETE FROM MusicPlaylist WHERE SongId = ? ", id);  
                await CassandraInitializer.session.ExecuteAsync(deleteStatement);  
            }  

            public async Task UpdateRecord(int id,PlayList playList)  
            {  
               await mapper.UpdateAsync<PlayList>("SET Singer = ? WHERE SongId = ? and SongName = ?", playList.Singer, id,playList.SongName);
      
                
            }  


        }  
    }  
