using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using static Assignment1.App;

namespace Assignment1.Model
{
    public class Works
    {

        public string WorkName { get; set; }




        public async Task<bool> AddWorks(string userkey, string workname)
        {
            try
            {
                var work = new Works()
                {
                    WorkName = workname


                };
                await client
                    .Child($"Users/{userkey}/Works")
                    .PostAsync(work);
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public ObservableCollection<Users> GetworkList(string userkey)
        {
            var worklist = client
                 .Child($"Users/{userkey}/Works")
                .AsObservable<Users>()
                .AsObservableCollection();
            return worklist;
        }
    }
}

