using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment1.App;
using Firebase.Database;

namespace Assignment1.Model
{
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //add or create
        public async Task<bool> AddUser(string fname, string lname, string mail, string pword)
        {
            try
            {
                var evaluateEmail = (await client.Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault(a => a.Object.Email == mail);

                if (evaluateEmail == null)
                {
                    var user = new Users()
                    {
                        FirstName = fname,
                        LastName = lname,
                        Email = mail,
                        Password = pword
                    };
                    await client
                        .Child("Users")
                        .PostAsync(user);
                    client.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        //login code
        public async Task<bool> UserLogin(string email, string Pass)
        {
            try
            {
                var evaluateEmail = (await client.Child("Users")
                                  .OnceAsync<Users>())
                                  .FirstOrDefault
                                  (a => a.Object.Email == email &&
                                   a.Object.Password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }
           
        }
        //retrieve code
        public async Task<string> GetUserKey(string mail)
            {
            try
            {
                var getuserkey = (await client.Child("Users").OnceAsync<Users>()).
                    FirstOrDefault(a=>a.Object.Email == mail);
                if (getuserkey == null) return null;

                  firstname = getuserkey.Object.FirstName;
                  lastname = getuserkey.Object.LastName;
                  pass = getuserkey.Object.Password;

                return getuserkey?.Key;
            }
            catch(Exception ex)
            {
                return null;
            }

            }


        //update code
        public async Task<bool> editdata(string lname,string fname)
        {
            try
            {
                var evaluteuser = (await client
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.Email == email);
                if(evaluteuser != null)
                {
                    Users user = new Users
                    {
                        Email = email,  
                        FirstName = fname,
                        LastName = lname,
                        Password = pass
                    };
                    await client.Child("Users").Child(key).PatchAsync(user);
                    client.Dispose();
                }
                client.Dispose();
                return false;
            }
            catch(Exception ex)
            {
                client.Dispose();
                return false;
            }
        }
        public async Task<string> Deletedata()
        {
            try
            {
                await client
                    .Child($"Users/{key}")
                    .DeleteAsync();
                return "removed";
            }
            catch (Exception ex)
            {
                return " error";
            }
        }




        public ObservableCollection<Users> GetUserList()
        {
            var userlist = client
                 .Child("Users")
                .AsObservable<Users>()
                .AsObservableCollection();
            return userlist;

        }


    }
   

}