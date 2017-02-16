using _365ThreeSixtyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _365ThreeSixtyAPI.Factories
{
    public class missionFactory
         
    {
        public _365ThreeSixtyAPIContext db = new _365ThreeSixtyAPIContext();


        public void updateMissionKeywords(mission mis)
        {
            //delete all the values from the key word dicionary
            db.keywordDictionary.RemoveRange(db.keywordDictionary);


            //split up mission into indvidual words
            string mission = mis.missionStatement;

            mission = mission.Replace(',', ' ');
            mission = mission.Replace('.', ' ');
            mission = mission.Replace('?', ' ');
            mission = mission.Replace('!', ' ');
            mission = mission.Replace(';', ' ');
            mission = mission.Replace(':', ' ');
            mission = mission.Replace('(', ' ');
            mission = mission.Replace(')', ' ');
            List<string> kw = mission.Split(' ').ToList()
                ;

            // compare and delete exclusions
           
            List<string> ex = db.exclusions.Select(x => x.exclusion).ToList();

            int originalNumberOfKeywords = kw.Count;
            int keywordsLeft = originalNumberOfKeywords;

            for (int i = 0; i < originalNumberOfKeywords-1; i++)
                {
                    if (i >= keywordsLeft)
                    {
                        break;
                    }

                    foreach (string e in ex)
                    {
                        string k = kw[i];
                        string x = e;

                        if (k.ToLower() == x.ToLower())
                        {
                            kw.RemoveAt(i);
                            i = i - 1;
                            keywordsLeft = kw.Count;
                            break;
                        }
                    }
                
                }


            //write keywords to table
            foreach(string k in kw)
            {
                if (!(string.IsNullOrEmpty(k)))
                {
                    keywordDictionary keywords = new keywordDictionary();
                    keywords.keyword = k;
                    db.keywordDictionary.Add(keywords);
                }
            }
           db.SaveChanges();
        }
    }
}