using Firebase;
using Firebase.Database;
using Firebase.Database.Query;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExLog
{
    internal class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://exlog-9f27b-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public async Task AddRecord(string n, string t, string d, double r, string u)
        {
            await firebase
                .Child("PersonalRecords")
                .PostAsync(new PersonalRecord()
                {
                    Name = n,
                    Type = t,
                    Date = d,
                    Record = r,
                    Unit =u,
                });
        }
        public async Task AddExerciseRecord(string n, string d, double r)
        {
            await firebase
                .Child(n)
                .PostAsync(new ExerciseRecord()
                {
                    Date = d,
                    Record = r,
                });
        }

        public async Task<List<PersonalRecord>> GetAllPersonalRecord()
        {
            return (await firebase
                .Child("PersonalRecords")
                .OnceAsync<PersonalRecord>()).Select(item => new PersonalRecord
                {
                    Name = item.Object.Name,
                    Type = item.Object.Type,
                    Date = item.Object.Date,
                    Record = item.Object.Record,
                    Unit = item.Object.Unit,

                }).ToList();
        }

        public async Task<List<ExerciseRecord>> GetAllExerciseRecord(string n)
        {
            return (await firebase
                .Child(n)
                .OnceAsync<ExerciseRecord>()).Select(item => new ExerciseRecord
                {
                    Date = item.Object.Date,
                    Record = item.Object.Record,
                }).ToList();
        }

    }

}
