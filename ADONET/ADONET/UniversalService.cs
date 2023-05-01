using System;
using System.Data;

namespace ADONET
{
	public class UniversalService
	{
		private HelperSQL _database;
		public UniversalService(HelperSQL sQL)
		{
			_database = sQL;
		}


        public List<Universal> GetAll()
        {
            string query = $"SELECT m.Id AS Id,c.Name AS CategoryName ,m.Name As MusicsNames, m.Duration AS MusicDuration, a.Name+' '+a.Surname AS Artists FROM Categories AS c\nJOIN Musics AS m ON CategoryId=c.Id\nJOIN ArtistMusics AS artm ON MusicsId=m.Id\nJOIN Artists As a ON artm.ArtistsId= a.Id";
			DataTable table = _database.ExecuteQuery(query);
			List<Universal> universals = new List<Universal>();
			foreach (DataRow item in table.Rows)
			{
				Universal universal = new Universal
				{
					Id = Convert.ToInt32(item["Id"]),
					CatogoryName = item["CategoryName"].ToString(),
					MusicName = item["MusicsNames"].ToString(),
					MusicDuration = TimeOnly.Parse(item["MusicDuration"].ToString()),
					Artist = item["Artists"].ToString()
                };
				universals.Add(universal);
			}
			return universals;
        }


        public void GetAllShow()
        {
            var universals = GetAll();
            foreach (var item in universals)
            {
                Console.WriteLine($"{item.Id}. {item.MusicName}->[{item.MusicDuration}] =>{item.Artist} --{item.CatogoryName}");
            }
        }
    }
}

