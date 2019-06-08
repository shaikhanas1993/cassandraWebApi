using Cassandra.Mapping.Attributes;  

namespace cassandraWebapi.Models
{
    [Table("musicplaylist")]  
    public class PlayList
    {
        [Column("SongId")]  
        public int SongId  { get; set;}
        
        [Column("SongName")]  
        public string SongName { get; set; } 
       
        [Column("Year")]  
        public int Year {get;set;} 
        
        [Column("Singer")]  
        public string Singer { get; set;}
        
    }

}