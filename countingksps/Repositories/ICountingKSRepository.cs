using countingksps.Models;
using System;
using System.Collections.Generic;

namespace countingksps.Repositories
{
    public interface ICountingKSRepository
    {
        IEnumerable<Food> GetAllFoods();
        IEnumerable<Food> GetAllFoodsWithMeasures();
        IEnumerable<Measure> GetMeasuresForFood(int foodId);
        Food GetFood(int id);
        Measure GetMeaure(int foodIds, int id);
        IEnumerable<Diary> GetDiaries(string userName);
        Diary GetDiary(string userName, DateTime diaryId);

        int Test(string str);
    }
}