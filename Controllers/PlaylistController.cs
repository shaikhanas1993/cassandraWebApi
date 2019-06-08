using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cassandraWebapi.Models;
using cassandraWebapi.DataAccess;

namespace cassandraWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        
         private readonly IDataAccessProvider _dataAccessProvider;  

        public PlaylistController(IDataAccessProvider dataAccessProvider)  
        {  
            _dataAccessProvider = dataAccessProvider;  
        } 
        
        // GET api/values
        [HttpGet]
        // [Route("api/playList/list")]  
        public async Task<IEnumerable<PlayList>> Get()
        {
            Console.WriteLine("-----------XXXXXXXXXXXXx------------------");
            
             var musicPlaylists =  await _dataAccessProvider.GetAllRecords();  
            //   foreach (var row in musicPlaylists)
            //     {
                   
            //        Console.WriteLine("-------------------");
            //        Console.WriteLine(row.Singer);
            //          Console.WriteLine("-------------------");
            //     }

                return musicPlaylists;
        }

    }
}
