using countingksps.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace countingksps.Repositories
{
    internal class CountingKSRepository:ICountingKSRepository
    {
        CountingKSContext countingKSContext;
        public CountingKSRepository(CountingKSContext countingKSContext)
        {
            this.countingKSContext = countingKSContext;
        }


        public IEnumerable<Food> GetAllFoods()
        {
            return countingKSContext.GetFoods();
        }

        public IEnumerable<Food> GetAllFoodsWithMeasures()
        {
            return countingKSContext.GetFoodsWithMeasures();
        }

        

        public Food GetFood(int id)
        {
            return countingKSContext.GetFood(id);
        }

        public IEnumerable<Measure> GetMeasuresForFood(int foodId)
        {
            return countingKSContext.GetMeasuresForFood(foodId);
        }

        public Measure GetMeaure(int foodId,int id)
        {
            return countingKSContext.GetMeasure(foodId, id);
        }


        public IEnumerable<Diary> GetDiaries(string userName)
        {
            return countingKSContext.GetDiaries(userName);
        }

        public Diary GetDiary(string userName, DateTime diaryId)
        {
            return countingKSContext.GetDiary(userName, diaryId);
        }

        public int Test(string str)
        {
            throw new NotImplementedException();
        }
    }
}