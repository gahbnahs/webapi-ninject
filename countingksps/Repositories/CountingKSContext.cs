using countingksps.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace countingksps.Repositories
{
    internal class CountingKSContext
    {


        static List<Diary> diariesList = new List<Diary>()
        {
             new Diary() { url="", date = DateTime.Now.Date },
             new Diary() { url="", date = DateTime.Now.Date.AddDays(1) },
             new Diary() { url="", date = DateTime.Now.Date.AddDays(-34) },


        };


        static List<Measure> meauresList = new List<Measure>()
        {
             new Measure() { Id=1,Description="1 cup" ,TotalFat=12.1M,
                        Food = new Food() {  Id =1,Description="Butter"} },
                    new Measure() { Id=2,Description="2 cup" ,TotalFat=12.211M,
                        Food = new Food() {  Id =1,Description="Butter"} },
                     new Measure() { Id=3,Description="measure2" ,TotalFat=12.2M,
                        Food = new Food() {  Id =2,Description="Milk"} },
                     new Measure() { Id=4,Description="measure3" ,TotalFat=12.3M,
                        Food = new Food() {  Id =3,Description="Cheese"} },
                     new Measure() { Id=5,Description="measure4" ,TotalFat=12.4M,
                        Food = new Food() {  Id =4,Description="Oil"} }

        };

        internal Diary GetDiary(string userName, DateTime diaryId)
        {
            return diariesList.FirstOrDefault(d => d.date.Equals(diaryId));
        }

        static List<Food> foodList = new List<Food>()
        {
            new Food() {Id=1,Description="Butter" },
            new Food() {Id=2,Description="Milk" },
            new Food() {Id=3,Description="Cheese" },
            new Food() {Id=4,Description="Oil" },
        };

        internal IEnumerable<Diary> GetDiaries(string userName)
        {
            return diariesList;
        }

        static List<Food> foodListWithMeasures = new List<Food>()
        {
            new Food()
            {
                Id =1,Description="Butter",
                Measures = new List<Measure>
                {
                    new Measure() { Id=1,Description="1 cup" ,TotalFat=12.1M,
                        Food = new Food() {  Id =1,Description="Butter"} },
                    new Measure() { Id=2,Description="2 cup" ,TotalFat=12.211M,
                        Food = new Food() {  Id =1,Description="Butter"} }
                }
            },
            new Food()
            {
                Id =2,Description="Milk",
                Measures = new List<Measure>
                {
                    new Measure() { Id=3,Description="measure2" ,TotalFat=12.2M,
                        Food = new Food() {  Id =2,Description="Milk"} }
                }
            },
            new Food()
            {
                Id =3,Description="Cheese",
                Measures = new List<Measure>
                {
                    new Measure() { Id=4,Description="measure3" ,TotalFat=12.3M,
                        Food = new Food() {  Id =3,Description="Cheese"} }
                }
            },
            new Food()
            {
                Id =4,Description="Oil",
                Measures = new List<Measure>
                {
                    new Measure() { Id=5,Description="measure4" ,TotalFat=12.4M,
                        Food = new Food() {  Id =4,Description="Oil"} }
                }
            },
        };

        public CountingKSContext()
        {
        }

        public IEnumerable<Food> GetFoods()
        {
            return foodList;
        }


        public IEnumerable<Food> GetFoodsWithMeasures()
        {
            return foodListWithMeasures;
        }


        public Food GetFood(int id)
        {
            return foodListWithMeasures.FirstOrDefault(f => f.Id.Equals(id));
        }


        public IEnumerable<Measure> GetMeasuresForFood(int foodId)
        {
            return meauresList.FindAll(m => m.Food.Id.Equals(foodId));
        }


        public Measure GetMeasure(int foodId, int id)
        {
            return meauresList.FirstOrDefault(m => m.Id.Equals(id) && m.Food.Id.Equals(foodId));
        }
    }
}